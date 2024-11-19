using DataDomain.Data.Context;
using DataDomain.Data.entity;
using DataDomain.Persistence.Repo;
using DataDomain.Persistence.Utilities;
using DataDomain.Types.ConfigTypes;
using DataDomain.Types.States;
using EntityFramework.Exceptions.Common;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Security.Cryptography;

namespace DataDomain.Persistence.AppService;

public interface IAuthService
{
    (bool ok, Client? cli, StateObject state) Login(string username, string password);
    (bool ok, Client? cli, StateObject state) Signup(string username, string password, string email);
    (bool ok, StateObject state) SendActivationEmail(Guid clientId);
    public (bool ok, StateObject state) ActivateEmail(Client cli, string codeValue);
}

public class AuthService : IAuthService
{
    PGContext context;
    IClientRepo clientRepo;
    ICodeRepo codeRepo;
    MailSender mailSender;


    public AuthService(PGContext context, SMTPConfig smtp)
    {
        this.context = context;
        this.clientRepo = new ClientRepo(context);
        this.codeRepo = new CodeRepo(context);
        this.mailSender = new MailSender(smtp);
    }

    public (bool ok, Client? cli, StateObject state) Login(string username, string password)
    {
        Client? cli = clientRepo.GetClientByUserName(username);
        if (cli == null) {
            return (false, null, BadStates.UsernameNotFound);
        }
        if (cli.Password == password)
        {
            return (true, cli, BadStates.None);
        }
        return (false, null, BadStates.WrongPassword);

    }

    public (bool ok, Client? cli, StateObject state) Signup(string username, string password, string email)
    {
        Client cli = clientRepo.AddClient(username, password, email);
        try
        {
            context.SaveChanges();
        }
        catch (UniqueConstraintException ex)
        {
            string name = ex.ConstraintName;

            return name switch
            {
                "IX_Clients_Email" => (false, null, BadStates.EmailAlreadyExists),
                "IX_Clients_UserName" => (false, null, BadStates.UsernameAlreadyExists),
                _ => (false, null, BadStates.UniqueConstraintDefault),
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine("[my log] un expected error: " + ex.Message);
            return (false, null, BadStates.UnHandled);
        }
        
        return (true, cli, BadStates.None);
    }

    private static string ActivateEmailString(string code, DateTime validUntil)
    {
        return 
$$"""
your activation code is: {{code}}
this code expires at: {{validUntil.ToString()}} (UTC)
""";
    }

    public (bool ok, StateObject state) SendActivationEmail(Guid clientId)
    {
        Code? previousCode = codeRepo.GetCodeByClientId(clientId);
        Client? cli = clientRepo.GetClientById(clientId);

        if (cli == null)
        {
            return (false, BadStates.ClientNotFound);
        }

        if (cli.IsActivated)
        {
            Console.WriteLine("[my log] email is already activated");
            return (false, BadStates.ClientAlreadyActivated);
        }

        string code = RandomNumberGenerator.GetInt32(0, 1000000).ToString().PadLeft(6, '0');

        if (previousCode != null) {
            TimeSpan delta = DateTime.UtcNow.Subtract(previousCode.UpdatedAt);
            if (delta.TotalMinutes < 1)
            {
                Console.WriteLine("[my log] to fast "+ delta.TotalMinutes.ToString());
                return (false, BadStates.TooFast);
            }

            codeRepo.UpdateCode(previousCode, code);
            try
            {
                context.SaveChanges();
                mailSender.SendEmail(cli.Email, "VpnSystem Activation Code", ActivateEmailString(code, previousCode.ValidUntil));
                return (true, BadStates.None);

            } catch (UniqueConstraintException ex)
            {
                Console.WriteLine("[my log] update code problem: unique constraint for field: " + ex.ConstraintName);
                return (false, BadStates.UniqueConstraintDefault);
            } catch (Exception ex)
            {
                Console.WriteLine("[my log] update code problem: " + ex.Message);
                return (false, BadStates.UnHandled);
            }
 
        }

        Code codeEnt = codeRepo.AddCode(clientId, code);
        try
        {
            context.SaveChanges();
            mailSender.SendEmail(cli.Email, "VpnSystem Activation Code", ActivateEmailString(code, codeEnt.ValidUntil));
            return (true, BadStates.None);

        }
        catch (UniqueConstraintException ex)
        {
            Console.WriteLine("[my log] Add code problem: unique constraint for field: " + ex.ConstraintName);
            return (false, BadStates.UniqueConstraintDefault);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("[my log] wrong smtp config");
            return (false, BadStates.WrongSMTPConfig);

        }
        catch (Exception ex)
        {
            Console.WriteLine("[my log] Add code problem: " + ex.Message);
            return (false, BadStates.UnHandled);
        }
        
    }

    public (bool ok, StateObject state) ActivateEmail(Client cli, string codeValue)
    {
        Code? codeEnt = codeRepo.GetCodeByClientId(cli.Id);
        if (codeEnt == null)
        {
            Console.WriteLine("[my log] Code is not found");
            return (false, BadStates.CodeNotFound);
        }

        if (codeValue != codeEnt.Value)
        {
            Console.WriteLine("[my log] Entered code is wrong");
            return (false, BadStates.WrongCode);
        }

        if (codeEnt.ValidUntil.Subtract(DateTime.UtcNow).Seconds < 0)
        {
            return (false, BadStates.CodeExpired);
        }
        clientRepo.ActivateClient(cli);

        try
        {
            context.SaveChanges();
            Console.WriteLine("[my log] email activated");
            return (true, BadStates.None);
        }
        catch (UniqueConstraintException ex)
        {
            Console.WriteLine("[my log] activating client: unique constraint voliation: " + ex.ConstraintName);
            return (false, BadStates.UniqueConstraintDefault);
        }
        catch (Exception ex)
        {
            Console.WriteLine("[my log] activating client: unhandled error: " + ex.Message);
            return (false, BadStates.UnHandled);
        }
    }
}

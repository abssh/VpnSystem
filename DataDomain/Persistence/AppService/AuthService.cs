using DataDomain.Data.Context;
using DataDomain.Data.entity;
using DataDomain.Persistence.Repo;
using DataDomain.Types.States;
using EntityFramework.Exceptions.Common;

namespace DataDomain.Persistence.AppService;

public interface IAuthService
{
    (bool ok, Client? cli, StateObject state) Login(string username, string password);
    (bool ok, StateObject state) Signup(string username, string password, string email);
}

public class AuthService : IAuthService
{
    PGContext context;
    IClientRepo clientRepo;
    public AuthService(PGContext context) 
    {
        this.context = context;
        this.clientRepo = new ClientRepo(context);
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

    public (bool ok, StateObject state) Signup(string username, string password, string email)
    {
        clientRepo.AddClient(username, password, email);
        try
        {
            context.SaveChanges();
        }
        catch (UniqueConstraintException ex)
        {
            string name = ex.ConstraintName;

            return name switch
            {
                "IX_Clients_Email" => (false, BadStates.EmailAlreadyExists),
                "IX_Clients_UserName" => (false, BadStates.UsernameAlreadyExists),
                _ => (false, BadStates.UniqueConstraintDefault),
            };
        }
        catch (Exception ex)
        {
            return (false, BadStates.UnHandled);
        }
        
        return (true, BadStates.None);
    }

    // TODO: ActivateEmail
}

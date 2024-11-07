using DataDomain.Data.Context;
using DataDomain.Data.entity;
using DataDomain.Persistence.Repo.Interfaces;
using DataDomain.Types.States;

namespace DataDomain.Persistence.AppService
{
    public interface IAuthService
    {
        (bool ok, Client? cli, StateObject state) LoginWithUsernameAndPassword(string username, string password);
    }

    public class AuthService : IAuthService
    {
        DSContext context;
        IClientRepo clientRepo;
        public AuthService(DSContext context, IClientRepo clientRepo) 
        {
            this.context = context;
            this.clientRepo = clientRepo;
        }

        public (bool ok, Client? cli, StateObject state) LoginWithUsernameAndPassword(string username, string password)
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
    }
}

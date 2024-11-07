using DataDomain.Data.Context;
using DataDomain.Data.entity;
using DataDomain.Persistence.Repo.Interfaces;

namespace DataDomain.Persistence.AppService
{
    public interface IAuthService
    {
        (bool ok, Guid id, string msg) LoginWithUsernameAndPassword(string username, string password);
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

        public (bool ok, Guid id, string msg) LoginWithUsernameAndPassword(string username, string password)
        {
            Client? cli = clientRepo.GetClientByUserName(username);
            if (cli == null) {
                return (false, Guid.Empty, "username  not found");
            }
            if (cli.Password == password)
            {
                return (true, cli.Id, "");
            }
            return (false, Guid.Empty, "wrong password");

        }
    }
}

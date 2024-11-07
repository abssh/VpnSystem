
using DataDomain.Data.Context;
using DataDomain.Data.entity;
using DataDomain.Persistence.Repo.Interfaces;

namespace DataDomain.Persistence.Repo
{
    public class ClientRepo : IClientRepo
    {
        DSContext context;
        public ClientRepo(DSContext context)
        {
            this.context = context;
        }
        public Client? GetClientByUserName(string userName)
        {
            return context.Clients.FirstOrDefault(cli => cli.UserName == userName);
        }
    }
}

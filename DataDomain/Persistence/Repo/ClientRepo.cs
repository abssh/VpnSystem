
using DataDomain.Data.Context;
using DataDomain.Data.entity;

namespace DataDomain.Persistence.Repo
{
    public interface IClientRepo
    {
        public void AddClient(string userName, string password, string email);
        public Client? GetClientByUserName(string userName);
    }
    public class ClientRepo : IClientRepo
    {
        DSContext context;
        public ClientRepo(DSContext context)
        {
            this.context = context;
        }

        public void AddClient(string userName, string password, string email)
        {
            Client cli = new()
            {
                Email = email,
                UserName = userName,
                Password = password,
                CreatedAt = DateTime.Now.ToUniversalTime(),
            };

            context.Clients.Add(cli);
        }

        public Client? GetClientByUserName(string userName)
        {
            return context.Clients.FirstOrDefault(cli => cli.UserName == userName);
        }

    }
}


using DataDomain.Data.Context;
using DataDomain.Data.entity;

namespace DataDomain.Persistence.Repo
{
    public interface IClientRepo
    {
        public Client AddClient(string userName, string password, string email);
        public Client? GetClientByUserName(string userName);
        public Client? GetClientById(Guid id);
        public void ActivateClient(Client cli);
    }
    public class ClientRepo : IClientRepo
    {
        DSContext context;
        public ClientRepo(DSContext context)
        {
            this.context = context;
        }

        public Client AddClient(string userName, string password, string email)
        {
            Client cli = new()
            {
                Email = email,
                UserName = userName,
                Password = password,
                CreatedAt = DateTime.UtcNow,
            };

            context.Clients.Add(cli);
            return cli;
        }

        public Client? GetClientByUserName(string userName)
        {
            return context.Clients.FirstOrDefault(cli => cli.UserName == userName);
        }

        public Client? GetClientById(Guid id)
        {
            return context.Clients.FirstOrDefault(c => c.Id == id);
        }

        public void ActivateClient(Client cli)
        {
            cli.IsActivated = true;
            context.Clients.Update(cli);
        }

    }
}

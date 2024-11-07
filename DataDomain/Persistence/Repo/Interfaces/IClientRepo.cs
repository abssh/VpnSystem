using DataDomain.Data.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain.Persistence.Repo.Interfaces
{
    public interface IClientRepo
    {
        public Client? GetClientByUserName(string userName);
    }
}

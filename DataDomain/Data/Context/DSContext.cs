using DataDomain.Data.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain.Data.Context
{
    public interface DSContext: IDisposable
    {
        public DbSet<Client> Clients { get;}
        public DbSet<Code> Codes { get;}
    }
}

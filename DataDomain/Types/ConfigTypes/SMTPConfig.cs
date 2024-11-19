using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain.Types.ConfigTypes
{
    public class SMTPConfig
    {
        public string Host { get; set;}
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

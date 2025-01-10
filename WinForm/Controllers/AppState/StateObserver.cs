using DataDomain.Data.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.Controllers.AppState
{
    public class StateObserver
    {
        private Client? _client;

        Client? GetClient() { return _client; }
        public void SetClient(Client? client) { _client = client; }
    }
}

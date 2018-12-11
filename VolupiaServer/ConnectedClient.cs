using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolupiaInterfaces;

namespace VolupiaServer
{
    public class ConnectedClient : Client
    {
        public IClient connection;
        public bool TryingToConnect;
        
        public bool Connected { get; set; }
    }
}

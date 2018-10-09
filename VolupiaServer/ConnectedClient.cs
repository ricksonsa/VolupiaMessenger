using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolupiaInterfaces;

namespace VolupiaServer
{
    public class ConnectedClient
    {
        public IClient connection;
        public int Id { get; set; }
        public int Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public bool Connected { get; set; }
    }
}

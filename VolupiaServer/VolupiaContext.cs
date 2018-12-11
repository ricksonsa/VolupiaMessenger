using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace VolupiaServer
{
    public class VolupiaContext : DbContext
    {
        readonly Type providerService = typeof(SqlProviderServices);

        public DbSet<Client> Clients{ get; set; }

        public DbSet<Friend> Friends { get; set; }
    }
}

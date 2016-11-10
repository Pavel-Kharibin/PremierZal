using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace PremierZal.Data.Configuration
{
    internal class DbConfig : DbConfiguration
    {
        public DbConfig()
        {
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        }
    }
}
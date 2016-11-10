using System.Data.Entity;
using PremierZal.Data.Configuration;

namespace PremierZal.Data
{
    [DbConfigurationType(typeof(DbConfig))]
    public class PremierZalDbContext : DbContext
    {
        public PremierZalDbContext(string connectionStringName)
            : base(connectionStringName)
        {
            Database.SetInitializer<PremierZalDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SessionConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
using System.Data.Entity.ModelConfiguration;
using PremierZal.Data.Models;

namespace PremierZal.Data.Configuration
{
    internal class SessionConfiguration : EntityTypeConfiguration<Session>
    {
        public SessionConfiguration()
        {
            ToTable("Sessions");
            Property(p => p.Id).HasColumnName("ID");
            Property(p => p.Name).HasColumnName("Name");
            Property(p => p.Begins).HasColumnName("Begins");
        }
    }
}
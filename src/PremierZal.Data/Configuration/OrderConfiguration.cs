using System.Data.Entity.ModelConfiguration;
using PremierZal.Common.Models;

namespace PremierZal.Data.Configuration
{
    internal class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("Orders");
            Property(p => p.Id).HasColumnName("ID");
            Property(p => p.SessionId).HasColumnName("SessionID");
            Property(p => p.TicketsCount).HasColumnName("TicketCount");
            Property(p => p.Sold).HasColumnName("Sold");
        }
    }
}
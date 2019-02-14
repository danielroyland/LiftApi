using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LiftApi.Models;

namespace LiftApi.Dataaksess
{
    public class LiftContext : DbContext
    {
        public LiftContext() : base("LiftContext")
        {

        }

        public DbSet<Treningsøkt> Treningsøkt { get; set; }
        public DbSet<Løft> Løft { get; set; }
        public DbSet<Bruker> Brukere { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
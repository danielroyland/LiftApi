using LiftApi.Models;

namespace LiftApi.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Dataaksess.LiftContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dataaksess.LiftContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //var løft = new Maksløft { Benkpress = 100, Knebøy = 120, Markløft = 165 };
            //context.Maksløft.AddOrUpdate(løft);
            context.SaveChanges();
        }
    }
}

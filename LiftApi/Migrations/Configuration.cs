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

            //var l�ft = new Maksl�ft { Benkpress = 100, Kneb�y = 120, Markl�ft = 165 };
            //context.Maksl�ft.AddOrUpdate(l�ft);
            context.SaveChanges();
        }
    }
}

namespace MvcGarageGroup.Migrations
{
    using MvcGarageGroup.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcGarageGroup.Models.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcGarageGroup.Models.LibraryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.VehicleTypes.AddOrUpdate(
            new VehicleType { Name = "Car" },
            new VehicleType { Name = "Motorcycle" },
            new VehicleType { Name = "Van" },
            new VehicleType { Name = "Truck" },
            new VehicleType { Name = "Lorry" }
            );

            context.SaveChanges();
        }
    }
}

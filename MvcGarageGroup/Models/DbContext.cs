using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=MvcGarageConnection") { } 

        public DbSet<Owner> Owners { get; set; }
        public DbSet<ParkedVehicle> ParkedVehicles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        public LibraryContext(string connString) : base(connString)
        {
        }


    }


}
using MvcGarage.CommonFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.Models
{
        [Table("Vehicle")]
        public class Vehicle
        {
            [Key]
            public int VehicleID { get; set; }
            public Enumerators.VehicleType VehicleTypeID { get; set; }
            public string Color { get; set; }
            public string LicencePlate { get; set; }
            // Test
            // Test annhuh
        }
   
}
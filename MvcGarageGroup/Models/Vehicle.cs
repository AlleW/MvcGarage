using MvcGarage.CommonFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

//Dummy comment
namespace MvcGarageGroup.Models
{
        [Table("Vehicle")]
        public class Vehicle
        {
            [Key]
            public int VehicleID { get; set; }

            [Display(Name = "Type")]
            [ForeignKey("VehicleType")]
            public virtual int VehicleTypeID { get; set; }

            public string LicencePlate { get; set; }
            public string Color { get; set; }

            public virtual VehicleType VehicleType { get; set; }
        }
   
}
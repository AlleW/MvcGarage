using MvcGarage.CommonFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.Models
{
    
    [Table("ParkedVehicle")]
    public class ParkedVehicle
    {
        [Key]
        public int ParkedVehicleID { get; set; }
        public int VehicleID { get; set; }
        public Enumerators.ParkingSpot ParkingSpotID { get; set; }
        public int OwnerID { get; set; }
        public bool Present { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime?StopTime { get; set; }
    }
}
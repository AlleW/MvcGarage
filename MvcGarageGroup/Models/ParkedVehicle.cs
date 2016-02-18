using MvcGarage.CommonFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.Models
{
    //Dummy comment
    [Table("ParkedVehicle")]
    public class ParkedVehicle
    {
        [Key]
        public int ParkedVehicleID { get; set; }

        [Display(Name = "Vehicle")]
        [ForeignKey("Vehicle")]
        public virtual int VehicleID { get; set; }

        [Display(Name = "Parking Spot")]
        public Enumerators.ParkingSpot ParkingSpotID { get; set; }

        [Display(Name = "Owner")]
        [ForeignKey("Owner")]
        public virtual int OwnerID { get; set; }

        public bool Present { get; set; }

        [Display(Name = "Parked")]
        [MvcGarageGroup.CommonFunctions.MyAwesomeDateValidation(ErrorMessage = "Invalid date !")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Exit Time")]
        [MvcGarageGroup.CommonFunctions.MyAwesomeDateValidation(ErrorMessage = "Invalid date !")]
        public DateTime? StopTime { get; set; }

        //[NotMapped]
        //public Owner Owner { get; set; }
        //[NotMapped]
        //public SearchForm SearchForm { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
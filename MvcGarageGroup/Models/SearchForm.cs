using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.Models
{
    public class SearchForm
    {
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }
        [Display(Name = "Vehicle Type")]
        public int VehicleTypeID { get; set; }
        public virtual string ViewName { get; set; }
    }
}
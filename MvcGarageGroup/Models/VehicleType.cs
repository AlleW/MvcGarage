﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.Models
{
    [Table("VehicleType")]
    public class VehicleType
    {
        [Key]
        public int VehicleTypeID { get; set; }
        public string Name { get; set; }
    }

}
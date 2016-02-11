using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.Models
{

        [Table("Owner")]
        public class Owner
        {
            [Key]
            public int OwnerID { get; set; }
            public string SSN { get; set; }
            public string Name { get; set; }
        }
   
}
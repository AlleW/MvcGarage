using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.CommonFunctions
{
        public class MyAwesomeDateValidation : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dt;
                bool parsed = DateTime.TryParse((string)value, out dt);
                if (!parsed)
                    return false;

                // eliminate other invalid values, etc
                // if contains valid hour for your business logic, etc

                return true;
            }
        }
}
using MvcGarage.CommonFunctions;
using MvcGarageGroup.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.DAL
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        // Get context for specific connectionstring.
        private LibraryContext context = new LibraryContext(ConfigurationManager.ConnectionStrings["MvcGarageConnection"].ConnectionString);

        #region Get all vehicles and color as list for listbox.
        public List<VehicleTypeListItem> GetAll()
        {
            return (from row in context.VehicleTypes
                    join vtype in context.VehicleTypes on row.VehicleTypeID equals vtype.VehicleTypeID
                    select new VehicleTypeListItem
                    {
                        VehicleTypeID = row.VehicleTypeID,
                        Name = row.Name
                    }).ToList();
        }
        #endregion

    

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
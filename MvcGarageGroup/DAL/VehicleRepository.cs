using MvcGarage.CommonFunctions;
using MvcGarageGroup.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.DAL
{
    public class VehicleRepository : IVehicleRepository
    {
        // Get context for specific connectionstring.
        private LibraryContext context = new LibraryContext(ConfigurationManager.ConnectionStrings["MvcGarageConnection"].ConnectionString);

        #region Get all Vehicles.
        public IEnumerable<Vehicle> GetVehicles()
        {
            return context.Vehicles;
        }
        #endregion

        #region Get all vehicles and color as list for listbox.
        public List<VehicleListItem> GetAllRegistrationAndType()
        {
            return (from row in context.Vehicles
                    select new VehicleListItem
                    {
                        VehicleID = row.VehicleID,
                        VehicleAndType = row.LicencePlate + " (" + ((Enumerators.VehicleType)row.VehicleTypeID).ToString() + ")"
                    }).ToList();
        }
        #endregion

        //EnumDisplayStatus enumDisplayStatus = (EnumDisplayStatus)value;
        //string stringValue = enumDisplayStatus.ToString();



        public void Save()
        {
            context.SaveChanges();
        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}
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

        public Vehicle GetVehicleByVehicleID(int vehicleID)
        {
            return context.Vehicles.FirstOrDefault(o => o.VehicleID == vehicleID);
        }

        public Vehicle GetVehicleByLicencePlate(string licencePlate)
        {
            return context.Vehicles.FirstOrDefault(o => o.LicencePlate == licencePlate);
        }


        public int AddVehicle(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
            Save();

            // Return the VehicleID of the recently added vehicle
            return context.Vehicles.Max(o => o.VehicleID);
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            context.Vehicles.Remove(vehicle);
            Save();
        }

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
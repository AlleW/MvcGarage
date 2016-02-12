using MvcGarageGroup.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.DAL
{
    public class ParkedVehicleRepository : IParkedVehicleRepository
    {
        // Get context for specific connectionstring.
        private LibraryContext context = new LibraryContext(ConfigurationManager.ConnectionStrings["MvcGarageConnection"].ConnectionString);

        #region Get all ParkedVehicles.
        public IEnumerable<ParkedVehicle> GetAllParkedVehiclesOrderByParkingSpot()
        {
            return context.ParkedVehicles.OrderBy(o => o.ParkingSpotID);
        }
        #endregion

        public void ParkVehicle(ParkedVehicle parkedVehicle)
        {
            context.ParkedVehicles.Add(parkedVehicle);
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
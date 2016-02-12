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
        private LibraryContext context = new LibraryContext(ConfigurationManager.ConnectionStrings["EFContext"].ConnectionString);

        #region Get all ParkedVehicles.
        public IEnumerable<ParkedVehicle> GetParkedVehicles()
        {
            return context.ParkedVehicles;
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

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
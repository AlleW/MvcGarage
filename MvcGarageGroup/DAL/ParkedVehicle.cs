using MvcGarage.CommonFunctions;
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

        public void AddParkVehicle(ParkedVehicle parkedVehicle)
        {
            context.ParkedVehicles.Add(parkedVehicle);
        }

        public void RemoveParkVehicle(ParkedVehicle parkedVehicle)
        {
            context.ParkedVehicles.Remove(parkedVehicle);
        }

        public List<ParkingSpotListItem> GetAllVacantParkingSpots()
        {
            var ListOfallParkingSpots = Enum.GetValues(typeof(Enumerators.ParkingSpot))
                                                .Cast<Enumerators.ParkingSpot>()
                                                .Select(c => new ParkingSpotListItem() { ParkingSpotID  = (int)c, Name = c.ToString() })
                                                .ToList();

            var listOfOccupiedParkingSpots = (from row in context.ParkedVehicles
                                                select new ParkingSpotListItem
                                                {
                                                    ParkingSpotID = (int)row.ParkingSpotID,
                                                    Name = ((Enumerators.ParkingSpot)row.ParkingSpotID).ToString()
                                                }).ToList();

            return ListOfallParkingSpots.Except(listOfOccupiedParkingSpots).ToList();
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
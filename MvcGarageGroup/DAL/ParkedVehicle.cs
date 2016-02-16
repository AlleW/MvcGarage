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
            var listOfParkedVehicles = context.ParkedVehicles.OrderBy(o => o.ParkingSpotID);

            // Include Vehicle and Owner objects into each ParkedVehicle
            foreach (var parkedVehicle in listOfParkedVehicles)
            {

                // Get owner by OwnerID
                parkedVehicle.Owner = new OwnerRepository().GetOwnerByOwnerID(parkedVehicle.OwnerID);

                // Get Vehicle by VehicleID
                parkedVehicle.Vehicle = new VehicleRepository().GetVehicleByVehicleID(parkedVehicle.VehicleID);
            }

            // return modifed object
            return listOfParkedVehicles;
        }
        #endregion

        public void AddParkVehicle(ParkedVehicle parkedVehicle)
        {
            context.ParkedVehicles.Add(parkedVehicle);
            Save();
        }

        public void RemoveParkVehicle(ParkedVehicle parkedVehicle)
        {
            context.ParkedVehicles.Remove(parkedVehicle);
        }

        public List<ParkingSpotListItem> GetAllVacantParkingSpots()
        {
            var ListOfallParkingSpots = Enum.GetValues(typeof(Enumerators.ParkingSpot))
                                                .Cast<Enumerators.ParkingSpot>()
                                                .Select(c => new ParkingSpotListItem() { ParkingSpotID = (int)c, Name = c.ToString() })
                                                .ToList();

            var listOfOccupiedParkingSpots = (from row in context.ParkedVehicles
                                              select new ParkingSpotListItem
                                              {
                                                  ParkingSpotID = (int)row.ParkingSpotID,
                                                  Name = ((Enumerators.ParkingSpot)row.ParkingSpotID).ToString()
                                              }).ToList();

            foreach (var item in listOfOccupiedParkingSpots)
            {
                ParkingSpotListItem i = ListOfallParkingSpots.FirstOrDefault(o => o.ParkingSpotID == item.ParkingSpotID);
                ListOfallParkingSpots.Remove(i);
            }

            //var Alle = ListOfallParkingSpots.RemoveAll(o => o == listOfOccupiedParkingSpots.Where(i => i.ParkingSpotID == 101));
            //           ListOfallParkingSpots.RemoveAll(o => o == listOfOccupiedParkingSpots.Where(i => i.ParkingSpotID == 101));

            //var qwerty = listOfOccupiedParkingSpots.FirstOrDefault(i => i.ParkingSpotID == 101);
            //    List<ParkingSpotListItem> aqqq = ListOfallParkingSpots.RemoveAll(o => listOfOccupiedParkingSpots.FirstOrDefault(i => i.ParkingSpotID == 101));

            //var a = listOfOccupiedParkingSpots.Except(ListOfallParkingSpots).ToList();
            //var a = ListOfallParkingSpots.Except(listOfOccupiedParkingSpots).ToList();
            // var b = 
            // List<ParkingSpotListItem> b = ListOfallParkingSpots.RemoveAll(o => listOfOccupiedParkingSpots.Contains(o).);
            return ListOfallParkingSpots;
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
using MvcGarageGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.DAL
{
    public interface IParkedVehicleRepository : IDisposable 
    {

        IEnumerable<ParkedVehicle> GetAllParkedVehiclesOrderByParkingSpot();

        void AddParkVehicle(ParkedVehicle parkedVehicle);
        void RemoveParkVehicle(ParkedVehicle parkedVehicle);

        List<ParkingSpotListItem> GetAllVacantParkingSpots();

        void Save(); 
    }
}
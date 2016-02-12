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

        void ParkVehicle(ParkedVehicle parkedVehicle);

        void Save(); 
    }
}
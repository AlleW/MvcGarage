using MvcGarageGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.DAL
{
    public interface IParkedVehicleRepository : IDisposable 
    {

        IEnumerable<ParkedVehicle> GetParkedVehicles();

        void ParkVehicle(ParkedVehicle parkedVehicle);

        void Save(); 
    }
}
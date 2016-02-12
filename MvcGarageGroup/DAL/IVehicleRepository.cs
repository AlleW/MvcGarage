using MvcGarageGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.DAL
{
    public interface IVehicleRepository : IDisposable 
    {
        IEnumerable<Vehicle> GetVehicles();

        void Save(); 
    }
}
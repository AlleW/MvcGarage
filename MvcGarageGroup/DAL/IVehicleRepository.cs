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
        List<VehicleListItem> GetAllRegistrationAndType();

        Vehicle GetVehicleByVehicleID(int vehicleID);
        Vehicle GetVehicleByLicencePlate(string licencePlate);
        void DeleteVehicle(Vehicle vehicle);

        int AddVehicle(Vehicle vehicle);

        void Save(); 
    }
}
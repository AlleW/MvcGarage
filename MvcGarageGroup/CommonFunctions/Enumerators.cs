using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGarage.CommonFunctions
{
    public class Enumerators
    {
        public enum VehicleTypeEnum
        {
            Car = 1,
            Motorcycle =2,
            Van = 3,
            Truck = 4,
            Lorry = 5
        }

        // MvcGarage.CommonFunctions.Enumerators.ParkingSpot
        public enum ParkingSpot
        {
            A1 = 101,
            A2 = 102,
            A3 = 103,
            A4 = 104,
            A5 = 105,
            A6 = 106,
            A7 = 107,
            A8 = 108,
            A9 = 109,
            A10 = 110,
            A11 = 111,
            A12 = 112,

            B1 = 201,
            B2 = 202,
            B3 = 203,
            B4 = 204,
            B5 = 205,
            B6 = 206,
            B7 = 207,
            B8 = 208,
            B9 = 209,
            B10 = 210,
            B11 = 211,
            B12 = 212,

            C1 = 301,
            C2 = 302,
            C3 = 303,
            C4 = 304,
            C5 = 305,
            C6 = 306,
            C7 = 307,
            C8 = 308,
            C9 = 309,
            C10 = 310,
            C11 = 311,
            C12 = 312
        }

        public enum MainListSortFields
        {
            ParkingSpotDesc = 1,
            LicencePlateDesc = 2,
            ColorDesc = 3,
            VehicleTypeDesc = 4,
            SSNDesc = 5,
            NameDesc = 6,
            PresentDesc = 7,
            StartTimeDesc = 8,
            StopTimeDesc = 9,
            ParkingSpot = 11,
            LicencePlate = 12,
            Color = 13,
            VehicleType = 14,
            SSN = 15,
            Name = 16,
            Present = 17,
            StartTime = 18,
            StopTime = 19
        }
    }
}
using MvcGarageGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.DAL
{
    public interface IOwnerRepository : IDisposable 
    {
        IEnumerable<Owner> GetOwners();

        void Save(); 
    }
}
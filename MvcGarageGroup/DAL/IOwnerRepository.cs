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
        List<OwnerListItem> GetSSNAndNames();

        Owner GetOwnerByOwnerID(int ownerID);
        Owner GetOwnerBySSN(string ssn);
        void DeleteOwner(Owner owner);

        int AddOwner(Owner owner);

        void Save(); 
    }
}
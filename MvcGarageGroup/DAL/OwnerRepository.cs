using MvcGarageGroup.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcGarageGroup.DAL
{
    public class OwnerRepository : IOwnerRepository
    {
        // Get context for specific connectionstring.
        private LibraryContext context = new LibraryContext(ConfigurationManager.ConnectionStrings["MvcGarageConnection"].ConnectionString);

        #region Get all Owners.
        public IEnumerable<Owner> GetOwners()
        {
            return context.Owners;
        }
        #endregion

        #region Get all Owners and SSN as list for listbox.
        public List<OwnerListItem> GetSSNAndNames()
        {
            return (from row in context.Owners
                        select new OwnerListItem
                        {
                            OwnerID = row.OwnerID,
                            SSNAndName = row.Name +  " ("+ row.SSN +")"
                        }).ToList();
        }
        #endregion


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
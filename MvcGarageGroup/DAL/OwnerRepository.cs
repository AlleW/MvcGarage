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
        private LibraryContext context = new LibraryContext(ConfigurationManager.ConnectionStrings["EFContext"].ConnectionString);

        #region Get all Companies exept those tagged as removed or not created yet.
        public IEnumerable<Owner> GetOwners()
        {
            return context.Owners;
        }
        #endregion

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
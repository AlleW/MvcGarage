using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcGarageGroup.Models;
using MvcGarageGroup.DAL;
using MvcGarage.CommonFunctions;

namespace MvcGarageGroup.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: ParkedVehicles
        public ActionResult Index()
        {
           // var parkedVehicles = db.ParkedVehicles.Include(p => p.Owner).Include(p => p.Vehicle);
            var parkedVehicles = new ParkedVehicleRepository().GetAllParkedVehiclesOrderByParkingSpot();

            // Store viewbag for us in partial view
            ViewBag.ToComboVehicleType = new VehicleTypeRepository().GetAll();
            ((List<VehicleTypeListItem>)ViewBag.ToComboVehicleType).Insert(0, new VehicleTypeListItem { VehicleTypeID = -1, Name = "<Not in list>" });


            var searchForm = (SearchForm)TempData["SearchForm"];
            if (searchForm != null)
            {
                if (!String.IsNullOrEmpty(searchForm.LicensePlate))
                {
                    parkedVehicles = parkedVehicles.Where(o => o.Vehicle.LicencePlate.ToLower() == searchForm.LicensePlate.ToLower());
                }

                if (searchForm.VehicleTypeID != -1)
                {
                    parkedVehicles = parkedVehicles.Where(o => o.Vehicle.VehicleTypeID == searchForm.VehicleTypeID);
                }
            }
            return View(parkedVehicles.ToList());
        }

        // GET: ParkedVehicles
        public ActionResult MainList(int? id)
        {
            // var parkedVehicles = db.ParkedVehicles.Include(p => p.Owner).Include(p => p.Vehicle);
            var parkedVehicles = new ParkedVehicleRepository().GetAllParkedVehiclesOrderByParkingSpot();

            // Store viewbag for us in partial view
            ViewBag.ToComboVehicleType = new VehicleTypeRepository().GetAll();
            ((List<VehicleTypeListItem>)ViewBag.ToComboVehicleType).Insert(0, new VehicleTypeListItem { VehicleTypeID = -1, Name = "<Not in list>" });


            var searchForm = (SearchForm)TempData["SearchForm"];
            if (searchForm != null)
            {
                if (!String.IsNullOrEmpty(searchForm.LicensePlate))
                {
                    parkedVehicles = parkedVehicles.Where(o => o.Vehicle.LicencePlate.ToLower() == searchForm.LicensePlate.ToLower());
                }

                if (searchForm.VehicleTypeID != -1)
                {
                    parkedVehicles = parkedVehicles.Where(o => o.Vehicle.VehicleTypeID == searchForm.VehicleTypeID);
                }
            }
    
            if (id != null)
            {
                //var alle = Enumerators.MainListSortFields;


                //Enumerators.MainListSortFields searchField = (Enumerators.MainListSortFields)Enum.Parse(typeof(Enumerators.MainListSortFields), value, true);

                

                
                switch (id)
                {
                    case (int)Enumerators.MainListSortFields.Color:
                        parkedVehicles = parkedVehicles.OrderBy(o => o.Vehicle.Color);
                        break;
                    case (int)Enumerators.MainListSortFields.ColorDesc:
                        parkedVehicles = parkedVehicles.OrderByDescending(o => o.Vehicle.Color);
                        break;
                    case (int)Enumerators.MainListSortFields.LicencePlate:
                        parkedVehicles = parkedVehicles.OrderBy(o => o.Vehicle.LicencePlate);
                        break;
                    case (int)Enumerators.MainListSortFields.LicencePlateDesc:
                        parkedVehicles = parkedVehicles.OrderByDescending(o => o.Vehicle.LicencePlate);
                        break;
                    case (int)Enumerators.MainListSortFields.Name:
                        parkedVehicles = parkedVehicles.OrderBy(o => o.Owner.Name);
                        break;
                    case (int)Enumerators.MainListSortFields.NameDesc:
                        parkedVehicles = parkedVehicles.OrderByDescending(o => o.Owner.Name);
                        break;
                    case (int)Enumerators.MainListSortFields.ParkingSpot:
                        parkedVehicles = parkedVehicles.OrderBy(o => o.ParkingSpotID);
                        break;
                    case (int)Enumerators.MainListSortFields.ParkingSpotDesc:
                        parkedVehicles = parkedVehicles.OrderByDescending(o => o.ParkingSpotID);
                        break;
                    case (int)Enumerators.MainListSortFields.Present:
                        parkedVehicles = parkedVehicles.OrderBy(o => o.Present);
                        break;
                    case (int)Enumerators.MainListSortFields.PresentDesc:
                        parkedVehicles = parkedVehicles.OrderByDescending(o => o.Present);
                        break;
                    case (int)Enumerators.MainListSortFields.SSN:
                        parkedVehicles = parkedVehicles.OrderBy(o => o.Owner.SSN);
                        break;
                    case (int)Enumerators.MainListSortFields.SSNDesc:
                        parkedVehicles = parkedVehicles.OrderByDescending(o => o.Owner.SSN);
                        break;
                    case (int)Enumerators.MainListSortFields.StartTime:
                        parkedVehicles = parkedVehicles.OrderBy(o => o.StartTime);
                        break;
                    case (int)Enumerators.MainListSortFields.StartTimeDesc:
                        parkedVehicles = parkedVehicles.OrderByDescending(o => o.StartTime);
                        break;
                    case (int)Enumerators.MainListSortFields.StopTime:
                        parkedVehicles = parkedVehicles.OrderBy(o => o.StopTime);
                        break;
                    case (int)Enumerators.MainListSortFields.StopTimeDesc:
                        parkedVehicles = parkedVehicles.OrderByDescending(o => o.StopTime);
                        break;
                    case (int)Enumerators.MainListSortFields.VehicleType:
                        parkedVehicles = parkedVehicles.OrderBy(o => o.Vehicle.VehicleType.Name);
                        break;
                    case (int)Enumerators.MainListSortFields.VehicleTypeDesc:
                        parkedVehicles = parkedVehicles.OrderByDescending(o => o.Vehicle.VehicleType.Name);
                        break;
                }

            }
            return View(parkedVehicles.ToList());
        }

        public ActionResult SearchFormPartialView(SearchForm searchForm)
        {

            //ViewBag.ToComboVehicleType = new VehicleTypeRepository().GetAll();
            //((List<VehicleTypeListItem>)ViewBag.ToComboVehicleType).Insert(0, new VehicleTypeListItem { VehicleTypeID = -1, Name = "<Not in list>" });

            return PartialView(new SearchForm());
        }

        [HttpPost]
        public ActionResult SearchFormPartialView_Update(SearchForm searchForm)
        {
            TempData["SearchForm"] = searchForm;

            return RedirectToAction(searchForm.ViewName);
            
        }

        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "SSN");
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "Color");
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParkedVehicleID,VehicleID,ParkingSpotID,OwnerID,Present,StartTime,StopTime")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "SSN", parkedVehicle.OwnerID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "Color", parkedVehicle.VehicleID);
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "SSN", parkedVehicle.OwnerID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "LicencePlate", parkedVehicle.Vehicle.LicencePlate);
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParkedVehicleID,VehicleID,ParkingSpotID,OwnerID,Present,StartTime,StopTime")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "SSN", parkedVehicle.OwnerID);
            ViewBag.VehicleID = new SelectList(db.Vehicles, "VehicleID", "Color", parkedVehicle.VehicleID);
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            db.ParkedVehicles.Remove(parkedVehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using MvcGarageGroup.DAL;
using MvcGarageGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGarageGroup.Controllers
{
    public class ParkVehicleController : Controller
    {
        // GET: ParkVehicle
        public ActionResult Index()
        {
            //ViewBag.OwnerModel = new Owner();
            //ViewBag.VehicleModel = new Vehicle();

            ViewBag.ToComboV = new VehicleRepository().GetAllRegistrationAndType();
            ((List<VehicleListItem>)ViewBag.ToComboV).Insert(0, new VehicleListItem { VehicleID = -1, VehicleAndType = "<Not in list>" });

            ViewBag.ToComboOwner = new OwnerRepository().GetSSNAndNames();
            ((List<OwnerListItem>)ViewBag.ToComboOwner).Insert(0, new OwnerListItem { OwnerID = -1, SSNAndName = "<Not in list>" });
            
            ViewBag.Message = "Park your Vehicle";

            return View();
            //return Content("Test mata in !!");
        }
    }
}
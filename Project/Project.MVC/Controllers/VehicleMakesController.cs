using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Service.DatabaseContext;
using Project.Service.Models;
using PagedList;
using Project.Service.ModelsView;
using Project.Service.CRUD;

namespace Project.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private VehicleService vehicleService;

        public VehicleMakeController()
        {
            vehicleService = VehicleService.Instance();
        }


        // GET: VehicleMakes
        public ActionResult Index(string sortOrder, string searchString, string searchBy, int? page)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AbrvSortParm = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";

            if (searchString == null)
            {
                return View(vehicleService.SortFilterPagingMake(sortOrder, "", "", page));
            }
            else
            {
                return View(vehicleService.SortFilterPagingMake(sortOrder, searchString, searchBy, page));
            }
        }

       
        

        // GET: VehicleMakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakeView makeV = vehicleService.FindIdMake(id);
            if (makeV == null)
            {
                return HttpNotFound();
            }
            return View(makeV);
        }

        // GET: VehicleMakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Abrv")] MakeView makeV)
        {
            if (ModelState.IsValid)
            {
                vehicleService.CreateVehicleMake(makeV);
                return RedirectToAction("Index");
            }

            return View(makeV);
        }

        // GET: VehicleMakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakeView makeV = vehicleService.FindIdMake(id); 
            if (makeV == null)
            {
                return HttpNotFound();
            }
            return View(makeV);
        }

        // POST: VehicleMakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Abrv")] MakeView makeView)
        {
            if (ModelState.IsValid)
            {
                vehicleService.EditVehicleMake(makeView);
                return RedirectToAction("Index");
            }
            return View(makeView);
        }

        // GET: VehicleMakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MakeView makeView = vehicleService.FindIdMake(id);
            if (makeView == null)
            {
                return HttpNotFound();
            }
            return View(makeView);
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicleService.DeleteVehicleMake(id);
            return RedirectToAction("Index");
        }
    }
}

      

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Service.CRUD;
using Project.Service.DatabaseContext;
using Project.Service.Models;
using Project.Service.ModelsView;

namespace Project.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private VehicleService vehicleService;

        public VehicleModelController()
        {
            vehicleService = VehicleService.Instance();
        }

        // GET: VehicleModels
        public ActionResult Index(string sortOrder, string searchString, string searchBy, int? page)
        {
            ViewBag.NameSortParmMake = string.IsNullOrEmpty(sortOrder) ? "make_desc" : "";
            ViewBag.NameSortParmModel = sortOrder == "Model" ? "model_desc" : "Model";
            ViewBag.AbrvSortParmModel = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";

            if (searchString == null)
            {
                return View(vehicleService.SortFilterPagingModel(sortOrder, "", "", page));
            }
            else
            {
                return View(vehicleService.SortFilterPagingModel(sortOrder, searchString, searchBy, page));
            }
        }

        // GET: VehicleModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelView modelView = vehicleService.FindIdModel(id);
            if (modelView == null)
            {
                return HttpNotFound();
            }
            return View(modelView);
        }

        // GET: VehicleModels/Create
        public ActionResult Create()
        {
            ViewBag.MakeID = new SelectList(vehicleService.GetAllVehicleMakes(), "ID", "Name");
            return View();
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MakeID,Name,Abrv,inStock")] ModelView modelView)
        {
            if (ModelState.IsValid)
            {
                vehicleService.CreateVehicleModel(modelView);
                return RedirectToAction("Index");
            }

            ViewBag.MakeID = new SelectList(vehicleService.GetAllVehicleMakes(), "ID", "Name", modelView.MakeID);
            return View(modelView);
        }

        // GET: VehicleModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelView modelView = vehicleService.FindIdModel(id);
            if (modelView == null)
            {
                return HttpNotFound();
            }
            ViewBag.MakeID = new SelectList(vehicleService.GetAllVehicleMakes(), "ID", "Name", modelView.MakeID);
            return View(modelView);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MakeID,Name,Abrv,inStock")] ModelView modelView)
        {
            if (ModelState.IsValid)
            {
                vehicleService.EditVehicleModel(modelView);
                return RedirectToAction("Index");

            }
            ViewBag.MakeID = new SelectList(vehicleService.GetAllVehicleMakes(), "ID", "Name", modelView.MakeID);
            return View(modelView);
        }

        // GET: VehicleModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelView modelView = vehicleService.FindIdModel(id);
            if (modelView == null)
            {
                return HttpNotFound();
            }
            return View(modelView);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicleService.DeleteVehicleModel(id);
            return RedirectToAction("Index");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeALLNav.Models;

namespace WeALLNav.Controllers
{
    public class AutoCarsController : Controller
    {
        private WeALLNEntities2 db = new WeALLNEntities2();

        // GET: AutoCars
        public ActionResult Index()
        {
            var autoCar = db.AutoCar.Include(a => a.Societe);
            return View(autoCar.ToList());
        }

        // GET: AutoCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoCar autoCar = db.AutoCar.Find(id);
            if (autoCar == null)
            {
                return HttpNotFound();
            }
            return View(autoCar);
        }

        // GET: AutoCars/Create
        public ActionResult Create()
        {
            ViewBag.No_Societe = new SelectList(db.Societe, "No_Ste", "Name_STE");
            return View();
        }

        // POST: AutoCars/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NoCar,Marque,Model,No_Societe,Capacity,Cilma,Available")] AutoCar autoCar)
        {
            if (ModelState.IsValid)
            {
                db.AutoCar.Add(autoCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.No_Societe = new SelectList(db.Societe, "No_Ste", "Name_STE", autoCar.No_Societe);
            return View(autoCar);
        }

        // GET: AutoCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoCar autoCar = db.AutoCar.Find(id);
            if (autoCar == null)
            {
                return HttpNotFound();
            }
            ViewBag.No_Societe = new SelectList(db.Societe, "No_Ste", "Name_STE", autoCar.No_Societe);
            return View(autoCar);
        }

        // POST: AutoCars/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NoCar,Marque,Model,No_Societe,Capacity,Cilma,Available")] AutoCar autoCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.No_Societe = new SelectList(db.Societe, "No_Ste", "Name_STE", autoCar.No_Societe);
            return View(autoCar);
        }

        // GET: AutoCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoCar autoCar = db.AutoCar.Find(id);
            if (autoCar == null)
            {
                return HttpNotFound();
            }
            return View(autoCar);
        }

        // POST: AutoCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutoCar autoCar = db.AutoCar.Find(id);
            db.AutoCar.Remove(autoCar);
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

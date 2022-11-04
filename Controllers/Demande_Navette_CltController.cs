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
    public class Demande_Navette_CltController : Controller
    {
        private WeALLNEntities2 db = new WeALLNEntities2();

        // GET: Demande_Navette_Clt
        public ActionResult Index()
        {
            var demande_Navette_Clt = db.Demande_Navette_Clt.Include(d => d.Client);
            return View(demande_Navette_Clt.ToList());
        }

        // GET: Demande_Navette_Clt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demande_Navette_Clt demande_Navette_Clt = db.Demande_Navette_Clt.Find(id);
            if (demande_Navette_Clt == null)
            {
                return HttpNotFound();
            }
            return View(demande_Navette_Clt);
        }

        // GET: Demande_Navette_Clt/Create
        public ActionResult Create()
        {
            ViewBag.No_Client = new SelectList(db.Client, "No_Client", "First_Name");
            return View();
        }

        // POST: Demande_Navette_Clt/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_demande,No_Client,Num_Car,Ville_Depart,Ville_Arrivee,Date_Depart,Date_Arrivee,Heur_debut,Heur_fin")] Demande_Navette_Clt demande_Navette_Clt)
        {
            if (ModelState.IsValid)
            {
                db.Demande_Navette_Clt.Add(demande_Navette_Clt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.No_Client = new SelectList(db.Client, "No_Client", "First_Name", demande_Navette_Clt.No_Client);
            return View(demande_Navette_Clt);
        }

        // GET: Demande_Navette_Clt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demande_Navette_Clt demande_Navette_Clt = db.Demande_Navette_Clt.Find(id);
            if (demande_Navette_Clt == null)
            {
                return HttpNotFound();
            }
            ViewBag.No_Client = new SelectList(db.Client, "No_Client", "First_Name", demande_Navette_Clt.No_Client);
            return View(demande_Navette_Clt);
        }

        // POST: Demande_Navette_Clt/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_demande,No_Client,Num_Car,Ville_Depart,Ville_Arrivee,Date_Depart,Date_Arrivee,Heur_debut,Heur_fin")] Demande_Navette_Clt demande_Navette_Clt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demande_Navette_Clt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.No_Client = new SelectList(db.Client, "No_Client", "First_Name", demande_Navette_Clt.No_Client);
            return View(demande_Navette_Clt);
        }

        // GET: Demande_Navette_Clt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demande_Navette_Clt demande_Navette_Clt = db.Demande_Navette_Clt.Find(id);
            if (demande_Navette_Clt == null)
            {
                return HttpNotFound();
            }
            return View(demande_Navette_Clt);
        }

        // POST: Demande_Navette_Clt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Demande_Navette_Clt demande_Navette_Clt = db.Demande_Navette_Clt.Find(id);
            db.Demande_Navette_Clt.Remove(demande_Navette_Clt);
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

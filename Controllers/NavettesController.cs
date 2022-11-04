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
    public class NavettesController : Controller
    {
        private WeALLNEntities2 db = new WeALLNEntities2();

        // GET: Navettes
        public ActionResult Index()
        {
            var navette = db.Navette.Include(n => n.Societe);
            return View(navette.ToList());
        }

        // GET: Navettes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navette navette = db.Navette.Find(id);
            if (navette == null)
            {
                return HttpNotFound();
            }
            return View(navette);
        }

        // GET: Navettes/Create
        public ActionResult Create()
        {
            ViewBag.No_Ste = new SelectList(db.Societe, "No_Ste", "Name_STE");
            return View();
        }

        // POST: Navettes/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_abonnement,No_Autocar,No_Ste,Date_debut,Date_fin,Heur_debut,Heur_fin,Ville_Depart,Ville_Arriver,Nbr_Max_Abonnee")] Navette navette)
        {
            if (ModelState.IsValid)
            {
                db.Navette.Add(navette);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.No_Ste = new SelectList(db.Societe, "No_Ste", "Name_STE", navette.No_Ste);
            return View(navette);
        }

        // GET: Navettes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navette navette = db.Navette.Find(id);
            if (navette == null)
            {
                return HttpNotFound();
            }
            ViewBag.No_Ste = new SelectList(db.Societe, "No_Ste", "Name_STE", navette.No_Ste);
            return View(navette);
        }

        // POST: Navettes/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_abonnement,No_Autocar,No_Ste,Date_debut,Date_fin,Heur_debut,Heur_fin,Ville_Depart,Ville_Arriver,Nbr_Max_Abonnee")] Navette navette)
        {
            if (ModelState.IsValid)
            {
                db.Entry(navette).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.No_Ste = new SelectList(db.Societe, "No_Ste", "Name_STE", navette.No_Ste);
            return View(navette);
        }

        // GET: Navettes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navette navette = db.Navette.Find(id);
            if (navette == null)
            {
                return HttpNotFound();
            }
            return View(navette);
        }

        // POST: Navettes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Navette navette = db.Navette.Find(id);
            db.Navette.Remove(navette);
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

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
    public class Line_OffreController : Controller
    {
        private WeALLNEntities2 db = new WeALLNEntities2();

        // GET: Line_Offre
        public ActionResult Index()
        {
            var line_Offre = db.Line_Offre.Include(l => l.Navette).Include(l => l.Societe);
            return View(line_Offre.ToList());
        }

        // GET: Line_Offre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line_Offre line_Offre = db.Line_Offre.Find(id);
            if (line_Offre == null)
            {
                return HttpNotFound();
            }
            return View(line_Offre);
        }

        // GET: Line_Offre/Create
        public ActionResult Create()
        {
            ViewBag.Id_Navette = new SelectList(db.Navette, "Id_abonnement", "Ville_Depart");
            ViewBag.Id_Ste = new SelectList(db.Societe, "No_Ste", "Name_STE");
            return View();
        }

        // POST: Line_Offre/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Offre,Id_Navette,Id_Ste,Date_Debut_Offre,Date_fin_Offre,Taux_Offre")] Line_Offre line_Offre)
        {
            if (ModelState.IsValid)
            {
                db.Line_Offre.Add(line_Offre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Navette = new SelectList(db.Navette, "Id_abonnement", "Ville_Depart", line_Offre.Id_Navette);
            ViewBag.Id_Ste = new SelectList(db.Societe, "No_Ste", "Name_STE", line_Offre.Id_Ste);
            return View(line_Offre);
        }

        // GET: Line_Offre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line_Offre line_Offre = db.Line_Offre.Find(id);
            if (line_Offre == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Navette = new SelectList(db.Navette, "Id_abonnement", "Ville_Depart", line_Offre.Id_Navette);
            ViewBag.Id_Ste = new SelectList(db.Societe, "No_Ste", "Name_STE", line_Offre.Id_Ste);
            return View(line_Offre);
        }

        // POST: Line_Offre/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Offre,Id_Navette,Id_Ste,Date_Debut_Offre,Date_fin_Offre,Taux_Offre")] Line_Offre line_Offre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(line_Offre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Navette = new SelectList(db.Navette, "Id_abonnement", "Ville_Depart", line_Offre.Id_Navette);
            ViewBag.Id_Ste = new SelectList(db.Societe, "No_Ste", "Name_STE", line_Offre.Id_Ste);
            return View(line_Offre);
        }

        // GET: Line_Offre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line_Offre line_Offre = db.Line_Offre.Find(id);
            if (line_Offre == null)
            {
                return HttpNotFound();
            }
            return View(line_Offre);
        }

        // POST: Line_Offre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Line_Offre line_Offre = db.Line_Offre.Find(id);
            db.Line_Offre.Remove(line_Offre);
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

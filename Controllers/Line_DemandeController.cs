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
    public class Line_DemandeController : Controller
    {
        private WeALLNEntities2 db = new WeALLNEntities2();

        // GET: Line_Demande
        public ActionResult Index()
        {
            var line_Demande = db.Line_Demande.Include(l => l.Demande_Navette_Clt);
            return View(line_Demande.ToList());
        }

        // GET: Line_Demande/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line_Demande line_Demande = db.Line_Demande.Find(id);
            if (line_Demande == null)
            {
                return HttpNotFound();
            }
            return View(line_Demande);
        }

        // GET: Line_Demande/Create
        public ActionResult Create()
        {
            ViewBag.Id_demand_Navette = new SelectList(db.Demande_Navette_Clt, "Id_demande", "Ville_Depart");
            return View();
        }

        // POST: Line_Demande/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_line_Cmd,Id_demand_Navette,Nbr_Demande")] Line_Demande line_Demande)
        {
            if (ModelState.IsValid)
            {
                db.Line_Demande.Add(line_Demande);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_demand_Navette = new SelectList(db.Demande_Navette_Clt, "Id_demande", "Ville_Depart", line_Demande.Id_demand_Navette);
            return View(line_Demande);
        }

        // GET: Line_Demande/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line_Demande line_Demande = db.Line_Demande.Find(id);
            if (line_Demande == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_demand_Navette = new SelectList(db.Demande_Navette_Clt, "Id_demande", "Ville_Depart", line_Demande.Id_demand_Navette);
            return View(line_Demande);
        }

        // POST: Line_Demande/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_line_Cmd,Id_demand_Navette,Nbr_Demande")] Line_Demande line_Demande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(line_Demande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_demand_Navette = new SelectList(db.Demande_Navette_Clt, "Id_demande", "Ville_Depart", line_Demande.Id_demand_Navette);
            return View(line_Demande);
        }

        // GET: Line_Demande/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line_Demande line_Demande = db.Line_Demande.Find(id);
            if (line_Demande == null)
            {
                return HttpNotFound();
            }
            return View(line_Demande);
        }

        // POST: Line_Demande/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Line_Demande line_Demande = db.Line_Demande.Find(id);
            db.Line_Demande.Remove(line_Demande);
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

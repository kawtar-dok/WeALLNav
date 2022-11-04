using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using WeALLNav.Models;

namespace WeALLNav.Controllers
{
    public class LoginAdminController : Controller
    {

        private WeALLNEntities2 db = new WeALLNEntities2();

        // GET: Login

        public ActionResult Index()
        {
            // ViewBag.user = Session["Admin"];
            return View();
        }

        public ActionResult About()
        {

            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Compagny()
        {
            return View();
        }
        public ActionResult AutoCars()
        {
            return View();
        }
        public ActionResult Navette()
        {
            return View();
        }
        public ActionResult Offredispo()
        {
            return View();
        }
        public ActionResult DemandeNavette()
        {
            return View();
        }
        public ActionResult Contact()
        {

            return View();
        }

       
    }
}
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
    public class LoginClientController : Controller
    {

        private WeALLNEntities2 db = new WeALLNEntities2();

        // GET: Login
      
        public ActionResult Index()
        {
           // ViewBag.user = Session["Client"];
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

         public ActionResult loginView()
       {

           return View();
       }
     
          public ActionResult inscrptionClientView()
          {

              return View();
          }

        //login
        [HttpPost]
        public ActionResult login(string username, string password)
        {

            var existe = db.Client.Where(s => s.Username == username && s.Password == password).FirstOrDefault();

            // traitement 
            if (existe != null)
            {
                Session["Client"] = existe;
              //  Session["User"] = existe.First_Name.ToString();
                return RedirectToAction("Index", "LoginClient");
            }
            else
            {
                ModelState.AddModelError("", "The Username or Password Incorrect !!");
            }
           

            return RedirectToAction("login", "LoginClient");
        }

        [HttpPost]
        public ActionResult inscrptionClient([Bind(Include = "First_Name,Last_Name,Username,Password,Telephone_Number,E_mail,City_Country")] Client client)
        {

            if (ModelState.IsValid)
            {
               
                db.Client.Add(client);
                db.SaveChanges();
                Session["User"] = client.First_Name.ToString();
                return RedirectToAction("login", "LoginClient");
            }
            return RedirectToAction("Index", "Home");
        }
      
    }
}
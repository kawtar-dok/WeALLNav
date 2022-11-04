using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using WeALLNav.Models;
using System.Web.Script.Serialization;

namespace WeALLNav.Controllers
{
    public class LoginController : Controller
    {
        private WeALLNEntities2 db = new WeALLNEntities2();

        // GET: Login
        public ActionResult loginView()
        {
            return View();
        }

        public String Login(string username, string password) { 

            Dictionary<string, string> userInfo = new Dictionary<string, string>(); 
            var admin = db.Login.Where(s => s.Username == "admin" && s.Password == "123").FirstOrDefault(); 
            var client = db.Client.Where(s => s.Username == username && s.Password == password).FirstOrDefault(); 
            var societe = db.Societe.Where(s => s.Username == username && s.Password == password).FirstOrDefault(); 
           
            if (admin != null) { 

                userInfo.Add("Username", admin.Username); 
                userInfo.Add("Password", admin.Password);
                userInfo.Add("role", "admin");
                var json = new JavaScriptSerializer().Serialize(userInfo.ToDictionary(item => item.Key.ToString(), item => item.Value.ToString())); 
                HttpContext.Session["user"] = "admin";

                
                return json;
               
            } 
            else if (client != null) { 

                userInfo.Add("Username", client.Username);
                userInfo.Add("Password", client.Password);
                userInfo.Add("id", client.No_Client.ToString());
                userInfo.Add("role", "client");
                var json = new JavaScriptSerializer().Serialize(userInfo.ToDictionary(item => item.Key.ToString(), item => item.Value.ToString()));
                HttpContext.Session["user"] = "client";

                return json; 
            }
            else if (societe != null) { 

                userInfo.Add("USsername", societe.Username); 
                userInfo.Add("Password", societe.Password);
                userInfo.Add("iD", societe.No_Ste.ToString());
                userInfo.Add("Nom", societe.Name_STE);
                userInfo.Add("RSole", "societe"); 
                var json = new JavaScriptSerializer().Serialize(userInfo.ToDictionary(item => item.Key.ToString(), item => item.Value.ToString()));
                HttpContext.Session["user"] = "societe";
               
                return json;
            } 
            else {
                return "error"; 
            }
        }
    }
}


/*
public ActionResult login(string Username, string Password)
{

    var existe = db.Client.Where(s => s.Username == Username && s.Password == Password).FirstOrDefault();

    // traitement 
    if (existe != null)
    {
        Session["Client"] = existe;
        Session["User"] = existe.First_Name.ToString();
        return RedirectToAction("Index", "HomeClient");
    }

    ViewBag.erreur = "The Username or Password Incorrect !!";
    return RedirectToAction("Index", "Home");
}

 public ActionResult login(Client objchk) 
        {

            if (ModelState.IsValid)
            {
                var existe = db.Client.Where(s => s.Username.Equals(objchk.Username) && s.Password.Equals(objchk.Password)).FirstOrDefault();

                // traitement 
                if (existe != null)
                {
                    Session["Client"] = existe;
                    Session["UserName"] = existe.First_Name.ToString();
                    return RedirectToAction("Index", "HomeClient");
                }
                else
                {
                    ModelState.AddModelError("", "The Username or Password Incorrect !!");
                   
                }
            }
            return RedirectToAction("Index", "Home");
        }

*/
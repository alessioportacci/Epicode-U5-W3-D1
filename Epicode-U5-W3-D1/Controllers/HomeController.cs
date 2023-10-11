using Epicode_U5_W3_D1.Models;
using Epicode_U5_W3_D1.Models.Db_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;

namespace Epicode_U5_W3_D1.Controllers
{
    public class HomeController : Controller
    {
        ModelDbContext db = new ModelDbContext();


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Username,Password")] T_Utenti utente) 
        {
            T_Utenti Utente = db.T_Utenti.Where(u => u.Username == utente.Username && u.Password == utente.Password).FirstOrDefault();
            if (Utente != null)
            {
                Session["IdUtente"] = Utente.Id;
                FormsAuthentication.SetAuthCookie(utente.Username, true);
                return RedirectToAction("Index");
            }

            return View(); 
        }


        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Exclude = "Ruolo")] T_Utenti utente)
        {
            if(ModelState.IsValid)
            {
                utente.Ruolo = "user";
                db.T_Utenti.Add(utente);
                db.SaveChanges();

                Session["IdUtente"] = utente.Id;
                FormsAuthentication.SetAuthCookie(utente.Username, true);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

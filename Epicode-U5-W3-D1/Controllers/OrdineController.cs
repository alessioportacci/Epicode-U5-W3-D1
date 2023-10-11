using Epicode_U5_W3_D1.Models;
using Epicode_U5_W3_D1.Models.Db_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epicode_U5_W3_D1.Controllers
{
    [Authorize]
    public class OrdineController : Controller
    {

        ModelDbContext db = new ModelDbContext();


        public ActionResult Index()
        {
            int id = Int32.Parse(Session["IdUtente"].ToString());

            if (User.IsInRole("admin"))
                return View(db.T_Ordine.ToList());

            return View(db.T_Ordine.Where(o => o.FkUtente == id && o.Evaso == false).ToList());
        }

        public ActionResult confermaOrdine()
        {
            int id = Int32.Parse(Session["IdUtente"].ToString());
            List<T_Ordine> Ordini = db.T_Ordine.Where(o => o.FkUtente == id && o.Evaso == false).ToList();

            foreach (T_Ordine ordine in Ordini)
            {
                ordine.Confermato = true;
                db.Entry(ordine).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit([Bind(Include = "Note,Indirizzo,FkProdotto,Quantita")] T_Ordine ordine)
        {
            return View(db.T_Ordine.Find(ordine.Id));
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            db.T_Ordine.Remove(db.T_Ordine.Find(id));
            db.SaveChanges();
            return View("Index");
        }

    }
}

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


        public JsonResult getOrdini(DateTime? Data)
        {            
            //Se è admin faccio il filtro sulla data (se disponibile)
            if (User.IsInRole("admin"))
                if(Data.HasValue)
                    return Json(db.T_Ordine.Where(o => o.DataArrivo == Data).ToList(), 
                                    JsonRequestBehavior.AllowGet);
                else
                    return Json(db.T_Ordine.ToList(), 
                                    JsonRequestBehavior.AllowGet);

            //Altrimenti passo i dati dell'utente normale
            int id = Int32.Parse(Session["IdUtente"].ToString());

            return Json(db.T_Ordine.Where(o => o.FkUtente == id && o.Evaso == false).ToList(), 
                            JsonRequestBehavior.AllowGet);
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

        public ActionResult evadiOrdine(int id)
        {
            T_Ordine ordine = db.T_Ordine.Find(id);
            ordine.Evaso = true;
            db.Entry(ordine).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(db.T_Ordine.Find(id));
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Note,Indirizzo,Quantita")] T_Ordine ordine)
        {
            T_Ordine Ordine = db.T_Ordine.Find(ordine.Id);

            Ordine.Note = ordine.Note;
            Ordine.Indirizzo = ordine.Indirizzo;
            Ordine.Quantita = ordine.Quantita;

            db.Entry(Ordine).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            db.T_Ordine.Remove(db.T_Ordine.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

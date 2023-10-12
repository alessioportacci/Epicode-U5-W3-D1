using Epicode_U5_W3_D1.Models.Db_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epicode_U5_W3_D1.Controllers
{
    public class UtentiController : Controller
    {
        ModelDbContext db = new ModelDbContext();


        public ActionResult Index()
        {
            return View(db.T_Utenti.ToList());
        }


        public ActionResult Details(int id)
        {
            return View(db.T_Utenti.Find(id));
        }


        public ActionResult Edit(int id)
        {
            return View(db.T_Utenti.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(T_Utenti utente)
        {
            db.Entry(utente).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            T_Utenti utente = db.T_Utenti.Find(id);
            List<T_Ordine> Ordini = db.T_Ordine.Where(o => o.FkUtente == id).ToList();
            /*List<T_OrdineProdotto> OrdineProdotto = new List<T_OrdineProdotto>();

            //Cancello gli ordini
            foreach (T_Ordine ordine in Ordini)
            {
                //Prima trovo tutte le pizze di un prodotto e le cancello
                OrdineProdotto = db.T_OrdineProdotto.Where(op => op.FkOrdine == ordine.Id).ToList();
                foreach(T_OrdineProdotto proddotto in OrdineProdotto)
                    db.T_OrdineProdotto.Remove(proddotto);
                //Cancello l'ordine in se
                db.T_Ordine.Remove(ordine);
            }
            */

            //Cancello l'utente
            db.T_Utenti.Remove(utente);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

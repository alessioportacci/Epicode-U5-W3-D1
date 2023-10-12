using Epicode_U5_W3_D1.Models;
using Epicode_U5_W3_D1.Models.Db_Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Epicode_U5_W3_D1.Controllers
{
    [Authorize]
    public class ProdottoController : Controller
    {

        ModelDbContext db = new ModelDbContext();


        public ActionResult Index()
        {
            return View(db.T_Prodotto.ToList());
        }


        public ActionResult Details(int id)
        {
            return View(db.T_Prodotto.Find(id));
        }

        [Authorize]
        [HttpPost]
        public ActionResult Details([Bind(Include = "Note,Indirizzo,FkProdotto,Quantita")]T_Ordine ordine)
        {

            ordine.DataOrdine = DateTime.Now;
            ordine.DataArrivo = DateTime.Now.AddHours(1);
            ordine.FkUtente = Int32.Parse(Session["IdUtente"].ToString());

            db.T_Ordine.Add(ordine);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(T_Prodotto prodotto)
        {
            if (prodotto.Immagine != null)
            {
                prodotto.Img = prodotto.Immagine.FileName;
                var path = Path.Combine(Server.MapPath("~/Content/Img/"), prodotto.Immagine.FileName);
                prodotto.Immagine.SaveAs(Path.Combine("~/Content/Img/", path));
            }

            db.T_Prodotto.Add(prodotto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            return View(db.T_Prodotto.Find(id));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(T_Prodotto prodotto)
        {
            if(prodotto.Immagine != null)
            {
                prodotto.Img = prodotto.Immagine.FileName;
                var path = Path.Combine(Server.MapPath("~/Content/Img/"), prodotto.Immagine.FileName);
                prodotto.Immagine.SaveAs(Path.Combine("~/Content/Img/", path));
            }

            db.Entry(prodotto).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        /*
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            T_Prodotto prodotto = db.T_Prodotto.Find(id);

            //Elimino prima il prodotto da tutti gli ordini
            List<T_OrdineProdotto> Ordini = db.T_OrdineProdotto.Where(op => op.T_Prodotto.Id == id).ToList();
            foreach(T_OrdineProdotto ordine in  Ordini)
                db.T_OrdineProdotto.Remove(ordine);

            //Ora posso eliminare il prodotto
            db.T_Prodotto.Remove(prodotto);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
    }
}

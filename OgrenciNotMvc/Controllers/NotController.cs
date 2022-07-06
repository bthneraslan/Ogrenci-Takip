using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.Entity;
using OgrenciNotMvc.Models;
namespace OgrenciNotMvc.Controllers
{
    public class NotController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Not
        public ActionResult Index()
        {
            var not = db.TBLNOTLAR.ToList();
            return View(not);
        }

        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR p)
        {
            db.TBLNOTLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotGetir(int id)
        {
            var not = db.TBLNOTLAR.Find(id);
            return View("NotGetir", not);
        }

        [HttpPost]
        public ActionResult NotGetir(Class1 model,TBLNOTLAR p, int SINAV1=0, int SINAV2=0, int SINAV3=0, int PROJE=0)
        {
            if (model.islem1 == "HESAPLA")
            {
                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort1 = ORTALAMA;
                if (ViewBag.ort1 <= 50)
                {
                    ViewBag.durum = false;
                }
                else
                {
                    ViewBag.durum = true;
                }
            }
            if (model.islem1 == "NOTGUNCELLE")
            {
                var snv = db.TBLNOTLAR.Find(p.NOTID);
                snv.SINAV1 = p.SINAV1;
                snv.SINAV2 = p.SINAV2;
                snv.SINAV3 = p.SINAV3;
                snv.PROJE = p.PROJE;
                snv.ORTALAMA = p.ORTALAMA;
                snv.DURUM = p.DURUM;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
       
    }
}
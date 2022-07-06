using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.Entity;
namespace OgrenciNotMvc.Controllers
{
    public class OgrenciController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Ogrenci
        public ActionResult Index()
        {
            var ogr = db.TBLOGRENCILER.ToList();
            return View(ogr);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER p)
        {

            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == p.TBLKULUPLER.KULUPID).FirstOrDefault();
            p.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci2 = db.TBLOGRENCILER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("OgrenciGetir", ogrenci2);
        }

        public ActionResult Guncelle(TBLOGRENCILER p)
        {
            var ogr = db.TBLOGRENCILER.Find(p.OGRENCIID);
            ogr.OGRAD = p.OGRAD;
            ogr.OGRSOYAD = p.OGRSOYAD;
            ogr.OGRFOTO = p.OGRFOTO;
            ogr.OGRCINSIYET = p.OGRCINSIYET;
            var klp2 = db.TBLKULUPLER.Where(x => x.KULUPID == p.TBLKULUPLER.KULUPID).FirstOrDefault();
            ogr.OGRKULUP = klp2.KULUPID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}
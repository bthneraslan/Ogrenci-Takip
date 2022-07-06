using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.Entity;
namespace OgrenciNotMvc.Controllers
{
    public class DefaultController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Default
        public ActionResult Index()
        {
            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER p)
        {
            db.TBLDERSLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var dersler = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(dersler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DersGetir(int id)
        {
            var dersler2 = db.TBLDERSLER.Find(id);
            return View("DersGetir",dersler2);
        }

        public ActionResult Guncelle(TBLDERSLER p)
        {
            var drs = db.TBLDERSLER.Find(p.DERSID);
            drs.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
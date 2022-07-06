using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.Entity;
namespace OgrenciNotMvc.Controllers
{
    public class KulupController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Kulup
        public ActionResult Index()
        {
            var kulup = db.TBLKULUPLER.ToList();
            return View(kulup);
        }
        [HttpGet]
        public ActionResult KulupEkle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult KulupEkle(TBLKULUPLER p)
        {
            db.TBLKULUPLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            var kulupler = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulupler);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KulupGetir(int id)

        {
            var kulup2 = db.TBLKULUPLER.Find(id);
            return View("KulupGetir",kulup2);
        }

        public ActionResult Guncelle(TBLKULUPLER p)
        {
            var klp = db.TBLKULUPLER.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
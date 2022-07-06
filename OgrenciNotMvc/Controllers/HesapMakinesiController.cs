using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class HesapMakinesiController : Controller
    {
        // GET: HesapMakinesi
        public ActionResult Index(double sayi1=0,double sayi2=0)
        {
            double toplama = sayi1 + sayi2;
            double cikarma = sayi1 - sayi2;
            double carpma = sayi1 * sayi2;
            double bolme = sayi1 / sayi2;
            ViewBag.topla = toplama;
            ViewBag.cikar = cikarma;
            ViewBag.carpma = carpma;
            ViewBag.bol = bolme;
            if (sayi2 == 0 || sayi2 == 0)
            {
                
                ViewBag.bol = 0;
            }

            return View();
        }
    }
}
using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db=new MvcDbStokEntities();
        public ActionResult MusteriListesi(string p)
        {
            var degerler = from d in db.TBLMUSTERILER select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLMUSTERILER.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIl(int id)
        {
            var deger = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("MusteriListesi");
        }
        public ActionResult MusteriGetir(int id)
        {
            var deger = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir",deger);
        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var mus = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            mus.MUSTERIAD=p1.MUSTERIAD;
            mus.MUSTERISOYAD=p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("MusteriListesi");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    [Authorize(Roles = "A")]
    public class DepartmanController : Controller
    {

        Context c = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var degerler = c.Departmens.Where(x => x.Durum==true).ToList();
            return View(degerler);
        }


        
        [HttpGet]
        public ActionResult DepartmanEkle( )
        {

            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmens.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmens.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmens.Find(id);
            return View("DepartmanGetir",dpt);

        }

        public ActionResult DepartmanGuncelle(Departman p)
        {
            var dept = c.Departmens.Find(p.DepartmanId);
            dept.DepartmanAd = p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmens.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);

        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var per = c.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);

        }


    }
}
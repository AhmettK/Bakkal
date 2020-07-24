using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakkal.Models;

namespace Bakkal.Controllers
{
    public class BakkalSiparisController : Controller
    {
        Model1 db = new Model1();
        // GET: BakkalSiparis
        public ActionResult Index()
        {
            string a = Session["userid"].ToString();
            int b = Convert.ToInt16(a);
            return View(db.Siparis.Where(x => x.Bakkal_Id == b && x.Kod == 1).ToList());
        }
        public ActionResult Getir(int id)
        {
            double y = db.Yeni.Where(x => x.SiparisId == id).Sum(x => x.UrunFiyati);
            ViewBag.tutar = y;

            string a = Session["userid"].ToString();
            int b = Convert.ToInt16(a);

            var sipucret = db.Bakkallar.Where(x => x.Bakkal_Id == b).Select(x => x.SiparisUcreti).FirstOrDefault();
            ViewBag.uc = sipucret;
            ViewBag.top = y + sipucret;
            ViewBag.his = id;
            return View(db.Yeni.Where(x => x.SiparisId == id).ToList());
        }

        public ActionResult History(int id)
        {
            var iki = db.Siparis.Find(id);
            iki.Kod = 2;
            db.SaveChanges();
            return RedirectToAction("Index", "BakkalSiparis");
        }

        public ActionResult Reddet(int id)
        {
            var eksi = db.Siparis.Find(id);
            eksi.Kod = -1;
            db.SaveChanges();
            return RedirectToAction("Index", "BakkalSiparis");
        }

        public ActionResult About()
        {
            string a = Session["userid"].ToString();
            int b = Convert.ToInt16(a);
            return View(db.Siparis.Where(x => x.Bakkal_Id == b && (x.Kod == 2 || x.Kod == -1)).ToList());
        }
        public ActionResult Details(int id)
        {
            double y = db.Yeni.Where(x => x.SiparisId == id).Sum(x => x.UrunFiyati);
            ViewBag.tutar = y;

            string a = Session["userid"].ToString();
            int b = Convert.ToInt16(a);

            var sipucret = db.Bakkallar.Where(x => x.Bakkal_Id == b).Select(x => x.SiparisUcreti).FirstOrDefault();
            ViewBag.uc = sipucret;
            ViewBag.top = y + sipucret;
            
            return View(db.Yeni.Where(x => x.SiparisId == id).ToList());
        }
    }
}
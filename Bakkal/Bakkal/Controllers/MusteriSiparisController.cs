using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakkal.Models;

namespace Bakkal.Controllers
{
    public class MusteriSiparisController : Controller
    {
        Model1 db = new Model1();
        // GET: MusteriSiparis
        public ActionResult Index()
        {
            string a = Session["userid"].ToString();
            int b = Convert.ToInt16(a);
            return View(db.Siparis.Where(x => x.MusteriId == b && x.Kod==1).ToList());
        }
        public ActionResult Getir(int id)
        {
            return View(db.Yeni.Where(x => x.SiparisId == id).ToList());
        }

        public ActionResult About()
        {
            string a = Session["userid"].ToString();
            int b = Convert.ToInt16(a);
            return View(db.Siparis.Where(x => x.MusteriId == b && x.Kod == 2).ToList());
        }
        public ActionResult Details(int id)
        {
            return View(db.Yeni.Where(x => x.SiparisId == id).ToList());
        }
    }
}
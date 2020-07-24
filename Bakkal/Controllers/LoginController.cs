using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Bakkal.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        Model1 db = new Model1();
        Login logi = new Login();
        Bakkallar bak = new Bakkallar();
        Musteri mus = new Musteri();


        // GET: Login
        public ActionResult Index(Login log)
        {
            if (log.Tip == 1)
            {
                var user = db.Bakkallar
                .Where(i => i.BakkalAdi == log.KullaniciAdi && i.BakkalSifresi == log.Sifre)
                .SingleOrDefault();

                if (user != null)
                {

                    FormsAuthentication.SetAuthCookie(user.BakkalAdi, false);
                    Session["userid"] = user.Bakkal_Id;
                    Session["useradi"] = user.BakkalAdi;
                    Session["usersifre"] = user.BakkalSifresi;
                    Session["userucret"] = user.SiparisUcreti;
                    return RedirectToAction("Index", "BakkalHome/Index");
                }
                else
                {
                    ViewBag.fail = true;
                    return View();
                }
            }
            else if (log.Tip == 2)
            {
                var user = db.Musteri
                .Where(i => i.KullaniciAdi == log.KullaniciAdi && i.Sifre == log.Sifre)
                .SingleOrDefault();

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.KullaniciAdi, false);
                    Session["userid"] = user.MusteriId;
                    Session["useradi"] = user.KullaniciAdi;
                    Session["usersifre"] = user.Sifre;
                    Session["useradres"] = user.Adres;
                    Session["usertel"] = user.Telefon;
                    return RedirectToAction("Index", "MusteriHome/Index");
                }
                else
                {
                    ViewBag.fail = true;
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}
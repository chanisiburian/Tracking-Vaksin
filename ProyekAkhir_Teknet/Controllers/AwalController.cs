using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyekAkhir_Teknet.Controllers
{
    public class AwalController : Controller
    {
        // GET: Awal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginRumahSakit()
        {
            return RedirectToAction("Login", "LoginRumahSakit");
        }
        public ActionResult Pasien()
        {
            return RedirectToAction("Login", "Akun");
        }
        public ActionResult LoginBPOM()
        {
            return RedirectToAction("Login", "LoginBPOM");
        }
    }
}
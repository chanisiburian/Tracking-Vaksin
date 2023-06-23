using ProyekAkhir_Teknet.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyekAkhir_Teknet.Controllers
{
    public class LoginRumahSakitController : Controller
    {

        private Vaksin_TeknetEntities7 db = new Vaksin_TeknetEntities7();
        private Vaksin_TeknetEntities14 db2 = new Vaksin_TeknetEntities14();

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: LoginRumahSakit
        public ActionResult Login()
        {
            return View();
        }


        void ConnectionString()
        {
            con.ConnectionString = "data source=LAPTOP-UU81J926/User; database=Vaksin_Teknet; integrated security = SSPI;";
        }
        [HttpPost]
        public ActionResult Verify(LoginRumahSakit lrs)
        {

            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM LoginRumahSakit WHERE username='" + lrs.username + "' AND password ='" + lrs.password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Dashboard");
            }
            else
            {
                con.Close();

                return View("Error");
            }
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult LihatGejala()
        {
            return RedirectToAction("Index", "LaporanPasien2");
        }
        public ActionResult LihatPendaftar()
        {
            return RedirectToAction("Index", "RegisterVaksin2");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Awal");
        }
        public ActionResult LihatVaksin()
        {
            return RedirectToAction("Index", "TambahVaksins");
        }
    }
}
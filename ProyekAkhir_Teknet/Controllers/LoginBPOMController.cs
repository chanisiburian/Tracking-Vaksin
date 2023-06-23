using ProyekAkhir_Teknet.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyekAkhir_Teknet.Controllers
{
    public class LoginBPOMController : Controller
    {

        private Vaksin_TeknetEntities9 db = new Vaksin_TeknetEntities9();
        private Vaksin_TeknetEntities2 db2 = new Vaksin_TeknetEntities2();

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: LoginBPOM
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View("Dashboard");
        }
        void ConnectionString()
        {
            con.ConnectionString = "data source=LAPTOP-UU81J926/User; database=Vaksin_Teknet; integrated security = SSPI;";
        }
        [HttpPost]
        public ActionResult Verify(LoginBPOM lbpom)
        {

            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM LoginBPOM WHERE username='" + lbpom.username + "' AND password ='" + lbpom.password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Dashboard");
            }
            else
            {
                con.Close();

                return RedirectToAction("Error","Akun");
            }
        }


        public ActionResult LihatGejala()
        {
            return View(db2.LaporanPasien.ToList());
        }
        public ActionResult TambahVaksin()
        {
            return RedirectToAction("Create", "TambahVaksins");
        }
        public ActionResult LihatVaksin()
        {
            return RedirectToAction("Index", "TambahVaksins");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Awal");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyekAkhir_Teknet;
using ProyekAkhir_Teknet.Models;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Net;

namespace ProyekAkhir_Teknet.Controllers
{
    public class AkunController : Controller
    {
        private VaksinModel db = new VaksinModel();
        private Vaksin_TeknetEntities12 db2 = new Vaksin_TeknetEntities12();

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Akun
        [HttpGet]
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
        public ActionResult Verify(Pasien pasien)
        {

            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Pasien WHERE username='" + pasien.Username + "' AND password ='" + pasien.Password + "'";
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

        public ActionResult lihatVaksin()
        {
            return View(db2.TambahVaksin.ToList());
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterPasien(Register registerDetails)
        {
            if (ModelState.IsValid)
            {
                using (var databaseContext = new Vaksin_TeknetEntities())
                {



                    Pasien reglog = new Pasien();

                    reglog.Pasien_ID = registerDetails.Pasien_ID;
                    reglog.Nama_Pasien = registerDetails.Nama_Pasien;
                    reglog.No_Hp = registerDetails.No_Hp;
                    reglog.Alamat = registerDetails.Alamat;
                    reglog.Username = registerDetails.Username;
                    reglog.Gejala_Pasien = registerDetails.Gejala_Pasien;
                    reglog.Password = registerDetails.Password;

                    databaseContext.Pasiens.Add(reglog);

                    databaseContext.SaveChanges();

                }

                ViewBag.Message = "User Details Saved";
                return View("Login");
            }
            else
            {

                return View("Register", registerDetails);
            }
        }

        public ActionResult RegisterVaksin()
        {
            return RedirectToAction("Create","RegisterVaksin2");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Awal");
        }

        /* [ValidateAntiForgeryToken]
         public ActionResult RegisterVaksinMethod([Bind(Include = "Nama, Alamat, JenisKelamin, NoHp")] RegisterVaksin registerVaksin)
         {
             if (ModelState.IsValid)
             {

                 db.RegisterVaksin.Add(registerVaksin);
                 db.SaveChanges();
                 return RedirectToAction("Dashboard");
             }

             return View(registerVaksin);
         }*/

        /*[HttpPost]
        public ActionResult RegisterVaksinMethod(RegisterVaksin registerVaksinDetails)
        {
            if (ModelState.IsValid)
            {
                using (var databaseContext2 = new Vaksin_TeknetEntities5())
                {



                    RegisterVaksin reglog = new RegisterVaksin();

                    reglog.Nama = registerVaksinDetails.Nama;
                    reglog.Alamat = registerVaksinDetails.Alamat;
                    reglog.JenisKelamin = registerVaksinDetails.JenisKelamin;
                    reglog.NoHp = registerVaksinDetails.NoHp;


                    databaseContext2.RegisterVaksins.Add(reglog);
                    databaseContext2.SaveChanges();

                }

                ViewBag.Message = "Register Vaksin Details Saved";
                return View("Dashboard");
            }
            else
            {

                return View("RegisterVaksin", registerVaksinDetails);
            }



        }*/
    }
}

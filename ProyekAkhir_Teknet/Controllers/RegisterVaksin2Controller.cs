using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyekAkhir_Teknet.Models;

namespace ProyekAkhir_Teknet.Controllers
{
    public class RegisterVaksin2Controller : Controller
    {
        private Vaksin_TeknetEntities14 db = new Vaksin_TeknetEntities14();

        // GET: RegisterVaksin2
        public ActionResult Index()
        {
            return View(db.RegisterVaksin2.ToList());
        }

        // GET: RegisterVaksin2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterVaksin2 registerVaksin2 = db.RegisterVaksin2.Find(id);
            if (registerVaksin2 == null)
            {
                return HttpNotFound();
            }
            return View(registerVaksin2);
        }

        // GET: RegisterVaksin2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterVaksin2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_daftar,nama,jenis_kelamin,no_hp,alamat")] RegisterVaksin2 registerVaksin2)
        {
            if (ModelState.IsValid)
            {
                db.RegisterVaksin2.Add(registerVaksin2);
                db.SaveChanges();
                return RedirectToAction("Dashboard", "Akun");
            }

            return View(registerVaksin2);
        }

        // GET: RegisterVaksin2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterVaksin2 registerVaksin2 = db.RegisterVaksin2.Find(id);
            if (registerVaksin2 == null)
            {
                return HttpNotFound();
            }
            return View(registerVaksin2);
        }

        // POST: RegisterVaksin2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_daftar,nama,jenis_kelamin,no_hp,alamat")] RegisterVaksin2 registerVaksin2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerVaksin2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerVaksin2);
        }

        // GET: RegisterVaksin2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterVaksin2 registerVaksin2 = db.RegisterVaksin2.Find(id);
            if (registerVaksin2 == null)
            {
                return HttpNotFound();
            }
            return View(registerVaksin2);
        }

        // POST: RegisterVaksin2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterVaksin2 registerVaksin2 = db.RegisterVaksin2.Find(id);
            db.RegisterVaksin2.Remove(registerVaksin2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

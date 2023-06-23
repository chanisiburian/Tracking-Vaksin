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
    public class RegisterVaksinsController : Controller
    {
        private Vaksin_TeknetEntities6 db = new Vaksin_TeknetEntities6();

        // GET: RegisterVaksins
        public ActionResult Index()
        {
            return View(db.RegisterVaksin.ToList());
        }

        // GET: RegisterVaksins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterVaksin registerVaksin = db.RegisterVaksin.Find(id);
            if (registerVaksin == null)
            {
                return HttpNotFound();
            }
            return View(registerVaksin);
        }

        // GET: RegisterVaksins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterVaksins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nama,Alamat,JenisKelamin,NoHp")] RegisterVaksin registerVaksin)
        {
            if (ModelState.IsValid)
            {
                db.RegisterVaksin.Add(registerVaksin);
                db.SaveChanges();
                return RedirectToAction("Dashboard", "Akun");
            }

            return View(registerVaksin);
        }

        // GET: RegisterVaksins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterVaksin registerVaksin = db.RegisterVaksin.Find(id);
            if (registerVaksin == null)
            {
                return HttpNotFound();
            }
            return View(registerVaksin);
        }

        // POST: RegisterVaksins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nama,Alamat,JenisKelamin,NoHp")] RegisterVaksin registerVaksin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerVaksin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerVaksin);
        }

        // GET: RegisterVaksins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterVaksin registerVaksin = db.RegisterVaksin.Find(id);
            if (registerVaksin == null)
            {
                return HttpNotFound();
            }
            return View(registerVaksin);
        }

        // POST: RegisterVaksins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RegisterVaksin registerVaksin = db.RegisterVaksin.Find(id);
            db.RegisterVaksin.Remove(registerVaksin);
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

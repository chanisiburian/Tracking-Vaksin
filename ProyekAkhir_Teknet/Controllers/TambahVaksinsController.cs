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
    public class TambahVaksinsController : Controller
    {
        private Vaksin_TeknetEntities12 db = new Vaksin_TeknetEntities12();

        // GET: TambahVaksins
        public ActionResult Index()
        {
            return View(db.TambahVaksin.ToList());
        }

        // GET: TambahVaksins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TambahVaksin tambahVaksin = db.TambahVaksin.Find(id);
            if (tambahVaksin == null)
            {
                return HttpNotFound();
            }
            return View(tambahVaksin);
        }

        // GET: TambahVaksins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TambahVaksins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "No_Vaksin,Jenis_Vaksin,Gejala_Yang_Cocok,Jumlah_Produksi")] TambahVaksin tambahVaksin)
        {
            if (ModelState.IsValid)
            {
                db.TambahVaksin.Add(tambahVaksin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tambahVaksin);
        }

        // GET: TambahVaksins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TambahVaksin tambahVaksin = db.TambahVaksin.Find(id);
            if (tambahVaksin == null)
            {
                return HttpNotFound();
            }
            return View(tambahVaksin);
        }

        // POST: TambahVaksins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "No_Vaksin,Jenis_Vaksin,Gejala_Yang_Cocok,Jumlah_Produksi")] TambahVaksin tambahVaksin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tambahVaksin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tambahVaksin);
        }

        // GET: TambahVaksins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TambahVaksin tambahVaksin = db.TambahVaksin.Find(id);
            if (tambahVaksin == null)
            {
                return HttpNotFound();
            }
            return View(tambahVaksin);
        }

        // POST: TambahVaksins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TambahVaksin tambahVaksin = db.TambahVaksin.Find(id);
            db.TambahVaksin.Remove(tambahVaksin);
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

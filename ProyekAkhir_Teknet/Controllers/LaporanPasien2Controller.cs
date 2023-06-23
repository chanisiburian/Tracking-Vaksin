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
    public class LaporanPasien2Controller : Controller
    {
        private Vaksin_TeknetEntities13 db = new Vaksin_TeknetEntities13();

        // GET: LaporanPasien2
        public ActionResult Index()
        {
            return View(db.LaporanPasien2.ToList());
        }

        // GET: LaporanPasien2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaporanPasien2 laporanPasien2 = db.LaporanPasien2.Find(id);
            if (laporanPasien2 == null)
            {
                return HttpNotFound();
            }
            return View(laporanPasien2);
        }

        // GET: LaporanPasien2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LaporanPasien2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_laporan,Gejala,Jumlah_Pasien,Deskripsi")] LaporanPasien2 laporanPasien2)
        {
            if (ModelState.IsValid)
            {
                db.LaporanPasien2.Add(laporanPasien2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(laporanPasien2);
        }

        // GET: LaporanPasien2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaporanPasien2 laporanPasien2 = db.LaporanPasien2.Find(id);
            if (laporanPasien2 == null)
            {
                return HttpNotFound();
            }
            return View(laporanPasien2);
        }

        // POST: LaporanPasien2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_laporan,Gejala,Jumlah_Pasien,Deskripsi")] LaporanPasien2 laporanPasien2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laporanPasien2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(laporanPasien2);
        }

        // GET: LaporanPasien2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaporanPasien2 laporanPasien2 = db.LaporanPasien2.Find(id);
            if (laporanPasien2 == null)
            {
                return HttpNotFound();
            }
            return View(laporanPasien2);
        }

        // POST: LaporanPasien2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LaporanPasien2 laporanPasien2 = db.LaporanPasien2.Find(id);
            db.LaporanPasien2.Remove(laporanPasien2);
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

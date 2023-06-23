using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyekAkhir_Teknet;

namespace ProyekAkhir_Teknet.Controllers
{
    public class LaporanPasiensController : Controller
    {
        private Vaksin_TeknetEntities2 db = new Vaksin_TeknetEntities2();

        // GET: LaporanPasiens
        public ActionResult Index()
        {
            return View(db.LaporanPasien.ToList());
        }

        // GET: LaporanPasiens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaporanPasien laporanPasien = db.LaporanPasien.Find(id);
            if (laporanPasien == null)
            {
                return HttpNotFound();
            }
            return View(laporanPasien);
        }

        // GET: LaporanPasiens/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Deskripsi_Laporan,Gejala_Pasien,Jumlah_Pasien")] LaporanPasien laporanPasien)
        {
            if (ModelState.IsValid)
            {
                db.LaporanPasien.Add(laporanPasien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(laporanPasien);
        }

        // GET: LaporanPasiens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaporanPasien laporanPasien = db.LaporanPasien.Find(id);
            if (laporanPasien == null)
            {
                return HttpNotFound();
            }
            return View(laporanPasien);
        }

        // POST: LaporanPasiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Deskripsi_Laporan,Gejala_Pasien,Jumlah_Pasien")] LaporanPasien laporanPasien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laporanPasien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(laporanPasien);
        }

        // GET: LaporanPasiens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaporanPasien laporanPasien = db.LaporanPasien.Find(id);
            if (laporanPasien == null)
            {
                return HttpNotFound();
            }
            return View(laporanPasien);
        }

        // POST: LaporanPasiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LaporanPasien laporanPasien = db.LaporanPasien.Find(id);
            db.LaporanPasien.Remove(laporanPasien);
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

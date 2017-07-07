using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuperGes.Models;

namespace SuperGes.Controllers
{
    public class RegiaoEnviosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegiaoEnvios
        public ActionResult Index()
        {
            return View(db.RegiaoEnvio.ToList());
        }

        // GET: RegiaoEnvios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegiaoEnvio regiaoEnvio = db.RegiaoEnvio.Find(id);
            if (regiaoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(regiaoEnvio);
        }

        // GET: RegiaoEnvios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegiaoEnvios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDRegiaoEnvio,NomeRegiao")] RegiaoEnvio regiaoEnvio)
        {
            if (ModelState.IsValid)
            {
                db.RegiaoEnvio.Add(regiaoEnvio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(regiaoEnvio);
        }

        // GET: RegiaoEnvios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegiaoEnvio regiaoEnvio = db.RegiaoEnvio.Find(id);
            if (regiaoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(regiaoEnvio);
        }

        // POST: RegiaoEnvios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDRegiaoEnvio,NomeRegiao")] RegiaoEnvio regiaoEnvio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regiaoEnvio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(regiaoEnvio);
        }

        // GET: RegiaoEnvios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegiaoEnvio regiaoEnvio = db.RegiaoEnvio.Find(id);
            if (regiaoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(regiaoEnvio);
        }

        // POST: RegiaoEnvios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegiaoEnvio regiaoEnvio = db.RegiaoEnvio.Find(id);
            db.RegiaoEnvio.Remove(regiaoEnvio);
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

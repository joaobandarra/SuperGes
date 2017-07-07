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
    public class TiposEnviosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TiposEnvios
        public ActionResult Index()
        {
            return View(db.TiposEnvio.ToList());
        }

        // GET: TiposEnvios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposEnvio tiposEnvio = db.TiposEnvio.Find(id);
            if (tiposEnvio == null)
            {
                return HttpNotFound();
            }
            return View(tiposEnvio);
        }

        // GET: TiposEnvios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposEnvios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TipoEnvio")] TiposEnvio tiposEnvio)
        {
            if (ModelState.IsValid)
            {
                db.TiposEnvio.Add(tiposEnvio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposEnvio);
        }

        // GET: TiposEnvios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposEnvio tiposEnvio = db.TiposEnvio.Find(id);
            if (tiposEnvio == null)
            {
                return HttpNotFound();
            }
            return View(tiposEnvio);
        }

        // POST: TiposEnvios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TipoEnvio")] TiposEnvio tiposEnvio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposEnvio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposEnvio);
        }

        // GET: TiposEnvios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposEnvio tiposEnvio = db.TiposEnvio.Find(id);
            if (tiposEnvio == null)
            {
                return HttpNotFound();
            }
            return View(tiposEnvio);
        }

        // POST: TiposEnvios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TiposEnvio tiposEnvio = db.TiposEnvio.Find(id);
            db.TiposEnvio.Remove(tiposEnvio);
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

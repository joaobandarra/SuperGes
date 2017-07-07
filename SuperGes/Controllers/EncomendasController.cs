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
    public class EncomendasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Encomendas
        public ActionResult Index()
        {
            var encomendas = db.Encomendas.Include(e => e.Cliente).Include(e => e.RegiaoEnvio).Include(e => e.TiposEnvio);
            return View(encomendas.ToList());
        }

        // GET: Encomendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            return View(encomenda);
        }

        // GET: Encomendas/Create
        public ActionResult Create()
        {
            ViewBag.IDClienteFK = new SelectList(db.Clientes, "IDCliente", "Nome");
            ViewBag.IDRegiaoEnvioFK = new SelectList(db.RegiaoEnvio, "IDRegiaoEnvio", "NomeRegiao");
            ViewBag.IDFK = new SelectList(db.TiposEnvio, "ID", "TipoEnvio");
            return View();
        }

        // POST: Encomendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDEncomenda,DataCriacaoEncomenda,DataEnvioEncomenda,EstadoCompra,CustoEnvio,MoradaFaturacao,CodPostalFaturacao,MoradaEntrega,CodigoPostalEntrega,IDClienteFK,IDFK,IDRegiaoEnvioFK")] Encomenda encomenda)
        {
            if (ModelState.IsValid)
            {
                db.Encomendas.Add(encomenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDClienteFK = new SelectList(db.Clientes, "IDCliente", "Nome", encomenda.IDClienteFK);
            ViewBag.IDRegiaoEnvioFK = new SelectList(db.RegiaoEnvio, "IDRegiaoEnvio", "NomeRegiao", encomenda.IDRegiaoEnvioFK);
            ViewBag.IDFK = new SelectList(db.TiposEnvio, "ID", "TipoEnvio", encomenda.IDFK);
            return View(encomenda);
        }

        // GET: Encomendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDClienteFK = new SelectList(db.Clientes, "IDCliente", "Nome", encomenda.IDClienteFK);
            ViewBag.IDRegiaoEnvioFK = new SelectList(db.RegiaoEnvio, "IDRegiaoEnvio", "NomeRegiao", encomenda.IDRegiaoEnvioFK);
            ViewBag.IDFK = new SelectList(db.TiposEnvio, "ID", "TipoEnvio", encomenda.IDFK);
            return View(encomenda);
        }

        // POST: Encomendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEncomenda,DataCriacaoEncomenda,DataEnvioEncomenda,EstadoCompra,CustoEnvio,MoradaFaturacao,CodPostalFaturacao,MoradaEntrega,CodigoPostalEntrega,IDClienteFK,IDFK,IDRegiaoEnvioFK")] Encomenda encomenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encomenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDClienteFK = new SelectList(db.Clientes, "IDCliente", "Nome", encomenda.IDClienteFK);
            ViewBag.IDRegiaoEnvioFK = new SelectList(db.RegiaoEnvio, "IDRegiaoEnvio", "NomeRegiao", encomenda.IDRegiaoEnvioFK);
            ViewBag.IDFK = new SelectList(db.TiposEnvio, "ID", "TipoEnvio", encomenda.IDFK);
            return View(encomenda);
        }

        // GET: Encomendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            return View(encomenda);
        }

        // POST: Encomendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encomenda encomenda = db.Encomendas.Find(id);
            db.Encomendas.Remove(encomenda);
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

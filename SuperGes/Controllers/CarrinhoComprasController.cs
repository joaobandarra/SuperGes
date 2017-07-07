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
    public class CarrinhoComprasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CarrinhoCompras
        public ActionResult Index()
        {
            var carrinhoCompras = db.CarrinhoCompras.Include(c => c.Cliente);
            return View(carrinhoCompras.ToList());
        }

        // GET: CarrinhoCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrinhoCompras carrinhoCompras = db.CarrinhoCompras.Find(id);
            if (carrinhoCompras == null)
            {
                return HttpNotFound();
            }
            return View(carrinhoCompras);
        }

        // GET: CarrinhoCompras/Create
        public ActionResult Create()
        {
            ViewBag.IDClienteFK = new SelectList(db.Clientes, "IDCliente", "Nome");
            return View();
        }

        // POST: CarrinhoCompras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCarrinhoCompras,DataAdicaoProduto,IDClienteFK")] CarrinhoCompras carrinhoCompras)
        {
            if (ModelState.IsValid)
            {
                db.CarrinhoCompras.Add(carrinhoCompras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDClienteFK = new SelectList(db.Clientes, "IDCliente", "Nome", carrinhoCompras.IDClienteFK);
            return View(carrinhoCompras);
        }

        // GET: CarrinhoCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrinhoCompras carrinhoCompras = db.CarrinhoCompras.Find(id);
            if (carrinhoCompras == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDClienteFK = new SelectList(db.Clientes, "IDCliente", "Nome", carrinhoCompras.IDClienteFK);
            return View(carrinhoCompras);
        }

        // POST: CarrinhoCompras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCarrinhoCompras,DataAdicaoProduto,IDClienteFK")] CarrinhoCompras carrinhoCompras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrinhoCompras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDClienteFK = new SelectList(db.Clientes, "IDCliente", "Nome", carrinhoCompras.IDClienteFK);
            return View(carrinhoCompras);
        }

        // GET: CarrinhoCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrinhoCompras carrinhoCompras = db.CarrinhoCompras.Find(id);
            if (carrinhoCompras == null)
            {
                return HttpNotFound();
            }
            return View(carrinhoCompras);
        }

        // POST: CarrinhoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarrinhoCompras carrinhoCompras = db.CarrinhoCompras.Find(id);
            db.CarrinhoCompras.Remove(carrinhoCompras);
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

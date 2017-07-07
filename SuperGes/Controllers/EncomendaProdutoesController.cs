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
    public class EncomendaProdutoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EncomendaProdutoes
        public ActionResult Index()
        {
            var encomendaProdutos = db.EncomendaProdutos.Include(e => e.Encomenda).Include(e => e.Produto);
            return View(encomendaProdutos.ToList());
        }

        // GET: EncomendaProdutoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncomendaProduto encomendaProduto = db.EncomendaProdutos.Find(id);
            if (encomendaProduto == null)
            {
                return HttpNotFound();
            }
            return View(encomendaProduto);
        }

        // GET: EncomendaProdutoes/Create
        public ActionResult Create()
        {
            ViewBag.IDEncomendaFK = new SelectList(db.Encomendas, "IDEncomenda", "EstadoCompra");
            ViewBag.IDProdutoFK = new SelectList(db.Produtos, "IDProduto", "Nome");
            return View();
        }

        // POST: EncomendaProdutoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDEncomendaProduto,NomeProduto,Quantidade,Preco,IVA,IDEncomendaFK,IDProdutoFK")] EncomendaProduto encomendaProduto)
        {
            if (ModelState.IsValid)
            {
                db.EncomendaProdutos.Add(encomendaProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEncomendaFK = new SelectList(db.Encomendas, "IDEncomenda", "EstadoCompra", encomendaProduto.IDEncomendaFK);
            ViewBag.IDProdutoFK = new SelectList(db.Produtos, "IDProduto", "Nome", encomendaProduto.IDProdutoFK);
            return View(encomendaProduto);
        }

        // GET: EncomendaProdutoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncomendaProduto encomendaProduto = db.EncomendaProdutos.Find(id);
            if (encomendaProduto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDEncomendaFK = new SelectList(db.Encomendas, "IDEncomenda", "EstadoCompra", encomendaProduto.IDEncomendaFK);
            ViewBag.IDProdutoFK = new SelectList(db.Produtos, "IDProduto", "Nome", encomendaProduto.IDProdutoFK);
            return View(encomendaProduto);
        }

        // POST: EncomendaProdutoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEncomendaProduto,NomeProduto,Quantidade,Preco,IVA,IDEncomendaFK,IDProdutoFK")] EncomendaProduto encomendaProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encomendaProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEncomendaFK = new SelectList(db.Encomendas, "IDEncomenda", "EstadoCompra", encomendaProduto.IDEncomendaFK);
            ViewBag.IDProdutoFK = new SelectList(db.Produtos, "IDProduto", "Nome", encomendaProduto.IDProdutoFK);
            return View(encomendaProduto);
        }

        // GET: EncomendaProdutoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncomendaProduto encomendaProduto = db.EncomendaProdutos.Find(id);
            if (encomendaProduto == null)
            {
                return HttpNotFound();
            }
            return View(encomendaProduto);
        }

        // POST: EncomendaProdutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EncomendaProduto encomendaProduto = db.EncomendaProdutos.Find(id);
            db.EncomendaProdutos.Remove(encomendaProduto);
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

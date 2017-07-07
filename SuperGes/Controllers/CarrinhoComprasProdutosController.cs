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
    public class CarrinhoComprasProdutosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CarrinhoComprasProdutos
        public ActionResult Index()
        {
            var carrinhoComprasProdutos = db.CarrinhoComprasProdutos.Include(c => c.CarrinhoCompras).Include(c => c.Produto);
            return View(carrinhoComprasProdutos.ToList());
        }

        // GET: CarrinhoComprasProdutos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrinhoComprasProdutos carrinhoComprasProdutos = db.CarrinhoComprasProdutos.Find(id);
            if (carrinhoComprasProdutos == null)
            {
                return HttpNotFound();
            }
            return View(carrinhoComprasProdutos);
        }

        // GET: CarrinhoComprasProdutos/Create
        public ActionResult Create()
        {
            ViewBag.IDCarrinhoComprasFK = new SelectList(db.CarrinhoCompras, "IDCarrinhoCompras", "IDCarrinhoCompras");
            ViewBag.IDProdutoFK = new SelectList(db.Produtos, "IDProduto", "Nome");
            return View();
        }

        // POST: CarrinhoComprasProdutos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDcomprasProduto,NomeProduto,Quantidade,Preco,IVA,IDCarrinhoComprasFK,IDProdutoFK")] CarrinhoComprasProdutos carrinhoComprasProdutos)
        {
            if (ModelState.IsValid)
            {
                db.CarrinhoComprasProdutos.Add(carrinhoComprasProdutos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCarrinhoComprasFK = new SelectList(db.CarrinhoCompras, "IDCarrinhoCompras", "IDCarrinhoCompras", carrinhoComprasProdutos.IDCarrinhoComprasFK);
            ViewBag.IDProdutoFK = new SelectList(db.Produtos, "IDProduto", "Nome", carrinhoComprasProdutos.IDProdutoFK);
            return View(carrinhoComprasProdutos);
        }

        // GET: CarrinhoComprasProdutos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrinhoComprasProdutos carrinhoComprasProdutos = db.CarrinhoComprasProdutos.Find(id);
            if (carrinhoComprasProdutos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCarrinhoComprasFK = new SelectList(db.CarrinhoCompras, "IDCarrinhoCompras", "IDCarrinhoCompras", carrinhoComprasProdutos.IDCarrinhoComprasFK);
            ViewBag.IDProdutoFK = new SelectList(db.Produtos, "IDProduto", "Nome", carrinhoComprasProdutos.IDProdutoFK);
            return View(carrinhoComprasProdutos);
        }

        // POST: CarrinhoComprasProdutos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDcomprasProduto,NomeProduto,Quantidade,Preco,IVA,IDCarrinhoComprasFK,IDProdutoFK")] CarrinhoComprasProdutos carrinhoComprasProdutos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrinhoComprasProdutos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCarrinhoComprasFK = new SelectList(db.CarrinhoCompras, "IDCarrinhoCompras", "IDCarrinhoCompras", carrinhoComprasProdutos.IDCarrinhoComprasFK);
            ViewBag.IDProdutoFK = new SelectList(db.Produtos, "IDProduto", "Nome", carrinhoComprasProdutos.IDProdutoFK);
            return View(carrinhoComprasProdutos);
        }

        // GET: CarrinhoComprasProdutos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrinhoComprasProdutos carrinhoComprasProdutos = db.CarrinhoComprasProdutos.Find(id);
            if (carrinhoComprasProdutos == null)
            {
                return HttpNotFound();
            }
            return View(carrinhoComprasProdutos);
        }

        // POST: CarrinhoComprasProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarrinhoComprasProdutos carrinhoComprasProdutos = db.CarrinhoComprasProdutos.Find(id);
            db.CarrinhoComprasProdutos.Remove(carrinhoComprasProdutos);
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

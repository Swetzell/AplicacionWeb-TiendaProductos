using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplicacionWeb;
using PagedList;

namespace AplicacionWeb.Controllers
{
    public class categoriaController : Controller
    {
        private bdalmaceneslibertad2Entities db = new bdalmaceneslibertad2Entities();

        //GET -> se utiliza para rutas y consultas(obtener informacion)
        // GET: Categoria -> Mostrar Categoria
        //public ActionResult Index()
        //{
        //    return View(db.categoria.ToList());
        //}

        public ActionResult Index(int? page)
        {
            //tamaño de la paginacion
            int pageSize = 10;
            //si no se especifica en que pagina comenzamos inicia en la primera
            int pageNumber = page ?? 1;
            //ordenamos por codigo
            var categorias = db.categoria.OrderBy(c => c.codcat);
            var pagedCategorias = categorias.ToPagedList(pageNumber, pageSize);
            return View(pagedCategorias);
        }

        // GET: Categoria/Details/5 -> Buscar Categoria
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categoria/Create ->Mostrar Registrar Categoria
        public ActionResult Create()
        {
            return View();
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        //HttpPost -> Acciones
        // POST: Categoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codcat,nomcat,estcat")] categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.categoria.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codcat,nomcat,estcat")] categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categoria categoria = db.categoria.Find(id);
            db.categoria.Remove(categoria);
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

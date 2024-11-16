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
    public class destinoController : Controller
    {
        private bdalmaceneslibertad2Entities db = new bdalmaceneslibertad2Entities();

        // GET: destino
        public ActionResult Index(int? page)
        {
            //tamaño de la paginacion
            int pageSize = 10;
            //si no se especifica en que pagina comenzamos inicia en la primera
            int pageNumber = page ?? 1;
            //ordenamos por codigo
            var Destino = db.destino.OrderBy(c => c.coddes);
            var pagedDestino = Destino.ToPagedList(pageNumber, pageSize);
            return View(pagedDestino);
        }

        // GET: destino/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            destino destino = db.destino.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // GET: destino/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: destino/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "coddes,nomdes,estdes")] destino destino)
        {
            if (ModelState.IsValid)
            {
                db.destino.Add(destino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destino);
        }

        // GET: destino/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            destino destino = db.destino.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // POST: destino/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "coddes,nomdes,estdes")] destino destino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destino);
        }

        // GET: destino/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            destino destino = db.destino.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // POST: destino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            destino destino = db.destino.Find(id);
            db.destino.Remove(destino);
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

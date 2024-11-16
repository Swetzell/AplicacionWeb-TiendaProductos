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
    public class distritoController : Controller
    {
        private bdalmaceneslibertad2Entities db = new bdalmaceneslibertad2Entities();

        // GET: distrito
        public ActionResult Index(int? page)
        {
            //tamaño de la paginacion
            int pageSize = 10;
            //si no se especifica en que pagina comenzamos inicia en la primera
            int pageNumber = page ?? 1;
            //ordenamos por codigo
            var distritos = db.distrito.OrderBy(c => c.coddis);
            var pagedDistritos = distritos.ToPagedList(pageNumber, pageSize);
            return View(pagedDistritos);
        }

        // GET: distrito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            distrito distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // GET: distrito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: distrito/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "coddis,nomdis,estdis")] distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.distrito.Add(distrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(distrito);
        }

        // GET: distrito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            distrito distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: distrito/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "coddis,nomdis,estdis")] distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distrito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distrito);
        }

        // GET: distrito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            distrito distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: distrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            distrito distrito = db.distrito.Find(id);
            db.distrito.Remove(distrito);
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

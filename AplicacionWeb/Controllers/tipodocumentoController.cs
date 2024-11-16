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
    public class tipodocumentoController : Controller
    {
        private bdalmaceneslibertad2Entities db = new bdalmaceneslibertad2Entities();

        // GET: tipodocumento
        public ActionResult Index(int? page)
        {
            //tamaño de la paginacion
            int pageSize = 10;
            //si no se especifica en que pagina comenzamos inicia en la primera
            int pageNumber = page ?? 1;
            //ordenamos por codigo
            var tipoDocumento = db.tipodocumento.OrderBy(c => c.codtipd);
            var pagedTipoDocumento = tipoDocumento.ToPagedList(pageNumber, pageSize);
            return View(pagedTipoDocumento);
        }

        // GET: tipodocumento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipodocumento tipodocumento = db.tipodocumento.Find(id);
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipodocumento);
        }

        // GET: tipodocumento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipodocumento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codtipd,nomtipd,esttipd")] tipodocumento tipodocumento)
        {
            if (ModelState.IsValid)
            {
                db.tipodocumento.Add(tipodocumento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipodocumento);
        }

        // GET: tipodocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipodocumento tipodocumento = db.tipodocumento.Find(id);
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipodocumento);
        }

        // POST: tipodocumento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codtipd,nomtipd,esttipd")] tipodocumento tipodocumento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipodocumento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipodocumento);
        }

        // GET: tipodocumento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipodocumento tipodocumento = db.tipodocumento.Find(id);
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipodocumento);
        }

        // POST: tipodocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipodocumento tipodocumento = db.tipodocumento.Find(id);
            db.tipodocumento.Remove(tipodocumento);
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

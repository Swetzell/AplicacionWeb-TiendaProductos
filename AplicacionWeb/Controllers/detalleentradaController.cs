using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplicacionWeb;

namespace AplicacionWeb.Controllers
{
    public class detalleentradaController : Controller
    {
        private bdalmaceneslibertad2Entities db = new bdalmaceneslibertad2Entities();

        // GET: detalleentrada
        public ActionResult Index()
        {
            var detalleentrada = db.detalleentrada.Include(d => d.producto).Include(d => d.registroentrada);
            return View(detalleentrada.ToList());
        }

        // GET: detalleentrada/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalleentrada detalleentrada = db.detalleentrada.Find(id);
            if (detalleentrada == null)
            {
                return HttpNotFound();
            }
            return View(detalleentrada);
        }

        // GET: detalleentrada/Create
        public ActionResult Create()
        {
            ViewBag.codpro = new SelectList(db.producto, "codpro", "nompro");
            ViewBag.nroent = new SelectList(db.registroentrada, "nroent", "nroent");
            return View();
        }

        // POST: detalleentrada/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nrodetent,canent,preent,nroent,codpro")] detalleentrada detalleentrada)
        {
            if (ModelState.IsValid)
            {
                db.detalleentrada.Add(detalleentrada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codpro = new SelectList(db.producto, "codpro", "nompro", detalleentrada.codpro);
            ViewBag.nroent = new SelectList(db.registroentrada, "nroent", "nroent", detalleentrada.nroent);
            return View(detalleentrada);
        }

        // GET: detalleentrada/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalleentrada detalleentrada = db.detalleentrada.Find(id);
            if (detalleentrada == null)
            {
                return HttpNotFound();
            }
            ViewBag.codpro = new SelectList(db.producto, "codpro", "nompro", detalleentrada.codpro);
            ViewBag.nroent = new SelectList(db.registroentrada, "nroent", "nroent", detalleentrada.nroent);
            return View(detalleentrada);
        }

        // POST: detalleentrada/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nrodetent,canent,preent,nroent,codpro")] detalleentrada detalleentrada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleentrada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codpro = new SelectList(db.producto, "codpro", "nompro", detalleentrada.codpro);
            ViewBag.nroent = new SelectList(db.registroentrada, "nroent", "nroent", detalleentrada.nroent);
            return View(detalleentrada);
        }

        // GET: detalleentrada/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalleentrada detalleentrada = db.detalleentrada.Find(id);
            if (detalleentrada == null)
            {
                return HttpNotFound();
            }
            return View(detalleentrada);
        }

        // POST: detalleentrada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalleentrada detalleentrada = db.detalleentrada.Find(id);
            db.detalleentrada.Remove(detalleentrada);
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

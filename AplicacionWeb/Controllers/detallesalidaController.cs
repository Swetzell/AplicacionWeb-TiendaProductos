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
    public class detallesalidaController : Controller
    {
        private bdalmaceneslibertad2Entities db = new bdalmaceneslibertad2Entities();

        // GET: detallesalida
        public ActionResult Index()
        {
            var detallesalida = db.detallesalida.Include(d => d.producto).Include(d => d.registrosalida);
            return View(detallesalida.ToList());
        }

        // GET: detallesalida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detallesalida detallesalida = db.detallesalida.Find(id);
            if (detallesalida == null)
            {
                return HttpNotFound();
            }
            return View(detallesalida);
        }

        // GET: detallesalida/Create
        public ActionResult Create()
        {
            ViewBag.codpro = new SelectList(db.producto, "codpro", "nompro");
            ViewBag.nrosal = new SelectList(db.registrosalida, "nrosal", "nrosal");
            return View();
        }

        // POST: detallesalida/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nrodetsal,canent,preent,nrosal,codpro")] detallesalida detallesalida)
        {
            if (ModelState.IsValid)
            {
                db.detallesalida.Add(detallesalida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codpro = new SelectList(db.producto, "codpro", "nompro", detallesalida.codpro);
            ViewBag.nrosal = new SelectList(db.registrosalida, "nrosal", "nrosal", detallesalida.nrosal);
            return View(detallesalida);
        }

        // GET: detallesalida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detallesalida detallesalida = db.detallesalida.Find(id);
            if (detallesalida == null)
            {
                return HttpNotFound();
            }
            ViewBag.codpro = new SelectList(db.producto, "codpro", "nompro", detallesalida.codpro);
            ViewBag.nrosal = new SelectList(db.registrosalida, "nrosal", "nrosal", detallesalida.nrosal);
            return View(detallesalida);
        }

        // POST: detallesalida/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nrodetsal,canent,preent,nrosal,codpro")] detallesalida detallesalida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detallesalida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codpro = new SelectList(db.producto, "codpro", "nompro", detallesalida.codpro);
            ViewBag.nrosal = new SelectList(db.registrosalida, "nrosal", "nrosal", detallesalida.nrosal);
            return View(detallesalida);
        }

        // GET: detallesalida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detallesalida detallesalida = db.detallesalida.Find(id);
            if (detallesalida == null)
            {
                return HttpNotFound();
            }
            return View(detallesalida);
        }

        // POST: detallesalida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detallesalida detallesalida = db.detallesalida.Find(id);
            db.detallesalida.Remove(detallesalida);
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

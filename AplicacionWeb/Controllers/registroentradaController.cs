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
    public class registroentradaController : Controller
    {
        private bdalmaceneslibertad2Entities db = new bdalmaceneslibertad2Entities();

        // GET: registroentrada
        public ActionResult Index()
        {
            var registroentrada = db.registroentrada.Include(r => r.empleado).Include(r => r.proveedor);
            return View(registroentrada.ToList());
        }

        // GET: registroentrada/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registroentrada registroentrada = db.registroentrada.Find(id);
            if (registroentrada == null)
            {
                return HttpNotFound();
            }
            return View(registroentrada);
        }

        // GET: registroentrada/Create
        public ActionResult Create()
        {
            ViewBag.codemp = new SelectList(db.empleado, "codemp", "nomemp");
            ViewBag.codprov = new SelectList(db.proveedor, "codprov", "nomprov");
            return View();
        }

        // POST: registroentrada/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nroent,fecent,codemp,codprov,estent")] registroentrada registroentrada)
        {
            if (ModelState.IsValid)
            {
                db.registroentrada.Add(registroentrada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codemp = new SelectList(db.empleado, "codemp", "nomemp", registroentrada.codemp);
            ViewBag.codprov = new SelectList(db.proveedor, "codprov", "nomprov", registroentrada.codprov);
            return View(registroentrada);
        }

        // GET: registroentrada/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registroentrada registroentrada = db.registroentrada.Find(id);
            if (registroentrada == null)
            {
                return HttpNotFound();
            }
            ViewBag.codemp = new SelectList(db.empleado, "codemp", "nomemp", registroentrada.codemp);
            ViewBag.codprov = new SelectList(db.proveedor, "codprov", "nomprov", registroentrada.codprov);
            return View(registroentrada);
        }

        // POST: registroentrada/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nroent,fecent,codemp,codprov,estent")] registroentrada registroentrada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroentrada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codemp = new SelectList(db.empleado, "codemp", "nomemp", registroentrada.codemp);
            ViewBag.codprov = new SelectList(db.proveedor, "codprov", "nomprov", registroentrada.codprov);
            return View(registroentrada);
        }

        // GET: registroentrada/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registroentrada registroentrada = db.registroentrada.Find(id);
            if (registroentrada == null)
            {
                return HttpNotFound();
            }
            return View(registroentrada);
        }

        // POST: registroentrada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registroentrada registroentrada = db.registroentrada.Find(id);
            db.registroentrada.Remove(registroentrada);
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

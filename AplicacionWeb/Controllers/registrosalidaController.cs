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
    public class registrosalidaController : Controller
    {
        private bdalmaceneslibertad2Entities db = new bdalmaceneslibertad2Entities();

        // GET: registrosalida
        public ActionResult Index()
        {
            var registrosalida = db.registrosalida.Include(r => r.destino).Include(r => r.empleado);
            return View(registrosalida.ToList());
        }

        // GET: registrosalida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registrosalida registrosalida = db.registrosalida.Find(id);
            if (registrosalida == null)
            {
                return HttpNotFound();
            }
            return View(registrosalida);
        }

        // GET: registrosalida/Create
        public ActionResult Create()
        {
            ViewBag.coddes = new SelectList(db.destino, "coddes", "nomdes");
            ViewBag.codemp = new SelectList(db.empleado, "codemp", "nomemp");
            return View();
        }

        // POST: registrosalida/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nrosal,fecent,codemp,coddes,estent")] registrosalida registrosalida)
        {
            if (ModelState.IsValid)
            {
                db.registrosalida.Add(registrosalida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.coddes = new SelectList(db.destino, "coddes", "nomdes", registrosalida.coddes);
            ViewBag.codemp = new SelectList(db.empleado, "codemp", "nomemp", registrosalida.codemp);
            return View(registrosalida);
        }

        // GET: registrosalida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registrosalida registrosalida = db.registrosalida.Find(id);
            if (registrosalida == null)
            {
                return HttpNotFound();
            }
            ViewBag.coddes = new SelectList(db.destino, "coddes", "nomdes", registrosalida.coddes);
            ViewBag.codemp = new SelectList(db.empleado, "codemp", "nomemp", registrosalida.codemp);
            return View(registrosalida);
        }

        // POST: registrosalida/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nrosal,fecent,codemp,coddes,estent")] registrosalida registrosalida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrosalida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.coddes = new SelectList(db.destino, "coddes", "nomdes", registrosalida.coddes);
            ViewBag.codemp = new SelectList(db.empleado, "codemp", "nomemp", registrosalida.codemp);
            return View(registrosalida);
        }

        // GET: registrosalida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registrosalida registrosalida = db.registrosalida.Find(id);
            if (registrosalida == null)
            {
                return HttpNotFound();
            }
            return View(registrosalida);
        }

        // POST: registrosalida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registrosalida registrosalida = db.registrosalida.Find(id);
            db.registrosalida.Remove(registrosalida);
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

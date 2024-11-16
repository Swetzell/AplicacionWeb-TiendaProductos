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
    public class empleadoController : Controller
    {
        private bdalmaceneslibertad2Entities db = new bdalmaceneslibertad2Entities();

        // GET: empleado
        public ActionResult Index()
        {
            var empleado = db.empleado.Include(e => e.distrito).Include(e => e.rol).Include(e => e.tipodocumento);
            return View(empleado.ToList());
        }

        // GET: empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: empleado/Create
        public ActionResult Create()
        {
            ViewBag.coddis = new SelectList(db.distrito, "coddis", "nomdis");
            ViewBag.codrol = new SelectList(db.rol, "codrol", "nomrol");
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codtipd", "nomtipd");
            return View();
        }

        // POST: empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codemp,nomemp,apepemp,apememp,docemp,diremp,telemp,celemp,coremp,estemp,coddis,codrol,codtipd")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.coddis = new SelectList(db.distrito, "coddis", "nomdis", empleado.coddis);
            ViewBag.codrol = new SelectList(db.rol, "codrol", "nomrol", empleado.codrol);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codtipd", "nomtipd", empleado.codtipd);
            return View(empleado);
        }

        // GET: empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.coddis = new SelectList(db.distrito, "coddis", "nomdis", empleado.coddis);
            ViewBag.codrol = new SelectList(db.rol, "codrol", "nomrol", empleado.codrol);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codtipd", "nomtipd", empleado.codtipd);
            return View(empleado);
        }

        // POST: empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codemp,nomemp,apepemp,apememp,docemp,diremp,telemp,celemp,coremp,estemp,coddis,codrol,codtipd")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.coddis = new SelectList(db.distrito, "coddis", "nomdis", empleado.coddis);
            ViewBag.codrol = new SelectList(db.rol, "codrol", "nomrol", empleado.codrol);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codtipd", "nomtipd", empleado.codtipd);
            return View(empleado);
        }

        // GET: empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            empleado empleado = db.empleado.Find(id);
            db.empleado.Remove(empleado);
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

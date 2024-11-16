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
    public class proveedorController : Controller
    {
        private bdalmaceneslibertad2Entities db = new bdalmaceneslibertad2Entities();

        // GET: proveedor
        public ActionResult Index()
        {
            var proveedor = db.proveedor.Include(p => p.distrito);
            return View(proveedor.ToList());
        }

        // GET: proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: proveedor/Create
        public ActionResult Create()
        {
            ViewBag.coddis = new SelectList(db.distrito, "coddis", "nomdis");
            return View();
        }

        // POST: proveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codprov,nomprov,repprov,dirprov,telprov,celprov,corprov,estprov,coddis")] proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.proveedor.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.coddis = new SelectList(db.distrito, "coddis", "nomdis", proveedor.coddis);
            return View(proveedor);
        }

        // GET: proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.coddis = new SelectList(db.distrito, "coddis", "nomdis", proveedor.coddis);
            return View(proveedor);
        }

        // POST: proveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codprov,nomprov,repprov,dirprov,telprov,celprov,corprov,estprov,coddis")] proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.coddis = new SelectList(db.distrito, "coddis", "nomdis", proveedor.coddis);
            return View(proveedor);
        }

        // GET: proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proveedor proveedor = db.proveedor.Find(id);
            db.proveedor.Remove(proveedor);
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

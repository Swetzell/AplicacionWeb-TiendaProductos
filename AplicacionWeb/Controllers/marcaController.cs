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
using System.Linq;
using System.Web.Mvc;

namespace AplicacionWeb.Controllers
{
    public class marcaController : Controller
    {
        private bdalmaceneslibertad2Entities db = new bdalmaceneslibertad2Entities();

        public ActionResult Index(int? page)
        {
            int pageSize = 10; // Número de elementos por página
            int pageNumber = (page ?? 1); // Número de página actual

            var marcas = db.marca.OrderBy(m => m.nommar).ToPagedList(pageNumber, pageSize);

            return View(marcas);
        }

        // Acción para mostrar el formulario de creación
        public ActionResult Create()
        {
            return View();
        }

        // Acción para manejar la creación de una nueva marca
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codmar,nommar,estmar")] marca marca)
        {
            if (ModelState.IsValid)
            {
                db.marca.Add(marca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marca);
        }

        // Acción para mostrar el formulario de edición
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            marca marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }

            return View(marca);
        }

        // Acción para manejar la edición de una marca existente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codmar,nommar,estmar")] marca marca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marca).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marca);
        }

        // Acción para mostrar los detalles de una marca
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            marca marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }

            return View(marca);
        }

        // Acción para mostrar el formulario de eliminación
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            marca marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }

            return View(marca);
        }

        // Acción para manejar la eliminación de una marca
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            marca marca = db.marca.Find(id);
            db.marca.Remove(marca);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

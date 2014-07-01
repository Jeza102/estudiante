using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class estudianteController : Controller
    {
        private estudianteContext db = new estudianteContext();

        //
        // GET: /estudiante/

        public ActionResult Index()
        {
            return View(db.estudiantes.ToList());
        }

        //
        // GET: /estudiante/Details/5

        public ActionResult Details(int id = 0)
        {
            estudiante estudiante = db.estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        //
        // GET: /estudiante/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /estudiante/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.estudiantes.Add(estudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estudiante);
        }

        //
        // GET: /estudiante/Edit/5

        public ActionResult Edit(int id = 0)
        {
            estudiante estudiante = db.estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        //
        // POST: /estudiante/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        //
        // GET: /estudiante/Delete/5

        public ActionResult Delete(int id = 0)
        {
            estudiante estudiante = db.estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        //
        // POST: /estudiante/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estudiante estudiante = db.estudiantes.Find(id);
            db.estudiantes.Remove(estudiante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
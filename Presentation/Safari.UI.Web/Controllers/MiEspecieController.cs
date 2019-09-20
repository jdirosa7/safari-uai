using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Safari.Entities;
using Safari.UI.Web.Models;
using Safari.Services.Contracts;
using Safari.Services;

namespace Safari.UI.Web.Controllers
{
    public class MiEspecieController : Controller
    {
        private IEspecie db;

        //private IEspecie db = new EspecieService();
        public MiEspecieController(IEspecie iespecie)
        {
            db = iespecie;
        }

        // GET: MiEspecie
        public ActionResult Index()
        {
            return View(db.ToList());
        }

        // GET: MiEspecie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Species species = db.Find(id.Value);
            if (species == null)
            {
                return HttpNotFound();
            }
            return View(species);
        }

        // GET: MiEspecie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MiEspecie/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] Species species)
        {
            if (ModelState.IsValid)
            {
                db.Add(species);
                
                return RedirectToAction("Index");
            }

            return View(species);
        }

        // GET: MiEspecie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Species species = db.Find(id.Value);
            if (species == null)
            {
                return HttpNotFound();
            }
            return View(species);
        }

        // POST: MiEspecie/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Species species)
        {
            if (ModelState.IsValid)
            {
                db.Update(species.Id, species);
                return RedirectToAction("Index");
            }
            return View(species);
        }

        // GET: MiEspecie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Species species = db.Find(id.Value);
            if (species == null)
            {
                return HttpNotFound();
            }
            return View(species);
        }

        // POST: MiEspecie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db = null;
            }
            base.Dispose(disposing);
        }
    }
}

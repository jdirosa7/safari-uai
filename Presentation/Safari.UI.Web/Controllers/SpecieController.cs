using Safari.Business;
using Safari.Entities;
using Safari.Services;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    //[Authorize]//Securizo que no se pueda acceder a ninguna vista o controlador si no estoy autenticado
    public class SpecieController : Controller
    {
        private IEspecie db = new EspecieService();

        //public SpecieController(IEspecie iEspecie)
        //{
        //    db = iEspecie;
        //}

        // GET: Especie
        [Route("especies", Name = "SpecieControllerRouteIndex")]
        public ActionResult Index()
        {
            var especies = db.ToList();
            return View(especies);
        }

        // GET: Especie/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Species especie = db.Find(id);
                if (especie == null)
                {
                    return HttpNotFound();
                }

                return View(especie);
            }
            catch (Exception ex)
            {                
                return View("Index");
            }
        }

        // GET: Especie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especie/Create
        [HttpPost]
        public ActionResult Create(Species especie)
        {
            try
            {
                var model = db.Add(especie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Especie/Edit/5
        public ActionResult Edit(int id)
        {
            Species especie = db.Find(id);
            if (especie == null)
            {
                return HttpNotFound();
            }

            return View(especie);
        }

        // POST: Especie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Species especie)
        {
            try
            {
                // TODO: Add update logic here
                especie = db.Update(id, especie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Especie/Delete/5
        public ActionResult Delete(int id)
        {
            Species especie = db.Find(id);
            if (especie == null)
            {
                return HttpNotFound();
            }

            return View(especie);
        }

        // POST: Especie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Species especie)
        {
            try
            {
                // TODO: Add delete logic here
                db.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

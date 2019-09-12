using Safari.Business;
using Safari.Entities;
using Safari.Services;
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
        // GET: Especie
        public ActionResult Index()
        {
            var especieSC = new EspecieService();
            var especies = especieSC.Listar();
            return View(especies);
        }

        // GET: Especie/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                var especieSC = new EspecieService();
                var model = especieSC.Agregar(especie);
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
            return View();
        }

        // POST: Especie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: Especie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

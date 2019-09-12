using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    public class MovementTypeController : Controller
    {
        // GET: MovementType
        public ActionResult Index()
        {
            return View();
        }

        // GET: MovementType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovementType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovementType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MovementType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovementType/Edit/5
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

        // GET: MovementType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovementType/Delete/5
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

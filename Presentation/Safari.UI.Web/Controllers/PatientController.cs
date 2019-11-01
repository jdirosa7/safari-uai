using Safari.Entities;
using Safari.Services;
using Safari.Services.Contracts;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    public class PatientController : Controller
    {
        PatientProcess db = new PatientProcess();
        ClientProcess dbClient = new ClientProcess();
        SpecieProcess dbSpecie = new SpecieProcess();

        // GET: Patient
        [Route("pacientes", Name = "PatientControllerRouteIndex")]
        public ActionResult Index()
        {
            var especies = db.ToList();
            return View(especies);
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Patient paciente = db.Find(id);
                if (paciente == null)
                {
                    return HttpNotFound();
                }

                return View(paciente);
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            List<Client> clientes = dbClient.ToList();
            List<Species> especies = dbSpecie.ToList();

            ViewBag.Clientes = clientes;
            ViewBag.Especies = especies;
            return View(ViewBag);
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(Patient paciente)
        {
            try
            {
                var model = db.Add(paciente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            Patient paciente = db.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }

            return View(paciente);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Patient paciente)
        {
            try
            {
                // TODO: Add update logic here
                paciente = db.Update(paciente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            Patient paciente = db.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }

            return View(paciente);
        }

        // POST: Patient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Patient paciente)
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

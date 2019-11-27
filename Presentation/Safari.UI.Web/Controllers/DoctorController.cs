using Safari.Business;
using Safari.Entities;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    public class DoctorController : Controller
    {
        //DoctorProcess db = new DoctorProcess();

        DoctorComponent db = new DoctorComponent();

        // GET: Doctor
        [Route("doctores", Name = "DoctorControllerRouteIndex")]
        public ActionResult Index()
        {
            var doctors = db.ToList();
            return View(doctors);
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Doctor doctor = db.Find(id);
                if (doctor == null)
                {
                    return HttpNotFound();
                }

                return View(doctor);
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            try
            {
                try
                {
                    db.Add(doctor);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            Doctor doctor = db.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            return View(doctor);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Doctor doctor)
        {
            try
            {
                // TODO: Add update logic here
                db.Update(doctor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            Doctor doctor = db.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Doctor doctor)
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

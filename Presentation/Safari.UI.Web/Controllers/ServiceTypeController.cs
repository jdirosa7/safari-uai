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
    public class ServiceTypeController : Controller
    {
        ServiceTypeProcess serviceTypeProcess = new ServiceTypeProcess();
        ServiceTypeComponent db = new ServiceTypeComponent();

        // GET: ServiceType
        [Route("tiposservicio", Name = "ServiceTypeControllerRouteIndex")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            List<ServiceType> data = db.List();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataById(int id)
        {
            var serviceType = db.Find(id);
            return Json(serviceType, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PostData(ServiceType serviceType)
        {
            if (ModelState.IsValid)
            {
                ServiceType dataServiceType = new ServiceType();
                serviceType.Name = serviceType.Name;

                if (serviceType.Id > 0)
                {
                    serviceType.Id = serviceType.Id;
                    db.Update(serviceType);
                }
                else
                    db.Add(serviceType);

                return Json("success", JsonRequestBehavior.AllowGet);
            }

            return Json("error", JsonRequestBehavior.DenyGet);
        }

        public JsonResult DeleteData(int? id)
        {
            if (id > 0)
            {
                db.Delete(id.Value);
                return Json("success", JsonRequestBehavior.AllowGet);
            }

            return Json("error", JsonRequestBehavior.DenyGet);
        }

        // GET: ServiceType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceType/Create
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

        // GET: ServiceType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServiceType/Edit/5
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

        // GET: ServiceType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceType/Delete/5
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

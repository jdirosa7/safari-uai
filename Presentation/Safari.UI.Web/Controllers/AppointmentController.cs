using Microsoft.AspNet.Identity;
using Safari.Business;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Safari.Entities.Appointment;

namespace Safari.UI.Web.Controllers
{
    public class AppointmentController : Controller
    {
        AppointmentComponent db = new AppointmentComponent();
        PatientComponent dbPatient = new PatientComponent();
        ClientComponent dbClient = new ClientComponent();
        RoomComponent dbRoom = new RoomComponent();
        ServiceTypeComponent dbServiceType = new ServiceTypeComponent();
        DoctorComponent dbDoctor = new DoctorComponent();


        // GET: Appointment
        [Route("turnos", Name = "AppointmentControllerRouteIndex")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            ViewBag.Rooms = new SelectList(dbRoom.ToList(), "Id", "Name");
            ViewBag.Patients = new SelectList(dbPatient.ToList(), "Id", "Name");
            ViewBag.ServiceTypes = new SelectList(dbServiceType.ToList(), "Id", "Name");
            ViewBag.Doctors = new SelectList(dbDoctor.ToList(), "Id", "Name");
            return View();
        }

        public ActionResult GetData()
        {
            List<Appointment> data = db.ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataById(int id)
        {
            var appointment = db.Find(id);
            return Json(appointment, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PostData(Appointment appointment)
        {
            Appointment dataAppointment = new Appointment();
            dataAppointment.Date = appointment.Date;
            dataAppointment.DoctorId = appointment.DoctorId;
            dataAppointment.PatientId = appointment.PatientId;
            dataAppointment.ServiceTypeId = appointment.ServiceTypeId;
            dataAppointment.RoomId = appointment.RoomId;
            dataAppointment.Status = Statuses.Reservado.ToString();



            if (appointment.Id > 0)
            {
                dataAppointment.UpdatedBy = User.Identity.GetUserId();
                dataAppointment.UpdatedDate = DateTime.Today;
                dataAppointment.Id = appointment.Id;
                db.Update(dataAppointment);
            }
            else
            {
                dataAppointment.CreatedBy = User.Identity.GetUserId();
                dataAppointment.CreatedDate = DateTime.Today;
                db.Add(dataAppointment);
            }

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteData(int id)
        {
            if (id > 0)
            {
                Appointment app = new Appointment();
                app.Id = id;
                app.Status = Statuses.Cancelado.ToString();
                app.Deleted = true;
                app.DeletedBy = User.Identity.GetUserId();
                app.DeletedDate = DateTime.Today;
                db.Delete(app);
                return Json("success", JsonRequestBehavior.AllowGet);
            }

            return Json("error", JsonRequestBehavior.DenyGet);
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var userId = User.Identity.GetUserId();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appointment/Edit/5
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

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Appointment/Delete/5
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

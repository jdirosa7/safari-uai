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
    public class RoomController : Controller
    {
        //IRoom db = new RoomService();

        RoomProcess roomProcess = new RoomProcess();

        // GET: Room
        [Route("consultorios", Name = "RoomControllerRouteIndex")]
        public ActionResult Index()
        {
            //var rooms = db.ToList();
            var rooms = roomProcess.SelectList();
            return View(rooms);
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Room room = roomProcess.FindRoom(id);
                if (room == null)
                {
                    return HttpNotFound();
                }

                return View(room);
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        public ActionResult Create(Room room)
        {
            try
            {
                roomProcess.AddRoom(room);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            Room room = roomProcess.FindRoom(id);
            if (room == null)
            {
                return HttpNotFound();
            }

            return View(room);
        }

        // POST: Room/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Room room)
        {
            try
            {
                // TODO: Add update logic here
                roomProcess.EditRoom(room);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            Room room = roomProcess.FindRoom(id);
            if (room == null)
            {
                return HttpNotFound();
            }

            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Room room)
        {
            try
            {
                // TODO: Add delete logic here
                roomProcess.DeleteRoom(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

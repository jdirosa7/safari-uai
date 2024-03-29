﻿using Safari.Business;
using Safari.Entities;
using Safari.Services;
using Safari.Services.Contracts;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Safari.Entities.Room;

namespace Safari.UI.Web.Controllers
{
    public class RoomController : Controller
    {
        //IRoom db = new RoomService();

        RoomProcess db = new RoomProcess();
        //RoomComponent db = new RoomComponent();

        // GET: Room
        [Route("consultorios", Name = "RoomControllerRouteIndex")]
        public ActionResult Index()
        {            
            var rooms = db.ToList();
            return View(rooms);
        }

        public ActionResult CreatePartialView()
        {
            ViewBag.RoomTypes = new SelectList(Enum.GetValues(typeof(Room.RoomTypes)), RoomTypes.Recuperación);
            return PartialView("CreatePartialView");
        }

        //[HttpGet]
        //public PartialViewResult Edit(Int32 id)
        //{
        //    var room = db.Find(id);
        //    return PartialView(room);
        //}

        //[HttpPost]
        //public JsonResult Edit(Room room)
        //{
        //    db.Update(room);
        //    return Json(room, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Index2()
        {
            ViewBag.RoomTypes = new SelectList(Enum.GetValues(typeof(Room.RoomTypes)), RoomTypes.Recuperación);
            return View();
        }

        public ActionResult GetData()
        {
            List<Room> data = db.ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataById(int id)
        {
            var room = db.Find(id);
            return Json(room, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PostData(Room room)
        {
            Room dataRoom = new Room();
            dataRoom.Name = room.Name;
            dataRoom.RoomType = room.RoomType;

            if (room.Id > 0)
            {
                dataRoom.Id = room.Id;
                db.Update(dataRoom);
            }
            else
                db.Add(dataRoom);

            return Json("success", JsonRequestBehavior.AllowGet);
            //if (ModelState.IsValid)
            //{

            //}

            //return Json("error", JsonRequestBehavior.DenyGet);
        }

        public JsonResult DeleteData(int? id)
        {
            if(id > 0)
            {
                db.Delete(id.Value);
                return Json("success", JsonRequestBehavior.AllowGet);
            }

            return Json("error", JsonRequestBehavior.DenyGet);
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Room room = db.Find(id);
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
                db.Add(room);
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
            Room room = db.Find(id);
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
                db.Update(room);
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
            Room room = db.Find(id);
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

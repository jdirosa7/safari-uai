using Safari.Business;
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
    public class ClientController : Controller
    {
        //ClientProcess db = new ClientProcess();
        ClientComponent db = new ClientComponent();

        
        // GET: Client
        [Route("clientes", Name = "ClientControllerRouteIndex")]
        public ActionResult Index()
        {
            var clientes = db.ToList();
            return View(clientes);
        }

        public ActionResult Index2()
        {            
            return View();
        }

        public ActionResult GetData()
        {
            List<Client> data = db.ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataById(int id)
        {
            var client = db.Find(id);
            return Json(client, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ClientPets(int id)
        {
            ViewBag.ClientId = id;
            return View("ClientPets");
        }

        public ActionResult GetClientPets(int id)
        {
            List<Patient> patients = db.GetClientPets(id);
            return Json(new { data = patients }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PostData(Client client)
        {
            Client dataClient = new Client();
            dataClient.Name = client.Name;
            dataClient.LastName = client.LastName;
            dataClient.Email = client.Email;
            dataClient.Phone = client.Phone;
            dataClient.URL = client.URL;
            dataClient.BirthDate = client.BirthDate;
            dataClient.Address = client.Address;

            if (client.Id > 0)
            {
                dataClient.Id = client.Id;
                db.Update(dataClient);
            }
            else
                db.Add(dataClient);

            return Json("success", JsonRequestBehavior.AllowGet);
            //if (ModelState.IsValid)
            //{

            //}

            //return Json("error", JsonRequestBehavior.DenyGet);
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

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Client cliente = db.Find(id);
                if (cliente == null)
                {
                    return HttpNotFound();
                }

                return View(cliente);
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client cliente)
        {
            try
            {
                db.Add(cliente);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            Client cliente = db.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Client cliente)
        {
            try
            {
                // TODO: Add update logic here
                db.Update(cliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            Client cliente = db.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Client cliente)
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

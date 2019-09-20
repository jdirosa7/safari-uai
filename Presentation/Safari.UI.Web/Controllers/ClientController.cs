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
    public class ClientController : Controller
    {
        private ICliente db = new ClienteService();

        //public ClientController(ICliente iCliente)
        //{
        //    db = iCliente;
        //}


        // GET: Client
        [Route("clientes", Name = "ClientControllerRouteIndex")]
        public ActionResult Index()
        {
            var clientes = db.ToList();
            return View(clientes);
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
                var model = db.Add(cliente);
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
                cliente = db.Update(id, cliente);
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

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Лаба_10.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        BD_BIPITEntities BD_BIPIT = new BD_BIPITEntities();
        public ActionResult Client()
        {
            IEnumerable<Client> Client = BD_BIPIT.Сlient;
            ViewBag.Client = Client;
            return View("Client");
        }
        public ActionResult Service()
        {
            IEnumerable<Service> Service = BD_BIPIT.Service;
            ViewBag.Service = Service;
            return View("Service");
        }

        public ActionResult Order()
        {
            IEnumerable<Order> Order = BD_BIPIT.Order;
            ViewBag.Order = Order;
            return View("Order");
        }

        [HttpGet]
        public ActionResult Client_Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Client_Add(Client s)
        {
            BD_BIPIT.Сlient.Add(s);
            BD_BIPIT.SaveChanges();
            return RedirectToAction("Client");
        }
        public ActionResult Client_Delete(int id)
        {
            Client s = new Client { Id = id };
            BD_BIPIT.Entry(s).State = EntityState.Deleted;
            BD_BIPIT.SaveChanges();
            return RedirectToAction("Client");
        }

        [HttpGet]
        public ActionResult Client_Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Client s = BD_BIPIT.Сlient.Find(id);
            if (s != null)
                return View(s);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Client_Edit(Client s)
        {
            BD_BIPIT.Entry(s).State = EntityState.Modified;
            BD_BIPIT.SaveChanges();
            return RedirectToAction("Client");
        }

        
        [HttpGet]
        public ActionResult Service_Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Service_Add(Service s)
        {
            BD_BIPIT.Service.Add(s);
            BD_BIPIT.SaveChanges();
            return RedirectToAction("Service");
        }
        public ActionResult Service_Delete(int id)
        {
            Service s = new Service { Id = id };
            BD_BIPIT.Entry(s).State = EntityState.Deleted;
            BD_BIPIT.SaveChanges();
            return RedirectToAction("Service");
        }

        [HttpGet]
        public ActionResult Service_Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Service s = BD_BIPIT.Service.Find(id);
            if (s != null)
                return View(s);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Service_Edit(Service s)
        {
            BD_BIPIT.Entry(s).State = EntityState.Modified;
            BD_BIPIT.SaveChanges();
            return RedirectToAction("Service");
        }

        


        [HttpGet]
        public ActionResult Order_Add()
        {
            SelectList Client = new SelectList(BD_BIPIT.Сlient, "Id", "FIO");
            ViewBag.Client = Client;
            SelectList Service = new SelectList(BD_BIPIT.Service, "Id", "Name_Service");
            ViewBag.Service = Service;
            return View();
        }

        [HttpPost]
        public ActionResult Order_Add(Order a)
        {
            BD_BIPIT.Order.Add(a);
            BD_BIPIT.SaveChanges();
            return RedirectToAction("Order");
        }

        [HttpGet]
        public ActionResult Order_Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Order app = BD_BIPIT.Order.Find(id);
            if (app != null)
            {
                SelectList Client = new SelectList(BD_BIPIT.Сlient, "Id", "FIO");
                ViewBag.Client = Client;
                SelectList Service = new SelectList(BD_BIPIT.Service, "Id", "Name_Service");
                ViewBag.Service = Service;
                return View(app);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Order_Edit(Order a)
        {
            BD_BIPIT.Entry(a).State = EntityState.Modified;
            BD_BIPIT.SaveChanges();
            return RedirectToAction("Order");
        }

        public ActionResult Order_Delete(int id)
        {
            Order a = new Order { Id = id };
            BD_BIPIT.Entry(a).State = EntityState.Deleted;
            BD_BIPIT.SaveChanges();
            return RedirectToAction("Order");
        }
    }
}
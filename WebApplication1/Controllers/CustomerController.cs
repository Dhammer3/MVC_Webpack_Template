using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using System.Configuration;
using WebApplication1.App_Start;
using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private MongoDBContext dBContext;
        private IMongoCollection<CustomerModel> customerCollection;

        public CustomerController()
        {
            dBContext = new MongoDBContext();
            customerCollection = dBContext.database.GetCollection<CustomerModel>("Customers");
        }
        // GET: Customers
        public ActionResult Index()
        {
            List<CustomerModel> customers = customerCollection.AsQueryable<CustomerModel>().ToList();
            return View(customers);
        }
        public ActionResult Details(string id)
        {
            var customerId = new ObjectId(id);
            var customer = customerCollection.AsQueryable<CustomerModel>().SingleOrDefault(x => x.id == customerId);
            return View(customer);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerModel customer)
        {
            try
            {
                customerCollection.InsertOne(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var customerId = new ObjectId(id);
            var customer = customerCollection.AsQueryable<CustomerModel>().SingleOrDefault(x => x.id == customerId);
            return View(customer);


        }

        [HttpPost]
        public ActionResult Edit(string id, CustomerModel customer)
        {
            try
            {
                var filter = Builders<CustomerModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<CustomerModel>.Update
                    .Set("name", customer.name)
                    .Set("email", customer.email)
                    .Set("phone", customer.phone);
                var result = customerCollection.UpdateOne(filter, update);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var customerId = new ObjectId(id);
            var customer = customerCollection.AsQueryable<CustomerModel>().SingleOrDefault(x => x.id == customerId);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(string id, CustomerModel customer)
        {
            try
            {
                customerCollection.DeleteOne(Builders<CustomerModel>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
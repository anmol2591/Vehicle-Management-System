using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDemo.App_Start;
using MongoDB.Bson;
using MongoDemo.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;

namespace MongoDemo.Controllers
{
    public class CarinformationController : Controller
    {
        MongoContext _dbContext;
        public CarinformationController()
        {
            _dbContext = new MongoContext();
        }
        // GET: Carinformation
        public ActionResult Index()
        {
            var carDetails = _dbContext._database.GetCollection<CarModel>("CarModel").FindAll().ToList();
            return View(carDetails);
        }

        // GET: Carinformation/Details/5
        public ActionResult Details(string id)
        {
            var carId = Query<CarModel>.EQ(p => p.Id, new ObjectId(id));
            var carDetail = _dbContext._database.GetCollection<CarModel>("CarModel").FindOne(carId);
            return View(carDetail);
        }

        // GET: Carinformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carinformation/Create
        [HttpPost]
        public ActionResult Create(CarModel carmodel)
        {

            var document = _dbContext._database.GetCollection<BsonDocument>("CarModel");

            var query = Query.And(Query.EQ("Carname", carmodel.Carname), Query.EQ("Color", carmodel.Color));

            var count = document.FindAs<CarModel>(query).Count();

            if (count == 0)
            {
                var result = document.Insert(carmodel);
            }
            else
            {
                TempData["Message"] = "Carname ALready Exist";
                return View("Create", carmodel);
            }
            // TODO: Add insert logic here

            return RedirectToAction("Index");
            
           
        }

        // GET: Carinformation/Edit/5
        public ActionResult Edit(string id)
        {
            var document = _dbContext._database.GetCollection<CarModel>("CarModel");

            var carDetailscount = document.FindAs<CarModel>(Query.EQ("_id", new ObjectId(id))).Count();

            if (carDetailscount > 0)
            {
                var carObjectid = Query<CarModel>.EQ(p => p.Id, new ObjectId(id));

                var carDetail = _dbContext._database.GetCollection<CarModel>("CarModel").FindOne(carObjectid);

                return View(carDetail);
            }
            return RedirectToAction("Index");
        }

        // POST: Carinformation/Edit/5
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

        // GET: Carinformation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Carinformation/Delete/5
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

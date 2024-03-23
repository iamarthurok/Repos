using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private readonly InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurance.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurance.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            return View(insurance);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.

        // POST: Insuree/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAdress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insurance insurance)
        {
            if (ModelState.IsValid)
            {
                // Add logic to calculate quote
                insurance.Quote = 50; // Base quote

                // Age logic
                int age = DateTime.Now.Year - insurance.DateOfBirth.Year;
                if (age <= 18)
                    insurance.Quote += 100;
                else if (age >= 19 && age <= 25)
                    insurance.Quote += 50;
                else
                    insurance.Quote += 25;

                // Car year logic
                if (insurance.CarYear < 2000)
                    insurance.Quote += 25;
                if (insurance.CarYear > 2015)
                    insurance.Quote += 25;

                // Car make logic
                if (insurance.CarMake == "Porsche")
                {
                    insurance.Quote += 25;
                    if (insurance.CarModel == "911 Carrera")
                        insurance.Quote += 25;
                }

                // Speeding tickets logic
                insurance.Quote += insurance.SpeedingTickets * 10;

                // DUI logic
                if (insurance.DUI)
                    insurance.Quote *= 1.25m;

                // Coverage type logic
                if (insurance.CoverageType.Equals("Full"))
                    insurance.Quote *= 1.5m;

                // Generate SQL query
                var sqlQuery = db.Insurance.ToString();

                // Log SQL query to console
                System.Diagnostics.Debug.WriteLine("SQL Query: " + sqlQuery);

                // Add insurance object to DbSet and save changes
                db.Insurance.Add(insurance);
                db.SaveChanges();

                // Redirect to Index action
                return RedirectToAction("Index");
            }

            return View(insurance);
        }



        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurance.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            return View(insurance);
        }

        // POST: Insuree/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAdress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insurance insurance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insurance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insurance);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurance.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            return View(insurance);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insurance insurance = db.Insurance.Find(id);
            db.Insurance.Remove(insurance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Admin()
        {
            var quotes = db.Insurance.ToList();
            return View(quotes);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your application contact page.";

            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

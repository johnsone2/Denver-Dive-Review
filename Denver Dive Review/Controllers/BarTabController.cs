using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Denver_Dive_Review.Models;

namespace Denver_Dive_Review.Controllers
{
    public class BarTabController : Controller
    {
        private BarTabContext db = new BarTabContext();

        //
        // GET: /BarTab/

        public ActionResult Index()
        {
            return View(db.BarTabModels.ToList());
        }

        //
        // GET: /BarTab/Details/5

        public ActionResult Details(int id = 0)
        {
            BarTabModel bartabmodel = db.BarTabModels.Find(id);
            if (bartabmodel == null)
            {
                return HttpNotFound();
            }
            return View(bartabmodel);
        }

        //
        // GET: /BarTab/Create

        public ActionResult Create()
        {
            throw new NotImplementedException("Need to implement security first");
            // Nob Hill ? 
            // Satellite ?
            // Shag Lounge ?
            var tab01 = new BarTabModel
            {
                BarName = "Delaney's",
                Items = new List<string>
                {
                    "New Belgium Autumn"
                },
                TabAmount = 5.00,
                WhoWasThere = new List<string>
                {
                    "Erik"
                },
                Date = new DateTime(2013, 10, 19, 17, 0, 0)
            };
            var tab02 = new BarTabModel
            {
                BarName = "Delaney's",
                Items = new List<string>
                {
                    "Potato Boats",
                    "Old Forester"
                },
                TabAmount = 12.00, // ~ $12
                WhoWasThere = new List<string>
                {
                    "Jon"
                },
                Date = new DateTime(2013, 10, 19, 17, 0, 0)
            };
            return View();
        }

        //
        // POST: /BarTab/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BarTabModel bartabmodel)
        {
            if (ModelState.IsValid)
            {
                db.BarTabModels.Add(bartabmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bartabmodel);
        }

        //
        // GET: /BarTab/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BarTabModel bartabmodel = db.BarTabModels.Find(id);
            if (bartabmodel == null)
            {
                return HttpNotFound();
            }
            return View(bartabmodel);
        }

        //
        // POST: /BarTab/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BarTabModel bartabmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bartabmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bartabmodel);
        }

        //
        // GET: /BarTab/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BarTabModel bartabmodel = db.BarTabModels.Find(id);
            if (bartabmodel == null)
            {
                return HttpNotFound();
            }
            return View(bartabmodel);
        }

        //
        // POST: /BarTab/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BarTabModel bartabmodel = db.BarTabModels.Find(id);
            db.BarTabModels.Remove(bartabmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
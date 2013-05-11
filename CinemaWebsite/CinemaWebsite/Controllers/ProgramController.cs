using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaWebsite.Models;

namespace CinemaWebsite.Controllers
{
    public class ProgramController : Controller
    {
        private List<ProgramModel> programModelList;
        private CinemaWebsiteContext db = new CinemaWebsiteContext();

        //
        // GET: /Program/

        public ActionResult Index()
        {
            return View(CreateProgramModel());
        }

        //
        // GET: /Program/Details/5

        public ActionResult Details(int id = 0)
        {
            Program program = db.Programmes.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        //
        // GET: /Program/Create

        public ActionResult Create()
        {
            return View();
        }

        private List<ProgramModel> CreateProgramModel()
        {
            List<ProgramModel> result = (from programes in db.Programmes
                                         join movies in db.Movies on programes.MovieId equals movies.MovieId

                                         select new ProgramModel
                                         {
                                             Date = programes.Date,
                                             MovieName = movies.Title,
                                             Price = programes.Price,
                                             Time = programes.Time
                                         }).ToList();
            return result;

        }

        //
        // POST: /Program/Create

        [HttpPost]
        public ActionResult Create(Program program)
        {
            if (ModelState.IsValid)
            {
                db.Programmes.Add(program);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(program);
        }

        //
        // GET: /Program/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Program program = db.Programmes.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        //
        // POST: /Program/Edit/5

        [HttpPost]
        public ActionResult Edit(Program program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(program).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(program);
        }

        //
        // GET: /Program/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Program program = db.Programmes.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        //
        // POST: /Program/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Program program = db.Programmes.Find(id);
            db.Programmes.Remove(program);
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
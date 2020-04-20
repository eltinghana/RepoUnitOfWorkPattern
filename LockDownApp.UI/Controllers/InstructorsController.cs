using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LockDownApp.BL.Interface;
using LockDownApp.DAL;
using LockDownApp.DAL.Repo;
using LockDownApp.DAL.Repo.Interface;

namespace LockDownApp.UI.Controllers
{
    public class InstructorsController : Controller
    {

        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InstructorName,InstructorContact")] Instructor instructor)
        {

            var validationResult = _instructorService.Validate(instructor);

            if (!validationResult.Item1) throw new Exception(validationResult.Item2);

            _instructorService.AddInstructor(instructor);

            return RedirectToAction("Index");

        }


        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var instructor = _instructorService.GetInstructor(id);

            if (instructor == null) return HttpNotFound();

            return View(instructor);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            _instructorService.DeleteInstructor(id);

            return RedirectToAction("Index");
        }


        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var instructor = _instructorService.DeleteInstructor(id);

            if (instructor == null) return HttpNotFound();

            return View(instructor);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var instructor = _instructorService.GetInstructor(id);

            if (instructor == null) return HttpNotFound();

            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InstructorName,InstructorContact")] Instructor instructor)
        {

            var validationResult = _instructorService.Validate(instructor);

            if (!validationResult.Item1) throw new Exception(validationResult.Item2);

            _instructorService.UpdateInstructor(instructor);

            return RedirectToAction("Index");

        }


        public ActionResult Index()
        {
            return View(_instructorService.GetAllInstructors());
        }
    }
}
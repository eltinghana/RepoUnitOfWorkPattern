using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LockDownApp.DAL;
using LockDownApp.DAL.Repo;
using LockDownApp.DAL.Repo.Interface;

namespace LockDownApp.UI.Controllers
{
    public class InstructorCoursesController : Controller
    {
       private readonly IInstructorCourseRepository _instrcutorCourseRepository;
       private readonly ICourseRepository _courseRepository;
       private readonly IInstructorRepository _instructorRepository;

       public InstructorCoursesController(IInstructorCourseRepository instrcutorCourseRepository, ICourseRepository courseRepository, IInstructorRepository instructorRepository)
       {
           _instrcutorCourseRepository = instrcutorCourseRepository;
           _courseRepository = courseRepository;
           _instructorRepository = instructorRepository;
       }

       public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(_courseRepository.GetAll(), "Id", "CourseTitle");

            ViewBag.InstructorId = new SelectList(_instructorRepository.GetAll(), "Id", "InstructorName");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseId,InstructorId")]
            InstructorCourse instructorCourse)
        {
            if (ModelState.IsValid)
                {
                    _instrcutorCourseRepository.Add(instructorCourse);

                   // _instrcutorCourseRepository.Save();

                    return RedirectToAction("Index");
                }

            ViewBag.CourseId = new SelectList(_courseRepository.GetAll(), "Id", "CourseTitle", instructorCourse.CourseId);
            ViewBag.InstructorId = new SelectList(_instructorRepository.GetAll(), "Id", "InstructorName", instructorCourse.InstructorId);
            return View(instructorCourse);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var instructorCourse = _instrcutorCourseRepository.Find(id);

            if (instructorCourse == null) return HttpNotFound();

            return View(instructorCourse);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var instructorCourse = _instrcutorCourseRepository.Find(id);

            _instrcutorCourseRepository.Remove(instructorCourse);

          //  _instrcutorCourseRepository.Save();

            return RedirectToAction("Index");
        }


        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var instructorCourse = _instrcutorCourseRepository.Find(id);

            if (instructorCourse == null) return HttpNotFound();

            return View(instructorCourse);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var instructorCourse = _instrcutorCourseRepository.Find(id);

            if (instructorCourse == null) return HttpNotFound();

            ViewBag.CourseId = new SelectList(_courseRepository.GetAll(), "Id", "CourseTitle", instructorCourse.CourseId);

            ViewBag.InstructorId = new SelectList(_instructorRepository.GetAll(), "Id", "InstructorName", instructorCourse.InstructorId);

            return View(instructorCourse);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseId,InstructorId")]
            InstructorCourse instructorCourse)
        {
            if (ModelState.IsValid)
                {
                    _instrcutorCourseRepository.Update(instructorCourse);

                  //  _instrcutorCourseRepository.Save();

                    return RedirectToAction("Index");
                }

            ViewBag.CourseId = new SelectList(_courseRepository.GetAll(), "Id", "CourseTitle", instructorCourse.CourseId);
            ViewBag.InstructorId = new SelectList(_instructorRepository.GetAll(), "Id", "InstructorName", instructorCourse.InstructorId);
            return View(instructorCourse);
        }


        public ActionResult Index()
        {
      
            return View(_instrcutorCourseRepository.GetAll());
        }
    }
}
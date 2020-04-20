using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LockDownApp.DAL;
using LockDownApp.DAL.Repo;
using LockDownApp.DAL.Repo.Interface;

namespace LockDownApp.UI.Controllers
{
    public class CoursesController : Controller
    {

        private readonly ICourseRepository _courseRepository;
        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseTitle,CourseCode")]
            Course course)
        {
            if (ModelState.IsValid)
                {
                    _courseRepository.Add(course);

                   // _courseRepository.Save();

                    return RedirectToAction("Index");
                }

            return View(course);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var course = _courseRepository.Find(id);

            if (course == null) return HttpNotFound();

            return View(course);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var course = _courseRepository.Find(id);

            _courseRepository.Remove(course);

           // _courseRepository.Save();

            return RedirectToAction("Index");
        }


        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var course = _courseRepository.Find(id);

            if (course == null) return HttpNotFound();

            return View(course);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var course = _courseRepository.Find(id);

            if (course == null) return HttpNotFound();

            return View(course);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseTitle,CourseCode")]
            Course course)
        {
            if (ModelState.IsValid)
                {

                    _courseRepository.Update(course);
               // _courseRepository.Save();

                    return RedirectToAction("Index");
                }

            return View(course);
        }


        public ActionResult Index()
        {
            return View(_courseRepository.GetAll());
        }
    }
}
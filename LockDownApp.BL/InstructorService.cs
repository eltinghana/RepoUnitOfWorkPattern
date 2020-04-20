using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LockDownApp.BL.Interface;
using LockDownApp.DAL;
using LockDownApp.DAL.Repo.Interface;

namespace LockDownApp.BL
{
    public class InstructorService : IInstructorService
    {

        private readonly IInstructorRepository _instructorRepository;
        private readonly IInstructorCourseRepository _instructorCourseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InstructorService(IInstructorRepository instructorRepository, IInstructorCourseRepository instructorCourseRepository, IUnitOfWork unitOfWork)
        {
            _instructorRepository = instructorRepository;
            _instructorCourseRepository = instructorCourseRepository;
            _unitOfWork = unitOfWork;
        }

        public Tuple<bool, string> Validate(Instructor obj)
        {

            var errorString = new StringBuilder();

            if (string.IsNullOrEmpty(obj.InstructorName)) errorString.AppendLine("Name cannot be empty");

            if (string.IsNullOrEmpty(obj.InstructorContact)) errorString.AppendLine("contact cannot be empty");

            return Tuple.Create(string.IsNullOrEmpty(errorString.ToString()), errorString.ToString());
        }

        public Instructor AddInstructor(Instructor obj)
        {

            _unitOfWork.Repository<Instructor>().Add(obj);

            _unitOfWork.SaveChanges();

            return obj;
        }

        public Instructor GetInstructor(int? id)
        {
            return _instructorRepository.Find(id);
        }

        public Instructor DeleteInstructor(int? id)
        {
            var instructor = _unitOfWork.Repository<Instructor>().Find(id);

            _unitOfWork.Repository<Instructor>().Remove(instructor);

            var oList = _instructorCourseRepository.GetByInstructorId(instructor.Id).ToList();

            foreach (var obj in oList.Select(allInstructor => _unitOfWork.Repository<InstructorCourse>().Find(allInstructor)))
                {
                    _unitOfWork.Repository<InstructorCourse>().Remove(obj);
                }


            _unitOfWork.SaveChanges();

            return instructor;
        }

        public Instructor UpdateInstructor(Instructor obj)
        {
            var existingObj = _unitOfWork.Repository<Instructor>().Find(obj.Id);

            existingObj.InstructorName = obj.InstructorName;

            existingObj.InstructorContact = obj.InstructorContact;

            _unitOfWork.SaveChanges();

            return existingObj;
        }

        public IEnumerable<Instructor> GetAllInstructors()
        {
            return _instructorRepository.GetAll().ToList();
        }
    }
}

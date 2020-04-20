using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockDownApp.DAL;

namespace LockDownApp.BL.Interface
{
    public interface IInstructorService
    {
        Tuple<bool, string> Validate(Instructor obj);
        Instructor AddInstructor(Instructor obj);
        Instructor GetInstructor(int? id);
        Instructor DeleteInstructor(int? id);
        Instructor UpdateInstructor(Instructor obj);
        IEnumerable<Instructor> GetAllInstructors();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockDownApp.DAL.Repo.Interface
{
    public interface IInstructorCourseRepository : IRepository<InstructorCourse>
    {
        IEnumerable<int> GetByInstructorId(int id);
    }
}

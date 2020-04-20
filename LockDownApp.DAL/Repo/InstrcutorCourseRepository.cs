using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LockDownApp.DAL.Repo.Interface;

namespace LockDownApp.DAL.Repo
{
    public class InstrcutorCourseRepository : Repository<InstructorCourse>, IInstructorCourseRepository
    {
        public InstrcutorCourseRepository(DbContext context) : base(context) { }

        public IEnumerable<int> GetByInstructorId(int id)
        {
            return Find(x => x.InstructorId == id).Select(x => x.Id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockDownApp.DAL.Repo.Interface;

namespace LockDownApp.DAL.Repo
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DbContext context) : base(context) { }


    }
}

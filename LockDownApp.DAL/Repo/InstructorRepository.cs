using System.Data.Entity;
using LockDownApp.DAL.Repo.Interface;

namespace LockDownApp.DAL.Repo
{
    public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(DbContext context) : base(context) { }
    }
}

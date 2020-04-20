namespace LockDownApp.DAL.Repo.Interface
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;
        void SaveChanges();
    }
}

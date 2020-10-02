namespace ApiUowPattern.Interfaces
{
    public interface IUnitOfWork
    {
         void Commit();
         void Rollback();
    }
}
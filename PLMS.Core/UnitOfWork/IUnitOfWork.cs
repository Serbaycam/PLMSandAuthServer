namespace PLMS.Core.UnitOfWork
{
    public interface IUnitOfWork<TContext>
    {
        Task CommitAsync();
        void Commit();
    }
}

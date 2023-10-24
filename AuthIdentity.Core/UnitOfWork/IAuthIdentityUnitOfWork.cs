namespace AuthIdentity.Core.UnitOfWork
{
    public interface IAuthIdentityUnitOfWork<TContext>
    {
        Task CommitAsync();
        void Commit();
    }
}

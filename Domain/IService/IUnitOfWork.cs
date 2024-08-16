
using Asar.Domain.Abstraction;

namespace SalesProject.Domain.IService
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepo<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
        public void Rollback();
    }
}

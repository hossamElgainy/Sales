
using Asar.Domain.Abstraction;
using Asar.Domain.Specification;
using System.Linq.Expressions;

namespace SalesProject.Domain.IService
{
    public interface IGenericRepo<T> where T : BaseEntity
    {

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetBYIdAsync(Guid id);

        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);
        Task<T> GetEntityWithSpecAsync(ISpecification<T> spec);
        Task<int> GetCountWithSpecAsync(ISpecification<T> spec);

        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task AddRange(List<T> entity);
        void UpdateRange(List<T> entity);
        void DeleteRange(List<T> entity);


        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

    }
}

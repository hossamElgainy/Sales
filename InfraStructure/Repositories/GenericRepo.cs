
using Asar.Domain.Abstraction;
using Asar.Domain.Specification;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.IService;
using System.Linq.Expressions;

namespace InfraStructure.Repositories
{
    public class GenericRepo<T>(SalesDbContext context) : IGenericRepo<T> where T : BaseEntity
    {
        private readonly SalesDbContext _context = context;


        public async Task<IReadOnlyList<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<T> GetBYIdAsync(Guid id)
            => await _context.Set<T>().FindAsync(id);


        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
          => await ApplySpecification(spec).ToListAsync();


        public async Task<T> GetEntityWithSpecAsync(ISpecification<T> spec)
          => await ApplySpecification(spec).FirstOrDefaultAsync();

        public async Task<int> GetCountWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }


        public async Task Add(T entity)
             => await _context.Set<T>().AddAsync(entity);

        public void Update(T entity)
             => _context.Set<T>().Update(entity);

        public void Delete(T entity)
             => _context.Set<T>().Remove(entity);


        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
                 => SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), spec);



        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().CountAsync(predicate);
        }

        public Task AddRange(List<T> entity)
            => _context.Set<T>().AddRangeAsync(entity);

        public void UpdateRange(List<T> entity)
            => _context.Set<T>().UpdateRange(entity);


        public void DeleteRange(List<T> entity)
            => _context.Set<T>().RemoveRange(entity);
    }
}

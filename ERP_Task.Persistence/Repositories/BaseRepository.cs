using System.Linq.Expressions;
using ERP_Task.Application.Repositories;
using ERP_Task.Domain.Common;
using ERP_Task.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP_Task.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            entity.DateCreated = DateTimeOffset.UtcNow;
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            entity.DateUpdated = DateTimeOffset.UtcNow;
            _context.Update(entity);
        }

        public virtual Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            if (entity is IDeletable deletable)
            {
                deletable.IsDeleted = true;
                deletable.DateDeleted = DateTimeOffset.UtcNow;
                _context.Set<T>().Update(entity);
            }
            else
            {
                throw new InvalidOperationException("Entity does not support soft delete.");
            }

            return Task.CompletedTask;
        }

        public virtual Task RemoveAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }


        public async Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return _context.Set<T>().ToListAsync(cancellationToken);
        }
        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AnyAsync(predicate, cancellationToken);
        }
        public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            return predicate == null
                ? await _context.Set<T>().CountAsync(cancellationToken)
                : await _context.Set<T>().CountAsync(predicate, cancellationToken);
        }
        public virtual async Task<List<T>> FindAllAsync(
               Expression<Func<T, bool>> predicate,
               CancellationToken cancellationToken)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync(cancellationToken);
        }
        public virtual async Task<TResult?> FindOneAsync<TResult>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> selector,
            CancellationToken cancellationToken)
        {
            return await _context.Set<T>()
                .Where(predicate)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);
        }
        public virtual async Task<List<T>> GetPagedAsync(
               int pageNumber,
               int pageSize,
               Expression<Func<T, bool>>? predicate = null,
               Expression<Func<T, object>>? orderBy = null,
               bool ascending = true,
               CancellationToken cancellationToken = default)
        {
            var query = _context.Set<T>().AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public abstract class EntityBase { }
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                    string includeProperties = "");

        Task<TEntity> GetByIdAsync<TKey>(TKey id);
        Task InsertAsync(TEntity entity);
        Task DeleteAsync<TKey>(TKey id);
        Task DeleteAsync(TEntity entityToDelete);
        Task UpdateAsync(TEntity entityToUpdate);
        void SaveChanges();
        Task SaveChangesAsync();

        // --------- TODO ---------
        // AddRange
        // DeleteRange
        // GetAll
    }
}

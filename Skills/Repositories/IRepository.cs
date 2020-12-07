using System.Collections.Generic;

namespace Skills.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> Queryable();
        void InsertAll(List<TEntity> entities);
    }
}

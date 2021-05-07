using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.DataLayer
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        TEntity Save(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(int id);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}

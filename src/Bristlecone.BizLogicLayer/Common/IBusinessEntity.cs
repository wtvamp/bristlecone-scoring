using System;
using System.Collections.Generic;

namespace Bristlecone.BizLogicLayer.Common
{
    public interface IBusinessEntity<T>
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void Save();
    }
}
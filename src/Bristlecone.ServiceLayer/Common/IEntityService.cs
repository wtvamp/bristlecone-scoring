using System.Collections.Generic;

namespace BristleCone.ServiceLayer.Common
{
    public interface IEntityService<T>
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}

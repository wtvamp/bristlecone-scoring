using System;
using System.Collections.Generic;
using Bristlecone.BizLogicLayer.Common;
using Bristlecone.DataAccessLayer.Common;
using BristleCone.ServiceLayer.Common;

namespace Bristlecone.ServiceLayer.Common
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        private IBusinessEntity<T> _bizLayer;

        protected EntityService(IBusinessEntity<T> bizLayer)
        {
            _bizLayer = bizLayer;
        }

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _bizLayer.Create(entity);
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _bizLayer.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _bizLayer.Delete(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _bizLayer.GetAll();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Bristlecone.DataAccessLayer.Interfaces
{
    public interface IContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
        void SetState<TEntity>(TEntity entity, EntityState state) where TEntity : class;
        EntityState GetState<TEntity>(TEntity entity) where TEntity : class;
    }
}

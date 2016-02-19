using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TaskTracker.Infrastructure.Contexts;
using TaskTracker.Infrastructure.Entities;

namespace TaskTracker.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TContext, TEntity> : IRepository<TContext, TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new()
    {
        protected RepositoryBase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TContext>());
//            Database.SetInitializer<TContext>(new DropCreateDatabaseAlways<TContext>());
        }

        public void Connect(Action<TContext> work)
        {
            using (var database = new TContext())
            {
                work(database);
                database.SaveChanges();
            }
        }

        public TReturn Connect<TReturn>(Func<TContext, TReturn> work)
        {
            using (var database = new TContext())
            {
                var result = work(database);
                database.SaveChanges();

                return result;
            }
        }

        public virtual TEntity GetById(int id)
        {
            return Connect(database => database.Set<TEntity>().Find(id));
        }

        public virtual void Add(TEntity entity)
        {
            Connect(database => database.Set<TEntity>().Add(entity));
        }

        public virtual void Remove(int id)
        {
            Connect(database =>
            {
                var taskEntity = database.Set<TEntity>().Find(id);
                database.Set<TEntity>().Remove(taskEntity);
            });
        }

        public virtual void AddOrUpdate(TEntity entity)
        {
            Connect(database => database.Set<TEntity>().AddOrUpdate(entity));
        }

        public virtual IEnumerable<TEntity> List()
        {
            return Connect(database => database.Set<TEntity>().ToList());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using TaskTracker.Infrastructure.Entities;

namespace TaskTracker.Infrastructure.Repositories
{
    public interface IRepository<out TContext, TEntity> where TEntity : IEntity
        where TContext : DbContext
    {
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Remove(int id);
        void AddOrUpdate(TEntity entity);
        IEnumerable<TEntity> List();
        void Connect(Action<TContext> work);
        TReturn Connect<TReturn>(Func<TContext, TReturn> work);
    }
}
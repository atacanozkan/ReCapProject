using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    // Generic constraint
    // T tipini sınırlandırabilmek için kullanılır
    // class -> T'nin referans tip alabileceği ve IEntity veya IEntity'yi implement eden bir nesne olabileceği anlamına gelir
    // new() : new'lenebilir olmalı. IEntity new'lenemeyeceği için sadece IEntity'yi implement eden bir nesne olabilir
    public interface IEntityRepository<T> where T:class,IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
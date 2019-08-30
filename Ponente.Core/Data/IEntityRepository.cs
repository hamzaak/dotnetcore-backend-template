using Ponente.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ponente.Core.Data
{
    public interface IEntityRepository<T> where T : class, IEntity, new()  //class > reference type, new olabilirim bir obje
    {
        T Get(Expression<Func<T, bool>> filter);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);
    }
}

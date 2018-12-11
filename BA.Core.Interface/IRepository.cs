using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BA.Core.Interface
{
    public interface IRepository<T> where T :class
    {
        IQueryable<T> Entities { get;}

        T GetById(int id);

        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
    }
}

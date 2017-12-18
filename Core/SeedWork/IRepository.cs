using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftManagementPortal.Core.SeedWork
{
    public interface IRepository <T> where T: IAggregateRoot
    {
        T GetById(object id);
        IEnumerable<T> GetAll();
        T Add(T item);
        void Update(T item);
        void Remove(T item);
    }
}

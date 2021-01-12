using System.Collections.Generic;

namespace temis.Core.Interfaces
{
    public interface IRepository<T> 
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long? id);
    }
}
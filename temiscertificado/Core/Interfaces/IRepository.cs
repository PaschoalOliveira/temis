using System.Collections.Generic;
using temis.Core.Models;

namespace temis.Core.Interfaces
{
    public interface IRepository
    {
        Certificado Create(Certificado item);
        Certificado FindById(long id);
        List<Certificado> FindAll();
        Certificado Update(Certificado item);
        void Delete(long id);
        bool Exists(long? id);
    }
}
using System.Collections.Generic;
using temis.Core.Models;

namespace temis.Core.Services.Interface
{
    public interface IService
    {
        Certificado Create(Certificado item);
        Certificado FindById(long id);
        List<Certificado> FindAll();
        Certificado Update(Certificado item);
        void Delete(long id);
        bool Exists(long? id);
    }
}
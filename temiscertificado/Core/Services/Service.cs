using System.Collections.Generic;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.Core.Services.Interface;

namespace temis.Core.Services
{
    public class Service : IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public Certificado Create(Certificado item)
        {
            Certificado certificado = _repository.Create(item);
            return certificado;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public bool Exists(long? id)
        {
            throw new System.NotImplementedException();
        }

        public List<Certificado> FindAll()
        {
            List<Certificado> certificados = _repository.FindAll();
            return certificados;
        }

        public Certificado FindById(long id)
        {
            Certificado certificado = _repository.FindById(id);
            return certificado;
        }

        public Certificado Update(Certificado item)
        {
            Certificado certificado = _repository.Update(item);
            return certificado;
        }
    }
}

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using temis.Core.Interfaces;
using temis.Core.Models;

namespace temis.Data.Repositories
{
    public class GenericRepository : IRepository
    {
        protected readonly TemisContext _context;

        public GenericRepository(TemisContext context)
        {
            _context = context;
        }

        public Certificado Create(Certificado item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(long id)
        {
            var result = _context.Certificados.SingleOrDefault(i => i.Id.Equals(id));

            try
            {
                if (result != null)
                {
                    _context.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(long? id)
        {

            return _context.Certificados.Any(b => b.Id.Equals(id));
        }

        public List<Certificado> FindAll()
        {
            return _context.Certificados.ToList();
        }

        public Certificado FindById(long id)
        {
            return _context.Certificados.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Certificado Update(Certificado item)
        {

            if (!Exists(item.Id)) return null;

            var result = _context.Certificados.SingleOrDefault(b => b.Id == item.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

    }
}
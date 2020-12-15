using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using temis.Core.Models;

namespace temis.Data.Repositories
{
    public class Pagination<T> : List<T>
    {
        public static PageList<T> Create(IQueryable<T> source, int numeroPagina, int tamanhoPagina){
            
            var count = source.Count();
            var items = source.Skip((numeroPagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToList();

            return new PageList<T>(items, count, numeroPagina , tamanhoPagina);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using temis.Core.Models;

namespace temis.core.Models
{
    public class PaginationRepository<T> : List<T>
    {
        public static PageList<T> Create(List<T> source, int numeroPagina, int tamanhoPagina){
            
            var count = source.Count();
            var items = source.Skip((numeroPagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToList();

            return new PageList<T>(items, count, numeroPagina , tamanhoPagina);
        }
    }
}
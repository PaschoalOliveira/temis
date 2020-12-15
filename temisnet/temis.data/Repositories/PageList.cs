using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace temis.Data.Repositories
{
    public class PageList<T> : List<T>
    {
        public int PaginaCorrente { get; set; }

        public int TotalPaginas { get; set; }

        public int TamanhoPagina { get; set; }

        public int TotalElementos { get; set; }

        public PageList(List<T> items, int totalElementos, int numeroPagina, int tamanhoPagina)
        {
            this.TotalElementos = totalElementos;
            this.TamanhoPagina = tamanhoPagina;
            this.PaginaCorrente = numeroPagina;
            this.TotalPaginas = (int)Math.Ceiling(totalElementos / tamanhoPagina);
            this.AddRange(items);
        }

        public static PageList<T> Create(IQueryable<T> source, int numeroPagina, int tamanhoPagina){
            
            var count = source.Count();
            var items = source.Skip((numeroPagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToList();

            return new PageList<T>(items, count, numeroPagina , tamanhoPagina);
        }
    }
}
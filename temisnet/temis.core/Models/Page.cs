using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace temis.Core.Models
{
    public class Page
    {
        public int PageCurrent { get; set; } // PaginaCorrente
        public bool Paged { get; set; }
        public int Number { get; set; }
        public int Limit {get; set; } // Limit
        public bool First { get; set; }
        public bool Last { get; set; }
        public int TotalPages { get; set; } // TotalPaginas
        public int Total { get; set; } // TamanhoPagina
        public int TotalElement { get; set; } // TotalElementos
        public List<int> Limits { get; }
        public Page()
        {
            this.Limits = PageRequest.PageLimits;
        }
    }
}
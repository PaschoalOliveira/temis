using System.Collections.Generic;
namespace temis.Core.Models
{
    public class Page
    {
        public int PageCurrent { get; set; } 
        public bool Paged { get; set; }
        public int Number { get; set; }
        public int Limit {get; set; } 
        public bool First { get; set; }
        public bool Last { get; set; }
        public int TotalPages { get; set; } 
        public int Total { get; set; } 
        public int TotalElement { get; set; } 
        public List<int> Limits { get; }
        public Page()
        {
            this.Limits = PageRequest.PageLimits;
        }
    }
}
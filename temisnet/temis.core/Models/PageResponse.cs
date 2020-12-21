using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace temis.Core.Models
{
    public class PageResponse<T>
    {
        public Page Page { get; set; }
        public List<T> Content { get; set; }
        public PageResponse() {}
        public PageResponse(List<T> content, int pageNumber, int pageLimit, int totalResult): this(content, PageRequest.Of(pageNumber, pageLimit), totalResult) { }
        public PageResponse(List<T> content, PageRequest pr, long totalResult)
        {

            Page page = new Page();

            page.Paged = totalResult > content.Count;
            
            page.Number = pr.Number;
            page.Limit = pr.Limit;

            page.TotalPages = (int)Math.Ceiling((double)totalResult / (double)page.Limit);
            
            page.Total = (int)totalResult;

            page.First = page.Number == 1;
            page.Last = page.Number >= page.Total;

            this.Content = content.Skip(page.Limit * (page.Number - 1)).Take(page.Limit).ToList();
            this.Page = page;
        }
        public static PageResponse<T> For(List<T> content, PageRequest pr, long totalResult) => new PageResponse<T>(content, pr, totalResult);
    
    }
}
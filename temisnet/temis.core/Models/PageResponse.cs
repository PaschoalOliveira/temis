using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace temis.Core.Models
{
    public class PageResponse<User>
    {
        public Page Page { get; set; }
        public List<User> Content { get; set; }
        public PageResponse() {}
        public PageResponse(List<User> content, int pageNumber, int pageLimit, int totalResult): this(content, PageRequest.Of(pageNumber, pageLimit), totalResult) { }
        public PageResponse(List<User> content, PageRequest pr, long totalResult)
        {
            this.Content = content;

            Page page = new Page();

            page.Paged = totalResult > content.Count;
            
            page.Number = pr.Number;
            page.Limit = pr.Limit;

            page.TotalPages = (int)Math.Ceiling((double)totalResult / (double)page.Limit);
            
            page.Total = (int)totalResult;

            page.First = page.Number == 1;
            page.Last = page.Number >= page.Total;

            this.Page = page;
        }
        public static PageResponse<User> For(List<User> content, PageRequest pr, long totalResult) => new PageResponse<User>(content, pr, totalResult);
    
    }
}
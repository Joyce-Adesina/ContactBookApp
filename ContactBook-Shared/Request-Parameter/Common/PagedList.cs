using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Shared.Request_Parameter.Common
{
    public class PagedList<T>:List<T>
    {
        public MetaData MetaData { get; set; }
        public PagedList(List<T>items, int count, int pageNumber, int pageSize)
        {
            MetaData = new()
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
            AddRange(items);

        }
    }
}

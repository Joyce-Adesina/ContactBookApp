using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Shared.Request_Parameter
{
    public abstract class RequestInputParameter
    {
        private int MaxPageSize = 20;
        private int PageSize = 5;

        public int pageSize
        {
            get 
            { 
                return pageSize; 
            }
            set
            {
                PageSize = value > MaxPageSize ? MaxPageSize : value;
            }
        }
        public int PageNumber { get; set; } = 1;
    }
}

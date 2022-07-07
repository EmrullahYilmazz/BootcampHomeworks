using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Application.Parameters
{
    public class RequesParameter
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public RequesParameter(int pagesize, int pagenumber)
        {
            PageSize = pagesize;
            PageNumber = pagenumber;    
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Application.Dto
{
    public class ListDTO
    {
        public string Category { get; set; }
        public string ListTitle { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public int ItemQuantity { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.Model
{
    public class Pagination
    {

        public Pagination() {
            PageIndex = 1; 
            PageSize = 10 ;
            SortFields = new List<string> { "id desc" };
            TotalElements = 0;   
        
        }


        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public List<string> SortFields { get; set; }

        public int TotalElements { get; set; }
    }
}

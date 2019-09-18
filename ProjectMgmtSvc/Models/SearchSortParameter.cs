using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMgmtSvc.Models
{
    public class SearchSortParameter
    {
        public string SortBy { get; set; }
        public string Search { get; set; }
        public bool Ascending { get; set; }        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CommonMessages_DTO
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsWarning { get; set; }
        public bool IsInformation { get; set; }
    }

    public class Sort_Parameters
    {
        public string OrderBy { get; set; }
        public string SortDir { get; set; }
        public string SearchKeyword { get; set; }
    }
}

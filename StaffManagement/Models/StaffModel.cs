using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.Models
{
    public class StaffModel
    {
        public int Id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

    }
    public class StaffFilterResult
    {
        public int total { get; set; }
        public List<StaffModel> rows { get; set; }
    }
    public class ApiResponse<T>
    {
        public T data { get; set; }
        public bool success { get; set; }
    }
}

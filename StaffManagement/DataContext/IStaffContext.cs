using StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.DataContext
{
    interface IStaffContext
    {
        StaffFilterResult Filter(int pageNumber, int pageSize);
        void Update(StaffModel model);
        void Create(StaffModel model);
        void Delete(int staffId);
    }
}

using StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.DataContext
{
    public interface IStaffContext
    {
        Task<StaffFilterResult> Filter(int pageNumber, int pageSize);
        Task Update(StaffModel model);
        Task Create(StaffModel model);
        Task Delete(int staffId);
    }
}

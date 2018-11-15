using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffManagement.Models;

namespace StaffManagement.DataContext
{
    public class StaffContext : IStaffContext
    {
        public void Create(StaffModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int staffId)
        {
            throw new NotImplementedException();
        }

        public StaffFilterResult Filter(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Update(StaffModel model)
        {
            throw new NotImplementedException();
        }
    }
}

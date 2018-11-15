using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement
{
    public class DbConfiguration
    {
        public string ConnectionString { get; private set; }

        public DbConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}

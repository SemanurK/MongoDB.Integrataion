using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekmob.Technical.Customer.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string EmployeeCollection { get; set; }
        public string DepartmentCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

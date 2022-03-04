using Ekmob.Technical.Customer.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekmob.Technical.Customer.Data
{
    public class DepartmentSeed
    {
        public static void SeedData(IMongoCollection<Department> departmentCollection)
        {
            bool existDepartment = departmentCollection.Find(p => true).Any();
            if (!existDepartment)
            {
                departmentCollection.InsertManyAsync(GetConfigureDepartment());
            }
        }

        private static IEnumerable<Department> GetConfigureDepartment()
        {
            return new List<Department>()
            {
                  new Department()
                {
                    DepartmentName = "Teknoloji",
                },
            };
        }
    }
}

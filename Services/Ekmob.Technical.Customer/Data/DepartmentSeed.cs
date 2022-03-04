using System.Collections.Generic;
using Ekmob.Technical.Services.Entities;
using MongoDB.Driver;

namespace Ekmob.Technical.Services.Data
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

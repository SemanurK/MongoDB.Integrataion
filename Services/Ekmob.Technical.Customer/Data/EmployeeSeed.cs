using Ekmob.Technical.Customer.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekmob.Technical.Customer.Data
{
    public class EmployeeSeed
    {

        public static void SeedData(IMongoCollection<Employee> employeeCollection,
            IMongoCollection<Department> departmentCollection)
        {
            bool existEmployee = employeeCollection.Find(p => true).Any();
            bool existDepartment = departmentCollection.Find(p => true).Any();

            string departmentId = "";
            if (existDepartment)
                departmentId = departmentCollection.Find(p => true).FirstOrDefault().DepartmentId;

            if (!existEmployee)
            {
                employeeCollection.InsertManyAsync(GetConfigureEmployee(departmentId));
            }
        }

        private static IEnumerable<Employee> GetConfigureEmployee(string departmentId)
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    EmployeerName = "Semanur Karaçam",
                    EmployeeMail = "semanur.karacam@ekmob.com",
                    EmployeeJob = "Backend Developer",
                    DepartmentId = departmentId,
                },
            };
        }
    }
}

using Ekmob.Technical.Customer.Data.Interface;
using Ekmob.Technical.Customer.Entities;
using Ekmob.Technical.Customer.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekmob.Technical.Customer.Data.Concrete
{
    public class BaseContext : IBaseContext
    {
        public BaseContext(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var databaseName = client.GetDatabase(databaseSettings.DatabaseName);

            Employees = databaseName.GetCollection<Employee>(databaseSettings.EmployeeCollection);
            Departments = databaseName.GetCollection<Department>(databaseSettings.DepartmentCollection);

            DepartmentSeed.SeedData(Departments);
            EmployeeSeed.SeedData(Employees, Departments);          

        }
        public IMongoCollection<Employee> Employees { get; }

        public IMongoCollection<Department> Departments { get; }
    }
}

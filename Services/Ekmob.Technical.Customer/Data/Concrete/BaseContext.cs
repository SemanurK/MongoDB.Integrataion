using Ekmob.Technical.Customer.Data;
using Ekmob.Technical.Customer.Data.Interface;
using Ekmob.Technical.Services.Entities;
using Ekmob.Technical.Services.Settings;
using MongoDB.Driver;

namespace Ekmob.Technical.Services.Data.Concrete
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

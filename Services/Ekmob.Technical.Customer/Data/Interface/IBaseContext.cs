﻿using Ekmob.Technical.Customer.Entities;
using MongoDB.Driver;

namespace Ekmob.Technical.Customer.Data.Interface
{
    public interface IBaseContext
    {
        IMongoCollection<Employee> Employees { get; }
        IMongoCollection<Department> Departments { get;}
    }
}

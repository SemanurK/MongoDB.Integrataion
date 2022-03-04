using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Ekmob.Technical.Customer.Entities
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EmployeeId { get; set; }
        public string EmployeerName { get; set; }
        public string EmployeeMail { get; set; }
        public string EmployeeJob { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string DepartmentId { get; set; }

        [BsonIgnore]
        public Department Department { get; set; }  
    }
}

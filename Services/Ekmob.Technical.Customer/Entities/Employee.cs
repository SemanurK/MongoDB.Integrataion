using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ekmob.Technical.Services.Entities
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

namespace Ekmob.Technical.Services.Settings
{
    public interface IDatabaseSettings
    {
        public string EmployeeCollection { get; set; }
        public string DepartmentCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

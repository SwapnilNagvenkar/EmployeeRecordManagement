namespace EmployeeRecordManagement.Models
{
    public class Department
    {
        public int DepartmentId {  get; set; }
        public string Name { get; set; }

        //Rrelationship with Employees
        //public ICollection<Employee> Employees { get; set; } //collection

    }
}

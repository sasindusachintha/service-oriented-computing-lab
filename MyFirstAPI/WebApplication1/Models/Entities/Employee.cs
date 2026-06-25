namespace WebApplication1.Modules.Entities
{
    public class Employee
    {
        public int EmployeeId {  get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Department { get; set; }

        public string Position { get; set; }

        public decimal Salary { get; set; }

        public DateTime HireDate  { get; set; }

        public bool status { get; set; }
    }
}

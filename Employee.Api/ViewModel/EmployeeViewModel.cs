namespace Employee.Api.ViewModel
{
    public class EmployeeViewModel
    {
        public Guid Id { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public string FatherName { set; get; }

        public string Email { set; get; }
        public DateTime DOB { set; get; }
        public string Address { set; get; }
        public string DepartmentNames { set; get; }
        public string PositionNames { set; get; }
    }
    public class EmployeeCreateViewModel
    {

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public string FatherName { set; get; }

        public string Email { set; get; }
        public DateTime DOB { set; get; }
        public string Address { set; get; }
        public Guid[] departmentPositionIds { set; get; }
    }
    public class EmployeeSearchViewModel
    {
        public bool All { set; get; }
        public Guid? Id { set; get; }
        public string? Name { set; get; }
        public Guid? DepartmentId { set; get; }
        public Guid? PositionId { set; get; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Employee.Api.ViewModel
{
    public class DepartmentViewModel
    {
        [StringLength(255)]
        public string Name { set; get; }
        public Guid Id { set; get; }
    }
    public class DepartmentCreateViewModel
    {
        [StringLength(255)]
        public string Name { set; get; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Employee.Api.ViewModel
{
    public class DepartmentViewModel
    {
        [StringLength(255)]
        public string Name { set; get; }
    }
}

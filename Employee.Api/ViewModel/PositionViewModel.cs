using System.ComponentModel.DataAnnotations;

namespace Employee.Api.ViewModel
{
    public class PositionViewModel
    {
        [StringLength(255)]
        public string Name { set; get; }
        public Guid Id { set; get; }
    }
    public class PositionCreateViewModel
    {
        [StringLength(255)]
        public string Name { set; get; }
    }
    public class PositionSearchCondition
    {
        public bool All { set; get; }
        public string? DepartmentId { set; get; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Employee.Api.ViewModel
{
    public class PositionViewModel
    {
        [StringLength(255)]
        public string Name { set; get; }
    }
}

using Employee.Api.ViewModel;
using Employee.DBA.Tables;
using Employee.DBA.Unit_Of_Work;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentPositionController : Controller
    {
        private readonly IUnitOfWork work;
        public DepartmentPositionController(IUnitOfWork work)
        {
            this.work = work;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var depPos = work.departmentPositionsrepo.All();
            return Ok(new { status = 200, data = depPos });
        }

        [HttpPost]
        public IActionResult Create(DepartmentPositionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DepartmentPosition departmentPosition = new DepartmentPosition()
                    {
                        DepartmentId = Guid.Parse(model.DepartmentId),
                        PositionId = Guid.Parse(model.PositionId),
                        CreatedEmp = Guid.NewGuid().ToString(),
                        UpdatedEmp = Guid.NewGuid().ToString()
                    };
                    work.departmentPositionsrepo.Create(departmentPosition);
                    work.SaveChanges();
                    return Ok(new { status = 200, message = "Department with Position Created Successfully" });
                }
                return BadRequest(new { status = 422, message = "Model State is Invalid" });
            }
            catch (Exception e)
            {
                return Ok(new { status = 200, message = "Please Try Again" });
            }
        }
    }
}

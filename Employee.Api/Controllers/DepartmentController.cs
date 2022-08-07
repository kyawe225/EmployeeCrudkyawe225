using Employee.Api.ViewModel;
using Employee.DBA.Tables;
using Employee.DBA.Unit_Of_Work;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : Controller
    {
        private ILogger<DepartmentController> logger;
        private IUnitOfWork _worker { init; get; }
        public DepartmentController(IUnitOfWork worker,ILogger<DepartmentController> logger)
        {
            _worker = worker;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Departments = _worker.departmentsrepo.All();
            return Ok(new { status = 200, departments = Departments });
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Index(string id)
        {

            Guid guid = Guid.Parse(id);
            var Department = _worker.departmentsrepo.GetById(guid);
            return Ok(new { status = 200, Department = Department });
        }
        [HttpPost]
        public IActionResult Create([FromBody] DepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Department Department = new Department()
                    {
                        Name = model.Name,
                        CreatedEmp = Guid.NewGuid().ToString(),
                        UpdatedEmp = Guid.NewGuid().ToString()
                    };
                    _worker.departmentsrepo.Create(Department);
                    _worker.SaveChanges();
                    return Ok(new { status = 200, message = "Successfully Created" });
                }
                return BadRequest(new { status = 400, message = "Successfully Created" });
            }
            catch(Exception e)
            {
                logger.LogDebug(e.Message);
                return Ok(new { status = 200, message = "fail to create" });
            }
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(string id,DepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Guid guid = Guid.Parse(id);
                    var Departments = _worker.departmentsrepo.GetById(guid);
                    Departments.Name = model.Name;
                    _worker.departmentsrepo.Update(Departments);
                    _worker.SaveChanges();
                    return Ok(new { status = 200, Departments = Departments });
                }
                return BadRequest(new { status = 400, message = "Fail to Update" });
            }catch(Exception e)
            {
                logger.LogDebug(e.Message);
                return Ok(new { status = 200, message = "Department Not Found" });
            }
            
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Guid guid = Guid.Parse(id);
                    var Departments = _worker.departmentsrepo.GetById(guid);
                    _worker.departmentsrepo.Delete(Departments);
                    _worker.SaveChanges();
                    return Ok(new { status = 200, Departments = Departments });
                }
                return BadRequest(new { status = 400, message = "Fail to Update" });
            }
            catch (Exception e)
            {
                logger.LogDebug(e.Message);
                return Ok(new { status = 200, message = "Department Not Found" });
            }
        }
    }
}

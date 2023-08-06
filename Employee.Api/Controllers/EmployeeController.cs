using Employee.DBA.Unit_Of_Work;
using Microsoft.AspNetCore.Mvc;
using Employee.Api.ViewModel;
using Employee.DBA.Tables;
using Employee.Api.Services;
using Employee.DBA;

namespace Employee.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private IUnitOfWork unitOfWork { set; get; }

        public EmployeeController(IUnitOfWork work)
        {
            unitOfWork = work;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //if (model == null)
            //{
            //    model = new EmployeeSearchViewModel();
            //}
            //IEnumerable<EmployeeDto> employees = unitOfWork.employeesrepo.search(model.DepartmentId, model.PositionId, model.Name, model.Id);
            IEnumerable<EmployeeDto> employees = unitOfWork.employeesrepo.search();

            if (employees.Count() == 0)
                return Ok(new { status = 400, message = "No Employee Found" });
            return Ok(new { status = 200, data = employees });
        }
        [HttpGet("Export")]
        public IActionResult Export(EmployeeSearchViewModel model)
        {
            if (model == null)
            {
                model = new EmployeeSearchViewModel();
            }
            byte[] arr = { };
            GenerateExcel generate = new GenerateExcel();
            
                List<EmployeeDto> employees = (List<EmployeeDto>)unitOfWork.employeesrepo.search(model.DepartmentId, model.PositionId, model.Name, model.Id);
                if (employees.Count() != 0)
                    arr = generate.Generate(employees);
            
            if(arr.Length == 0)
                return Ok(new { status = 400, message = "No Employee Found" });
            return File(arr, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Detail(string id)
        {
            Guid guid;
            bool check = Guid.TryParse(id, out guid);
            if (!check)
            {
                return BadRequest(new { status = 400, message = "Please fill the valid EmployeeId" });
            }
            var employee = unitOfWork.employeesrepo.GetById(guid);
            if (employee == null)
                return Ok(new { status = 400, message = "Employee Not Found" });
            return Ok(new { status = 200, data = employee });
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery]string id)
        {
            try
            {
                Guid guid;
                bool check = Guid.TryParse(id, out guid);
                if (!check)
                {
                    return BadRequest(new { status = 400, message = "Please fill the valid EmployeeId" });
                }
                var model = unitOfWork.employeesrepo.GetById(guid);
                unitOfWork.employeesrepo.Delete(model);
                unitOfWork.SaveChanges();
                return Ok(new { status = 200, data = "Successfully Deleted" });
            }
            catch (Exception e)
            {
                return Ok(new { status = 400, message = "No Employee Found" });
            }

        }
        [HttpPost]
        public IActionResult Create([FromBody] EmployeeCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeTable employee = new EmployeeTable()
                    {
                        LastName = model.LastName,
                        FirstName = model.FirstName,
                        FatherName = model.FatherName,
                        Email = model.Email,
                        Address = model.Address,
                        DOB = model.DOB.ToUniversalTime(),
                        CreatedEmp = Guid.NewGuid().ToString(),
                        UpdatedEmp = Guid.NewGuid().ToString()
                    };
                    unitOfWork.employeesrepo.Create(employee);
                    IList<EmployeeDepartmentPosition> depPosList = new List<EmployeeDepartmentPosition>();
                    foreach (Guid i in model.departmentPositionIds)
                    {
                        DepartmentPosition depPos = unitOfWork.departmentPositionsrepo.GetById(i);
                        if (depPos != null)
                        {
                            var empDepPos = new EmployeeDepartmentPosition()
                            {
                                DepartmentPositonId = depPos.Id,
                                EmployeeId = employee.Id,
                                CreatedEmp = Guid.NewGuid().ToString(),
                                UpdatedEmp = Guid.NewGuid().ToString()
                            };
                            depPosList.Add(empDepPos);
                        }
                    }
                    unitOfWork.employeeDepartmentPositionsrepo.CreateRange(depPosList);
                    unitOfWork.SaveChanges();
                    return Ok(new { status = 200, data = "Successfully Created" });
                }
                return BadRequest(new { status = 400, message = "Successfully Created" });
            }
            catch (Exception e)
            {
                return Ok(new { status = 400, message = "fail to create" });
            }
        }
        [HttpPut]
        [Route("{guid}")]
        public IActionResult Update(Guid guid, EmployeeCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeTable employee = unitOfWork.employeesrepo.GetById(guid);

                    employee.LastName = model.LastName;
                    employee.FirstName = model.FirstName;
                    employee.FatherName = model.FatherName;
                    employee.Email = model.Email;
                    employee.Address = model.Address;
                    employee.DOB = model.DOB;
                    employee.UpdatedEmp = Guid.NewGuid().ToString();
                    employee.UpdatedAt = DateTime.Now;
                    unitOfWork.employeesrepo.Update(employee);
                    IList<EmployeeDepartmentPosition> depPosList = new List<EmployeeDepartmentPosition>();
                    foreach (Guid i in model.departmentPositionIds)
                    {
                        DepartmentPosition depPos = unitOfWork.departmentPositionsrepo.GetById(i);
                        if (depPos != null)
                        {
                            var empDepPos = new EmployeeDepartmentPosition()
                            {
                                DepartmentPositonId = depPos.Id,
                                EmployeeId = employee.Id,
                                CreatedEmp = Guid.NewGuid().ToString(),
                                UpdatedEmp = Guid.NewGuid().ToString()
                            };
                            depPosList.Add(empDepPos);
                        }
                    }
                    unitOfWork.employeeDepartmentPositionsrepo.DeleteEmployeeRelatedPositions(employee);
                    unitOfWork.employeeDepartmentPositionsrepo.CreateRange(depPosList);
                    unitOfWork.SaveChanges();
                    return Ok(new { status = 200, message = "Successfully Created" });
                }
                return BadRequest(new { status = 400, message = "Successfully Created" });
            }
            catch (Exception e)
            {
                return Ok(new { status = 400, message = "fail to create" });
            }
        }
    }
}

using Employee.Api.ViewModel;
using Employee.DBA.Tables;
using Employee.DBA.Unit_Of_Work;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : Controller
    {
        private ILogger<PositionController> logger;
        private IUnitOfWork _worker { init; get; }
        public PositionController(IUnitOfWork worker,ILogger<PositionController> logger)
        {
            _worker = worker;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var positions = _worker.positionsrepo.All();
            return Ok(new { status = 200, positions = positions });
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Index(string id)
        {

            Guid guid = Guid.Parse(id);
            var position = _worker.positionsrepo.GetById(guid);
            return Ok(new { status = 200, position = position });
        }
        [HttpPost]
        public IActionResult Create([FromBody] PositionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Position position = new Position()
                    {
                        Name = model.Name,
                        CreatedEmp = Guid.NewGuid().ToString(),
                        UpdatedEmp = Guid.NewGuid().ToString()
                    };
                    _worker.positionsrepo.Create(position);
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
        public IActionResult Update(string id,PositionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Guid guid = Guid.Parse(id);
                    var positions = _worker.positionsrepo.GetById(guid);
                    positions.Name = model.Name;
                    _worker.positionsrepo.Update(positions);
                    _worker.SaveChanges();
                    return Ok(new { status = 200, positions = positions });
                }
                return BadRequest(new { status = 400, message = "Fail to Update" });
            }catch(Exception e)
            {
                logger.LogDebug(e.Message);
                return Ok(new { status = 200, message = "Position Not Found" });
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
                    var positions = _worker.positionsrepo.GetById(guid);
                    _worker.positionsrepo.Delete(positions);
                    _worker.SaveChanges();
                    return Ok(new { status = 200, positions = positions });
                }
                return BadRequest(new { status = 400, message = "Fail to Update" });
            }
            catch (Exception e)
            {
                logger.LogDebug(e.Message);
                return Ok(new { status = 200, message = "Position Not Found" });
            }
        }
    }
}

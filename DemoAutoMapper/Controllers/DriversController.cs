using AutoMapper;
using DemoAutoMapper.Models.DataModels;
using DemoAutoMapper.Models.IncomingModels;
using DemoAutoMapper.Models.OutgoingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ILogger<DriversController> _logger;

        private static List<Driver> drivers = new();
        private readonly IMapper _mapper; 

        public DriversController(ILogger<DriversController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllDrivers() 
        {
            var listDrivers = drivers.Where(d => d.Status == 1).ToList();
            var _drivers = _mapper.Map<IEnumerable<DriverDTO>>(listDrivers);
            return Ok(_drivers);
        }

        [HttpGet("{id}")]
        public IActionResult GetDriverById(Guid id)
        {
            var driver = drivers.FirstOrDefault(d => d.Id == id);
            if(driver == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<DriverDTO>(driver));
        }

        [HttpPost]
        public IActionResult CreateDriver(DriverForCreationDTO data) 
        {
            if (ModelState.IsValid)
            {
                var _driver = _mapper.Map<Driver>(data);
                _driver.Id = Guid.NewGuid();
                _driver.CreatedDate = DateTime.Now;
                _driver.UpdatedDate = DateTime.Now;
                _driver.Status = 1;
                drivers.Add(_driver);
                var newDriver = _mapper.Map<DriverDTO>(_driver);
                return CreatedAtAction("GetAllDrivers", new { _driver.Id}, newDriver);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpPut("{id}")]
        public IActionResult EditDriver(Guid id, DriverForEditingDTO data) 
        {
            if(id != data.Id)
            {
                return BadRequest();
            }
            var exsistingDriver = drivers.FirstOrDefault(d => d.Id == id);
            if(exsistingDriver == null)
            {
                return NotFound();
            }
            exsistingDriver = _mapper.Map<Driver>(data);
            exsistingDriver.Status = (from d in drivers where d.Id == id select d.Status).FirstOrDefault();
            exsistingDriver.CreatedDate = (from d in drivers where d.Id == id select d.CreatedDate).FirstOrDefault();
            exsistingDriver.UpdatedDate = DateTime.Now;
            var _driver = _mapper.Map<DriverDTO>(exsistingDriver);
            return Ok(exsistingDriver);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDriverById(Guid id) 
        { 
            var exsistingDriver = drivers.Where(d => d.Id == id).FirstOrDefault();
            if(exsistingDriver == null)
            {
                return NotFound();
            }
            exsistingDriver.Status = 0;
            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRMAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly List<EmployeeModel> employees;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            employees = new List<EmployeeModel>
            {
                new EmployeeModel{Id = 1, Name = "David"},
                new EmployeeModel{Id = 2, Name = "Lisa"},
                new EmployeeModel{Id = 3, Name = "Mia"}
            };
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetEmployees()
        { 
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetById/{id:min(1):max(100)}")]
        public IActionResult GetById(int id)
        {
            var result = employees.Find(x => x.Id == id);
            if (result != null)
                return Ok(result);
            return NotFound("Employee not found");
        }

        [HttpGet("Search")]
        public IActionResult SearchEmployee(int id, string name)
        {
            return Ok(id + " " + name);
        }


        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            var result = employees.First(x => x.Name == name);
            if (result != null)
                return Ok(result);
            return NotFound("Employee not found");
        }


        [HttpGet("ExceptionHandling")]
        public IActionResult ExceptionHandling(string input)
        {
            throw new NullReferenceException();
            //try
            //{
            //    throw new NullReferenceException();
            //}
            //catch(Exception ex)
            //{
            //    _logger.LogError(ex.StackTrace);
            //    _logger.LogError("input value = " + input)
            //    return BadRequest(ex.Message);
            //}
        }


        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using HRMAPI.Models;
using HRMMVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRMAPI.Controllers
{
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly ILogger<EmployeeController> _logger;
        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;

        }
        [HttpGet]
        public IActionResult GetCandidates()
        {
            var candidates = _candidateService.GetAllCandidates();
            return Ok(candidates);
        }

        [HttpGet]
        [Route("GetById/{id:min(1):max(100)}")]
        public async Task<IActionResult> GetById(int id)
        {
            var candidates = await _candidateService.GetCandidateByIdAsync(id);
            if (candidates != null)
                return Ok(candidates);
            return NotFound("Candidate Not Found");
        }

        [HttpGet("Search")]
        public IActionResult SearchCandidate(int id, string name)
        {
            return Ok(id + " " + name);
        }


        //[HttpGet("GetByName")]
        //public IActionResult GetByName(string name)
        //{
        //    var result = _candidateServi.First(x => x.Name == name);
        //    if (result != null)
        //        return Ok(result);
        //    return NotFound("Employee not found");
        //}
        [HttpGet("Add")]
        public async Task<int> AddCandidateAsync(CandidateRequestModel model)
        {
            // Get User By Email uses FirstorDefault which allows Null as return. 
            var existingCandidate = await _candidateService.AddCandidateAsync(model);
            if (existingCandidate != null)
            {
                throw new Exception("Email is already used");
            }
            CandidateRequestModel candidate = new CandidateRequestModel();
            if (model != null)
            {
                candidate.Id = model.Id;
                candidate.FirstName = model.FirstName;
                candidate.MiddleName = model.MiddleName;
                candidate.LastName = model.LastName;
                candidate.Email = model.Email;
                candidate.ResumeURL = model.ResumeURL;
            }
            //returns number of rows affected, typically 1
            return await _candidateService.AddCandidateAsync(candidate);
        }


        [HttpGet("ExceptionHandling")]
        public IActionResult ExceptionHandling(string input)
        {
            throw new NullReferenceException();
        }
    }
}


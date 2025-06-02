using CompanyEvaluationsAPI.Core_Layer.Interfaces;
using CompanyEvaluationsAPI.Infrastructure.Context;
using CompanyEvaluationsAPI.Infrastructure.Models;
using CompanyEvaluationsAPI.Infrastructure_Layer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyEvaluationsAPI.API_Layer.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService, DataContext context)
        {

            this.employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employees = await employeeService.GetEmployeesById(id);
            return Ok(employees);
        }



         [HttpPost("rate-colleagues/{raterId}")]
        public async Task<IActionResult> RateColleagues(int raterId, [FromBody] ICollection<RatedEmployeeInputDto> data)
        {
            var result = await employeeService.RateColleaguesAsync(raterId, data);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok("Ratings submitted successfully.");
        }

    }
}



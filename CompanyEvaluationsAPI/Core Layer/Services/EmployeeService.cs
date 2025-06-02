using CompanyEvaluationsAPI.Core_Layer.Interfaces;
using CompanyEvaluationsAPI.Infrastructure.Models;
using CompanyEvaluationsAPI.Infrastructure_Layer.Dto;
using CompanyEvaluationsAPI.Infrastructure_Layer.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CompanyEvaluationsAPI.Core_Layer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;
        public EmployeeService(IUnitOfWork uow) { 
        
            unitOfWork= uow;
        }


        //fetch employees
        public async Task<ICollection<EmployeeDto>> GetEmployeesById(int id) {
        
            return await unitOfWork.employee.GetEmployeesById(id);
        
        }


        //Rate Employees
        public async Task<(bool Success, string Message)> RateColleaguesAsync(int raterId, ICollection<RatedEmployeeInputDto> data)
        {
            //fetch employee to check if its in the database
            var rater = await FindEmployee(raterId);
            if (rater == null)
                return (false, "Rater not found.");

            
            //check if the employee rated him/her self
            var rateeIds = data.Select(d => d.RateeId).ToList();

            if (rateeIds.Contains(raterId))
                return (false, "Rater cannot rate themselves.");

            //global validation for consistency
            if (data.Any(d => d.Rate < 1 || d.Rate > 5))
                return (false, "All ratings must be between 1 and 5.");

            //check if all ids employee rated are valid
            var ratees = await GetEmployeesByIds(rateeIds);
            if (ratees.Count != data.Count)
                return (false, "One or more ratees not found.");

            //check if emplpoyee tried to rate another one from different department
            if (ratees.Any(e => e.DepartmentId != rater.DepartmentId))
                return (false, "All rated employees must be in the same department as the rater.");

            var ratings = data.Select(d => new Rating
            {
                RaterId = raterId,
                RateeId = d.RateeId,
                Score = d.Rate
            }).ToList();


            //if all valid then add rates and save them
            unitOfWork.rating.AddRange(ratings);
            int saved = await unitOfWork.Save();
            if (saved == 0)
                return (false, "CHANGES COULDN'T BE SAVED PROPERLY");
            return (true, null);
        }

        public async Task<Employee> FindEmployee(int id)
        {
            return await unitOfWork.employee.FindEmployee(id);
        }

        public async Task<bool> HasAlreadyRated(int raterId)
        {
            return await unitOfWork.employee.HasAlreadyRated(raterId);
        }

        public async Task<List<Employee>> GetEmployeesByIds(IEnumerable<int> ids)
        {
            return await unitOfWork.employee.GetEmployeesByIds(ids);
        }
    }
}

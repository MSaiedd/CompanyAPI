using CompanyEvaluationsAPI.Infrastructure.Models;
using CompanyEvaluationsAPI.Infrastructure_Layer.Dto;

namespace CompanyEvaluationsAPI.Core_Layer.Interfaces
{
    public interface IEmployeeService
    {
        //Task<bool> RateColleaguesInSameDepartmentAsync(EmployeeDto data);
        
        
        // get employee by id
        Task<ICollection<EmployeeDto>> GetEmployeesById(int id);
        
        //rate employees
        Task<(bool Success, string Message)> RateColleaguesAsync(int raterId, ICollection<RatedEmployeeInputDto> data);
    }
}

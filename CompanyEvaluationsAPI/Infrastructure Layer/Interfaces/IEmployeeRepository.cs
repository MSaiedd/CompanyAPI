using CompanyEvaluationsAPI.Infrastructure.Models;
using CompanyEvaluationsAPI.Infrastructure_Layer.Dto;

namespace CompanyEvaluationsAPI.Infrastructure.Interfaces
{
    public interface IEmployeeRepository
    {

        //fetch all employees by id (used in get request)
        public Task<ICollection<EmployeeDto>> GetEmployeesById(int id);

        //fetch single employee by id
        Task<Employee> FindEmployee(int id);

        //fetch all employees by id (used in post request)
        Task<List<Employee>> GetEmployeesByIds(IEnumerable<int> ids);
        
        //check if empolyee is already rated
        Task<bool> HasAlreadyRated(int raterId);
    }
}

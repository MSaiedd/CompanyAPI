
using CompanyEvaluationsAPI.Infrastructure.Context;
using CompanyEvaluationsAPI.Infrastructure.Interfaces;
using CompanyEvaluationsAPI.Infrastructure.Models;
using CompanyEvaluationsAPI.Infrastructure_Layer.Dto;
using Microsoft.EntityFrameworkCore;


namespace CompanyEvaluationsAPI.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext context;

        public EmployeeRepository(DataContext context) {

            this.context = context;
        }






        //fetch all employees by id (used in get request)
        public async Task<ICollection<EmployeeDto>> GetEmployeesById(int id)
        {

            return await context.Employees
                        .Where(a => a.Id == id)
                        .Select(e => new EmployeeDto
                        {
                            RaterName = e.Name,
                            RatedEmployees = e.GivenRatings
                            .Select(r => new RatedEmployeeDto
                            {
                                Name = r.Ratee.Name,
                                rate = r.Score
                            })
                            .ToList() }).ToListAsync();
        }


        //fetch all employees by id (used in post request)
        public async Task<List<Employee>> GetEmployeesByIds(IEnumerable<int> ids)
        {
            return await context.Employees
                .Where(e => ids.Contains(e.Id))
                .ToListAsync();
        }

        //fetch single employee by id
        public async Task<Employee> FindEmployee(int id) { 
        
            var emp = await context.Employees.FindAsync(id);
            if(emp == null)
                return null;
            return emp;
        }


        //check if empolyee is already rated
        public async Task<bool> HasAlreadyRated(int raterId)
        {
            return await context.Ratings.AnyAsync(r => r.RaterId == raterId);
        }

       


    }

    }

    





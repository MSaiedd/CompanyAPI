using CompanyEvaluationsAPI.Infrastructure.Models;
using CompanyEvaluationsAPI.Infrastructure_Layer.Dto;

namespace CompanyEvaluationsAPI.Infrastructure_Layer.Interfaces
{
    public interface IRatingRepository
    {
        void AddRange(ICollection<Rating> ratings);
        //Task<bool> RateColleaguesInSameDepartmentAsync(EmployeeDto data);

    }
}

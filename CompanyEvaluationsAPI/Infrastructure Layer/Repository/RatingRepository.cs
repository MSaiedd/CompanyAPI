using CompanyEvaluationsAPI.Infrastructure.Context;
using CompanyEvaluationsAPI.Infrastructure.Models;
using CompanyEvaluationsAPI.Infrastructure_Layer.Dto;
using CompanyEvaluationsAPI.Infrastructure_Layer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyEvaluationsAPI.Infrastructure_Layer.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly DataContext context;

        public RatingRepository(DataContext context)
        {

            this.context = context;
        }

        //add ratings to employees
        public async void AddRange(ICollection<Rating> ratings) {

            context.Ratings.AddRange(ratings);
        }


       /* public async Task<bool> RateColleaguesInSameDepartmentAsync(EmployeeDto data)
        {
            var rater = await context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == 1);

            if (rater == null)
                return false;

            // Fetch all colleagues in the same department except the rater
            var colleagues = await context.Employees
                .Where(e => e.DepartmentId == rater.DepartmentId && e.Id != 1)
                .ToListAsync();

            var ratings = colleagues.Select(c => new Rating
            {
                RaterId = 1,
                RateeId = c.Id,
                Score = 5,
            }).ToList();

            context.Ratings.AddRange(ratings);

            return true;
        }*/
    }
}

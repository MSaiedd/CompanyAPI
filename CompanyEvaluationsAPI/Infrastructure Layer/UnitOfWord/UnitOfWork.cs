

using CompanyEvaluationsAPI.Infrastructure.Context;
using CompanyEvaluationsAPI.Infrastructure.Interfaces;
using CompanyEvaluationsAPI.Infrastructure_Layer.Interfaces;
using CompanyEvaluationsAPI.Infrastructure_Layer.Interfaces.UnitOfWork;

namespace CompanyEvaluationsAPI.Infrastructure_Layer.UnitOfWord
{
    
    public class UnitOfWork : IUnitOfWork
    {
        public IEmployeeRepository employee { get; }
        public IRatingRepository  rating{ get; }

        private DataContext context;
        public UnitOfWork(
            DataContext context,
            IEmployeeRepository employeeRepository,
            IRatingRepository ratingRepository
            ) { 
            this.context=context;
            this.employee = employeeRepository;
            this.rating = ratingRepository;
            }
        
        //free unused data 
        public void Dispose()
        {
            context.Dispose();
        }

        //save changes in database
        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }
    }
}

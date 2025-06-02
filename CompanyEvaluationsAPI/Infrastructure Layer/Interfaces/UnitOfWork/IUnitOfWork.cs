using CompanyEvaluationsAPI.Infrastructure.Interfaces;

namespace CompanyEvaluationsAPI.Infrastructure_Layer.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IEmployeeRepository employee { get; }
        public IRatingRepository rating { get; }
        Task<int> Save();

    }
}

using CompanyEvaluationsAPI.Infrastructure.Models;

namespace CompanyEvaluationsAPI.Infrastructure_Layer.Models
{
    //DEPARTMENT ENTITY
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }

}


using CompanyEvaluationsAPI.Infrastructure_Layer.Models;

namespace CompanyEvaluationsAPI.Infrastructure.Models
{
    //EMPLOYEE ENTITY
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Rating> GivenRatings { get; set; }
        public ICollection<Rating> ReceivedRatings { get; set; }
    }


}

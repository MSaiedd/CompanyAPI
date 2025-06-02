using System.ComponentModel.DataAnnotations;

namespace CompanyEvaluationsAPI.Infrastructure_Layer.Dto
{
    public class EmployeeDto
    {
        [Required]
        [MaxLength(20,ErrorMessage ="MAX LENGTH = 20 CHARACTERS")]
        public string RaterName { get; set; }
        public List<RatedEmployeeDto> RatedEmployees { get; set; }
    }

}

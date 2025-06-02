using System.ComponentModel.DataAnnotations;

namespace CompanyEvaluationsAPI.Infrastructure_Layer.Dto
{
    public class RatedEmployeeInputDto
    {
        [Required]
        public int RateeId { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }
       
    }
}

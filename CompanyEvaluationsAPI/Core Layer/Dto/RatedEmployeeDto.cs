using System.ComponentModel.DataAnnotations;

namespace CompanyEvaluationsAPI.Infrastructure_Layer.Dto
{
    public class RatedEmployeeDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [Range(1,5)]
        public int rate{ get; set; }
    }
}


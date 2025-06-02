namespace CompanyEvaluationsAPI.Infrastructure.Models
{
    //RATING ENTITY
    public class Rating
    {
        public int Id { get; set; }

        public int RaterId { get; set; }
        public Employee Rater { get; set; }

        public int RateeId { get; set; }
        public Employee Ratee { get; set; }

        public int Score { get; set; } // e.g., 1-5
    }

}

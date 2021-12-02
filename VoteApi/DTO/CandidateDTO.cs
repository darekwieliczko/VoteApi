using System.ComponentModel.DataAnnotations;

namespace VoteApi.DTO
{
    public class CandidateDTO
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [MinLength(5)]
        public string SurName { get; set; }
        public int VoteQuantity { get; set; }
    }
    public class CandidateInsertDTO
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [MinLength(5)]
        public string SurName { get; set; }
    }
}

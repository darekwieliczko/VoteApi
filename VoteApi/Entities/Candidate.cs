using System.ComponentModel.DataAnnotations;

namespace VoteApi.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [MinLength(3)]
        public string SurName { get; set; }
        public int VoteQuantity { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;

namespace VoteApi.DTO
{
    public class VoterDTO
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [MinLength(5)]
        public string SurName { get; set; }
        public bool VoteDone { get; set; }
    }
    public class VoterInsertDTO
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [MinLength(5)]
        public string SurName { get; set; }
    }
}

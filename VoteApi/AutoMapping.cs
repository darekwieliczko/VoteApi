using AutoMapper;
using VoteApi.Entities;

namespace VoteApi
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Voter, DTO.VoterDTO>();
            CreateMap<DTO.VoterInsertDTO, Voter>();

            CreateMap<Candidate, DTO.CandidateDTO>();
            CreateMap<DTO.CandidateInsertDTO, Candidate>();
        }
    }
}

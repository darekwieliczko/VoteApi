using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using VoteApi.DTO;
using VoteApi.Entities;

namespace VoteApi.Services
{
    public interface IVoterService
    {
        public IEnumerable<VoterDTO> getList();
        public VoterDTO GetById(int id);
        public VoterDTO GetByName(string name);
        public int addNew(VoterInsertDTO candidate);
       
        public bool canVote(int id);
        public int addVote(int idCandidate);
        public void setVoted(int id);

    }
    public class VoterService : IVoterService
    {
        private readonly VoteDbContext _dbContext;
        private readonly IMapper _mapper;

        public VoterService(VoteDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext; 
            _mapper = mapper;   
        }

        public int addNew(VoterInsertDTO dto)
        {
            var voter = _mapper.Map<Voter>(dto);

            voter.VoteDone = false;

            _dbContext.Voters.Add(voter);
            _dbContext.SaveChanges();

            return voter.Id;
        }
        public int addVote(int idCandidate)
        {
            var candidate = _dbContext.Candidates.FirstOrDefault(x => x.Id == idCandidate);
            if (candidate == null)
                throw new KeyNotFoundException("Candidates not found");

            candidate.VoteQuantity++;

            _dbContext.SaveChanges();

            return candidate.VoteQuantity;

        }

        public void setVoted(int id)
        {
            var voter = _dbContext.Voters.FirstOrDefault(x => x.Id == id);
            if (voter == null)
                throw new KeyNotFoundException("Voter not found");

            voter.VoteDone = true;

            _dbContext.SaveChanges();

        }

        public bool canVote(int id)
        {
            var voter = _dbContext.Voters.FirstOrDefault(x => x.Id == id);
            if (voter == null)
                throw new KeyNotFoundException("Voter not found");

            return !voter.VoteDone;
        }

        public VoterDTO GetById(int id)
        {
            var voter = _dbContext.Voters.FirstOrDefault(x => x.Id == id);
            if (voter == null)
                throw new KeyNotFoundException("Voter not found");

            var result = _mapper.Map<VoterDTO>(voter);
            return result;
        }

        public VoterDTO GetByName(string name)
        {
            var voter = _dbContext.Voters.FirstOrDefault(x => x.Name.Contains(name));
            if (voter == null)
                throw new KeyNotFoundException("Voter not found");

            var result = _mapper.Map<VoterDTO>(voter);
            return result;
        }

        public IEnumerable<VoterDTO> getList()
        {
            var voters = _dbContext.Voters.ToList();
            var result = _mapper.Map<IEnumerable<VoterDTO>>(voters);

            return result;
        }
    }
}

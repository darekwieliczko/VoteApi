using System.Collections.Generic;
using VoteApi.DTO;
using VoteApi.Entities;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;

namespace VoteApi.Services
{
    public interface ICandidateServis
    {
        public IEnumerable<CandidateDTO> getList();
        public CandidateDTO GetById(int id);
        public CandidateDTO GetByName(string name);
        public int addNew(CandidateInsertDTO dto);
        public int voteQuantity(int id);

    }
    public class CandidateServis : ICandidateServis
    {
        private readonly VoteDbContext _dbContext;
        private readonly IMapper _mapper;

        public CandidateServis(VoteDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int addNew(CandidateInsertDTO dto)
        {
            var candidate = _mapper.Map<Candidate>(dto);

            candidate.VoteQuantity = 0;

            _dbContext.Candidates.Add(candidate);
            _dbContext.SaveChanges();

            return candidate.Id;
        }

        public int voteQuantity(int id)
        {
            var candidate = _dbContext.Candidates.FirstOrDefault(x => x.Id == id);
            if (candidate == null)
                throw new KeyNotFoundException("Candidates not found");

            return candidate.VoteQuantity;
        }

        public CandidateDTO GetById(int id)
        {
            var candidate = _dbContext.Candidates.FirstOrDefault(x => x.Id == id);
            if (candidate == null)
                throw new KeyNotFoundException("Candidates not found");

            var result = _mapper.Map<CandidateDTO>(candidate);
            return result;
        }

        public CandidateDTO GetByName(string name)
        {
            var candidate = _dbContext.Candidates.FirstOrDefault(x => x.Name.Contains(name));
            if (candidate == null)
                throw new KeyNotFoundException("Candidates not found");

            var result = _mapper.Map<CandidateDTO>(candidate);
            return result;
        }

        public IEnumerable<CandidateDTO> getList()
        {
            var candidates = _dbContext.Candidates.ToList();
            var result = _mapper.Map<IEnumerable<CandidateDTO>>(candidates);

            return result;
        }
    }
}

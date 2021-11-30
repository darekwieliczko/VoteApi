using System.Collections.Generic;
using VoteApi.DTO;
using VoteApi.Entities;

namespace VoteApi.Services
{
    interface ICandidateServis
    {
        public IEnumerable<Candidate> getList();
        public Candidate GetById(int id);
        public Candidate GetByName(string name);
        public bool addNew(CandidateDTO candidate);
    }
    public class CandidateServis : ICandidateServis
    {
        public bool addNew(CandidateDTO candidate)
        {
            throw new System.NotImplementedException();
        }

        public Candidate GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Candidate GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Candidate> getList()
        {
            throw new System.NotImplementedException();
        }
    }
}

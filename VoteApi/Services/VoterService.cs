using System.Collections.Generic;
using VoteApi.DTO;
using VoteApi.Entities;

namespace VoteApi.Services
{
    interface IVoterService
    {
        public IEnumerable<Voter> getList();
        public Voter GetById(int id);
        public Voter GetByName(string name);
        public bool addNew(VoterDTO candidate);

    }
    public class VoterService : IVoterService
    {
        public bool addNew(VoterDTO candidate)
        {
            throw new System.NotImplementedException();
        }

        public Voter GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Voter GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Voter> getList()
        {
            throw new System.NotImplementedException();
        }
    }
}

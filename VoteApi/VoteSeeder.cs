using AutoBogus;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VoteApi.Entities;

namespace VoteApi
{
    public class VoteSeeder
    {
        private readonly VoteDbContext _dbContext;

        public VoteSeeder(VoteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Voters.Any())
                {
                    var voters = GetVoters();
                    _dbContext.Voters.AddRange(voters);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Candidates.Any())
                {
                    var candidates = GetCandidates();
                    _dbContext.Candidates.AddRange(candidates);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Voter> GetVoters()
        {
            var id = 0;
            var votersFaker = new AutoFaker<Voter>()
              .RuleFor(fake => fake.Id, _ => id)
              .RuleFor(fake => fake.Name, fake => fake.Person.FirstName)
              .RuleFor(fake => fake.SurName, fake => fake.Person.LastName)
              .Generate(15);

            return votersFaker.AsEnumerable();
        }

        private IEnumerable<Candidate> GetCandidates()
        {
            var id = 0;
            var candidateFaker = new AutoFaker<Candidate>()
              .RuleFor(fake => fake.Id, _ => id)
              .RuleFor(fake => fake.Name, fake => fake.Person.FirstName)
              .RuleFor(fake => fake.SurName, fake => fake.Person.LastName)
              .Generate(5);

            return candidateFaker.AsEnumerable();
        }
    }
}

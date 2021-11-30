using Microsoft.EntityFrameworkCore;
using System;

namespace VoteApi.Entities
{
    public class VoteDbContext : DbContext
    {
        public VoteDbContext(DbContextOptions<VoteDbContext> options) : base(options)
        {

        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Voter> Voters { get; set; }


    }
}

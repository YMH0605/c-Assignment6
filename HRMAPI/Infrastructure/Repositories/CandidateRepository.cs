using System;
using System.Linq.Expressions;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        

        public CandidateRepository(RecruitingDbContext context) :base(context)
        {
           
        }

        public async Task<Candidate> FirstOrDefaultWithIncludesAsync(Expression<Func<Candidate, bool>> where, params Expression<Func<Candidate, object>>[] includes)
        {
            var query = _db.Set<Candidate>().AsQueryable();

            if (includes != null)
                foreach (var navigationProperty in includes)
                    query = query.Include(navigationProperty);

            return await query.FirstOrDefaultAsync(where);
        }

        public async Task<Candidate> GetUserByEmail(string email)
        {
            return await _db.Candidates.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}


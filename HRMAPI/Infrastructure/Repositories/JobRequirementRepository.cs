using System;
using System.Linq.Expressions;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class JobRequirementRepository : BaseRepository<JobRequirement>, IJobRequirementRepository
    {
        public JobRequirementRepository(RecruitingDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<JobRequirement>> GetJobRequirementsIncludingCategory(Expression<Func<JobRequirement, bool>> filter)
        {
            return await _db.JobRequirements.Include("JobCategory").Where(filter).ToListAsync();
        }
    }
}


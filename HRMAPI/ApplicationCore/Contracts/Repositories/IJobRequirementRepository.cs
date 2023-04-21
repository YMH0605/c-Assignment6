using System;
using ApplicationCore.Entities;
using System.Linq.Expressions;

namespace ApplicationCore.Contracts.Repositories
{
	public interface IJobRequirementRepository : IBaseRepository<JobRequirement>
    {
        public Task<IEnumerable<JobRequirement>> GetJobRequirementsIncludingCategory(Expression<Func<JobRequirement, bool>> filter);
    }
}


using System;
using ApplicationCore.Entities;
using System.Linq.Expressions;

namespace ApplicationCore.Contracts.Repositories
{
	public interface ISubmissionRepository : IBaseRepository<Submission>
	{
        public Task<Submission> FirstOrDefaultWithIncludesAsync(Expression<Func<Submission, bool>> where,
            params Expression<Func<Submission, object>>[] includes);
    }
}


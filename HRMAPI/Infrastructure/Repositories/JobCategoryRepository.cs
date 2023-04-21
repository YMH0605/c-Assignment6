using System;
using ApplicationCore.Entities;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class JobCategoryRepository : BaseRepository<JobCategory>, IJobCategoryRepository
    {
        public JobCategoryRepository(RecruitingDbContext context) : base(context)
        {
        }
    }
}


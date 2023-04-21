using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(RecruitingDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Status>> GetStatusByState(string state)
        {
            var statuses = await _db.Statuses.Where(s => s.State == state).Include(s => s.Submission).ToListAsync();
            return statuses;
        }
    }
}


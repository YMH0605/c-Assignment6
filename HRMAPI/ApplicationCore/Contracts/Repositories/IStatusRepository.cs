using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
	public interface IStatusRepository: IBaseRepository<Status>
	{
        public Task<IEnumerable<Status>> GetStatusByState(string state);
    }
}


using System;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface IJobRequirementService
	{
        Task<int> AddJobRequirementAsync(JobRequirementRequestModel model);

        Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model);

        Task<int> DeleteJobRequirementAsync(int id);

        Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirementsAsync();

        Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id);
    }
}


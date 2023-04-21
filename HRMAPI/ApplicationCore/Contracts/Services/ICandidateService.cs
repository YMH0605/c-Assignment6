using System;
using ApplicationCore.Models;
using HRMMVC.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface ICandidateService
	{
        Task<int> AddCandidateAsync(CandidateRequestModel model);

        Task<int> UpdateCandidateAsync(CandidateRequestModel model);

        Task<int> DeleteCandidateAsync(int id);

        //Task <CandidateInfoResponseModel> GetCandidateInfo(int id);

        Task<IEnumerable<CandidateResponseModel>> GetAllCandidates();

        Task<CandidateResponseModel> GetCandidateByIdAsync(int id);

    }
}


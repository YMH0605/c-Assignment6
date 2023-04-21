using System;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using HRMMVC.Models;

namespace Infrastructure.Helper
{
	public static class MapHelper
	{
		//public static Candidate CandidateRequestToCandidate(CandidateRequestModel can)
		//{
		//	return new Candidate
		//	{
		//		Id = can.Id,

		//		FirstName = can.FirstName,

		//		LastName = can.LastName,

		//		Email = can.Email,

		//		ResumeURL = can.ResumeURL,
				
				
		//	};
		//}


		public static CandidateResponseModel ToCandidateResponseModel(this Candidate candidate)
		{
			return new CandidateResponseModel
			{
				Id = candidate.Id,
				Email = candidate.Email,
				FirstName = candidate.FirstName,
				MiddleName = candidate.MiddleName,
				LastName = candidate.LastName,
				ResumeURL = candidate.ResumeURL
			};
		}


		public static EmployeeTypeResponseModel ToEmployeeTypeResponseModel(this EmployeeType empType)
		{
			return new EmployeeTypeResponseModel
			{
				Id = empType.Id,
				TypeName = empType.TypeName
			};
		}


		public static JobRequirementResponseModel ToJobRequirementResponseModel(this JobRequirement jR)
		{
			return new JobRequirementResponseModel
			{
				Id = jR.Id,
				NumberOfPosition = jR.NumberOfPosition,
				Title = jR.Title,
				Description = jR.Description,
				HiringManagerId = jR.HiringManagerId,
				HiringManagerName = jR.HiringManagerName,
				StartDate = jR.StartDate,
				IsActive = jR.IsActive,
				ClosedOn = jR.ClosedOn,
				ClosedReason = jR.ClosedReason,
				CreatedOn = jR.CreatedOn,
				JobCategoryId = jR.JobCategoryId

			};
		}

        public static StatusResponseModel ToStatusResponseModel(this Status status)
        {
            return new StatusResponseModel
            {
                Id = status.Id,
                SubmissionId = status.SubmissionId,
                State = status.State,
                ChangedOn = status.ChangedOn,
                StatusMessage = status.StatusMessage
            };
        }

        public static SubmissionResponseModel ToSubmissionResponseModel(this Submission sub)
        {
            return new SubmissionResponseModel
            {
                Id = sub.Id,
                JobRequirementId = sub.JobRequirementId,
                CandidateId = sub.CandidateId,
                SubmittedOn = sub.SubmittedOn,
                ConfirmedOn = sub.ConfirmedOn,
                RejectedOn = sub.RejectedOn,
                CurrentStatus = sub.CurrentStatus
            };
        }
    }
}


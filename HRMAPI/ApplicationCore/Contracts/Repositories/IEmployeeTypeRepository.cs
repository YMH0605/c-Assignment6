using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
	public interface IEmployeeTypeRepository : IBaseRepository<EmployeeType>
    {
        Task<EmployeeType> GetEmployeeTypeByTypeName(string typeName);
    }
}


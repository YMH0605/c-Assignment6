using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmployeeTypeRepository : BaseRepository<EmployeeType>, IEmployeeTypeRepository
    {
        public EmployeeTypeRepository(RecruitingDbContext context) : base(context)
        {
        }

        public async Task<EmployeeType> GetEmployeeTypeByTypeName(string typeName)
        {
            return await _db.EmployeeTypes.Where(x => x.TypeName == typeName.ToLower()).FirstOrDefaultAsync();
        }

        
    }
}


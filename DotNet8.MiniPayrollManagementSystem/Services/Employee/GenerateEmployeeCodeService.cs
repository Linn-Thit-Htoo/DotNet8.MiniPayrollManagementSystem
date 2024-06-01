using DotNet8.MiniPayrollManagementSystem.DbService.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.MiniPayrollManagementSystem.Api.Services.Employee
{
    public class GenerateEmployeeCodeService
    {
        private readonly AppDbContext _appDbContext;

        public GenerateEmployeeCodeService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> GenerateEmployeeCodeAsync()
        {
            try
            {
                var latestEmployeeCode = await _appDbContext.TblEmployees
                    .AsNoTracking()
                    .OrderByDescending(x => x.EmployeeCode)
                    .Select(x => x.EmployeeCode)
                    .FirstOrDefaultAsync();

                string newEmployeeCode = string.Empty;
                if (string.IsNullOrEmpty(latestEmployeeCode) || latestEmployeeCode is null)
                {
                    newEmployeeCode = "E00001";
                }
                else
                {
                    int numericPart = int.Parse(latestEmployeeCode!.Substring(1)) + 1;
                    newEmployeeCode = $"E{numericPart:D5}";
                }

                return newEmployeeCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using DotNet8.MiniPayrollManagementSystem.DbService.Entities;
using DotNet8.MiniPayrollManagementSystem.Models;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.MiniPayrollManagementSystem.Repositories.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<EmployeeListResponseModel> GetEmployeeListAsync()
        {
            try
            {
                var employees = await _appDbContext.TblEmployees
                    .AsNoTracking()
                    .OrderByDescending(x => x.EmployeeId)
                    .Where(x => x.IsActive)
                    .ToListAsync();

                var lst = employees.Select(x => x.Change()).ToList();
                var responseModel = new EmployeeListResponseModel()
                {
                    DataLst = lst
                };

                return responseModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

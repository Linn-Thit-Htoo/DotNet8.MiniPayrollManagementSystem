using DotNet8.MiniPayrollManagementSystem.DbService.Entities;
using DotNet8.MiniPayrollManagementSystem.Models;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.MiniPayrollManagementSystem.Api.Repositories.Payroll
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly AppDbContext _appDbContext;

        public PayrollRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<PayrollListResponseModel> GetPayrollByEmployeeAsync(string employeeCode)
        {
            try
            {
                PayrollListResponseModel responseModel = new();
                var dataLst = await _appDbContext.TblPayrolls
                    .AsNoTracking()
                    .OrderByDescending(x => x.PId)
                    .ToListAsync();

                var lst = dataLst.Select(x => x.Change()).ToList();
                responseModel.DataLst = lst;

                return responseModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<PayrollListResponseModel> GetPayrollByEmployeeAsync(string employeeCode, string fromDate, string toDate)
        {
            throw new NotImplementedException();
        }
    }
}

using DotNet8.MiniPayrollManagementSystem.Api.Services;
using DotNet8.MiniPayrollManagementSystem.DbService.Entities;
using DotNet8.MiniPayrollManagementSystem.Models;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.MiniPayrollManagementSystem.Api.Repositories.Payroll
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DapperService _dapperService;

        public PayrollRepository(AppDbContext appDbContext, DapperService dapperService)
        {
            _appDbContext = appDbContext;
            _dapperService = dapperService;
        }

        public async Task<IEnumerable<PayrollResponseModel>> GetPayrollListByEmployeeAsync(string employeeCode, string fromDate, string toDate)
        {
            try
            {
                string query = string.Empty;
                IEnumerable<PayrollResponseModel>? lst = null;

                // both from date & to date
                if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
                {
                    query = @"SELECT PId, Tbl_Payroll.EmployeeName, PayDate, GrossPay, NetPay,
DeductionAmount, BonusAmount, TaxAmount, EmployeeCode
FROM Tbl_Payroll
INNER JOIN Tbl_Employee ON Tbl_Employee.EmployeeCode = @EmployeeCode
WHERE PayDate >= @FromDate AND PayDate <= @ToDate
ORDER BY PId DESC
";
                    var parameters = new
                    {
                        EmployeeCode = employeeCode,
                        FromDate = fromDate,
                        ToDate = toDate
                    };
                    lst = await _dapperService
                       .QueryAsync<PayrollResponseModel>(query, parameters);
                }

                // only from date
                if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
                {
                    query = @"SELECT PId, Tbl_Payroll.EmployeeName, PayDate, GrossPay, NetPay,
DeductionAmount, BonusAmount, TaxAmount, EmployeeCode
FROM Tbl_Payroll
INNER JOIN Tbl_Employee ON Tbl_Employee.EmployeeCode = @EmployeeCode
WHERE PayDate >= @FromDate
ORDER BY PId DESC
";
                    var parameters = new
                    {
                        EmployeeCode = employeeCode,
                        FromDate = fromDate,
                    };
                    lst = await _dapperService
                       .QueryAsync<PayrollResponseModel>(query, parameters);
                }

                // only to date
                if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
                {
                    query = @"SELECT PId, Tbl_Payroll.EmployeeName, PayDate, GrossPay, NetPay,
DeductionAmount, BonusAmount, TaxAmount, EmployeeCode
FROM Tbl_Payroll
INNER JOIN Tbl_Employee ON Tbl_Employee.EmployeeCode = @EmployeeCode
WHERE PayDate <= @ToDate
ORDER BY PId DESC
";
                    var parameters = new
                    {
                        EmployeeCode = employeeCode,
                        ToDate = toDate,
                    };
                    lst = await _dapperService
                       .QueryAsync<PayrollResponseModel>(query, parameters);
                }

                // both null
                if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
                {
                    query = @"SELECT PId, Tbl_Payroll.EmployeeName, PayDate, GrossPay, NetPay,
DeductionAmount, BonusAmount, TaxAmount, EmployeeCode
FROM Tbl_Payroll
INNER JOIN Tbl_Employee ON Tbl_Employee.EmployeeCode = @EmployeeCode
ORDER BY PId DESC";
                    lst = await _dapperService
                        .QueryAsync<PayrollResponseModel>(query, new { EmployeeCode = employeeCode });
                }

                return lst!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CreatePayrollAsync(PayrollRequestModel requestModel)
        {
            try
            {
                bool doesEmployeeExist = await _appDbContext.TblEmployees
                    .AsNoTracking()
                    .AnyAsync(x => x.EmployeeName == requestModel.EmployeeName.Trim() && x.IsActive);
                if (!doesEmployeeExist)
                    throw new Exception("Employee with this name does not exist.");

                await _appDbContext.TblPayrolls.AddAsync(requestModel.Change());
                return await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

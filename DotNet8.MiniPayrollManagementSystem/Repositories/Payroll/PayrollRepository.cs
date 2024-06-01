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

        public async Task<IEnumerable<PayrollResponseModel>> GetPayrollListByEmployeeAsync(string employeeCode)
        {
            try
            {
                string query = @"SELECT PId, EmployeeName, PayDate, GrossPay, NetPay,
DeductionAmount, BonusAmount, TaxAmount, EmployeeCode
FROM Tbl_Payroll
INNER JOIN Tbl_Employee ON Tbl_Employee.EmployeeCode = @EmployeeCode
ORDERY BY PId DESC";
                IEnumerable<PayrollResponseModel> lst = await _dapperService
                    .QueryAsync<PayrollResponseModel>(query, new { EmployeeCode = employeeCode });

                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PayrollResponseModel>> FilterPayrollListByEmployeeAsync(string employeeCode, string fromDate, string toDate)
        {
            try
            {
                string query = string.Empty;
                IEnumerable<PayrollResponseModel>? lst = null;

                // both from date & to date
                if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
                {
                    query = @"SELECT PId, EmployeeName, PayDate, GrossPay, NetPay,
DeductionAmount, BonusAmount, TaxAmount, EmployeeCode
FROM Tbl_Payroll
INNER JOIN Tbl_Employee ON Tbl_Employee.EmployeeCode = @EmployeeCode
ORDERY BY PId DESC
WHERE PayDate >= @FromDate AND PayDate <= @ToDate";
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
                    query = @"SELECT PId, EmployeeName, PayDate, GrossPay, NetPay,
DeductionAmount, BonusAmount, TaxAmount, EmployeeCode
FROM Tbl_Payroll
INNER JOIN Tbl_Employee ON Tbl_Employee.EmployeeCode = @EmployeeCode
ORDERY BY PId DESC
WHERE PayDate >= @FromDate";
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
                    query = @"SELECT PId, EmployeeName, PayDate, GrossPay, NetPay,
DeductionAmount, BonusAmount, TaxAmount, EmployeeCode
FROM Tbl_Payroll
INNER JOIN Tbl_Employee ON Tbl_Employee.EmployeeCode = @EmployeeCode
ORDERY BY PId DESC
WHERE PayDate <= @ToDate";
                    var parameters = new
                    {
                        EmployeeCode = employeeCode,
                        ToDate = toDate,
                    };
                    lst = await _dapperService
                       .QueryAsync<PayrollResponseModel>(query, parameters);
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

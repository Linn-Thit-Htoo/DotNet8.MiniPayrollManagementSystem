using DotNet8.MiniPayrollManagementSystem.Api.Services;
using DotNet8.MiniPayrollManagementSystem.DbService.Entities;
using DotNet8.MiniPayrollManagementSystem.Models;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DotNet8.MiniPayrollManagementSystem.Api.Repositories.Payroll;

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
                var parameters = new
                {
                    EmployeeCode = employeeCode,
                    FromDate = fromDate,
                    ToDate = toDate
                };
                lst = await _dapperService
                   .QueryAsync<PayrollResponseModel>("Sp_FilterPayrollByFromDateToDateWithEmployeeCode", parameters,
                   commandType: CommandType.StoredProcedure);
            }

            // only from date
            if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                var parameters = new
                {
                    EmployeeCode = employeeCode,
                    FromDate = fromDate
                };
                lst = await _dapperService
                   .QueryAsync<PayrollResponseModel>("Sp_FilterPayrollByFromDateWithEmployeeCode", parameters,
                   commandType: CommandType.StoredProcedure);
            }

            // only to date
            if (!string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(fromDate))
            {
                var parameters = new
                {
                    EmployeeCode = employeeCode,
                    ToDate = toDate,
                };
                lst = await _dapperService
                   .QueryAsync<PayrollResponseModel>("Sp_FilterPayrollByToDateWithEmployeeCode", parameters,
                   commandType: CommandType.StoredProcedure);
            }

            // both null
            if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                lst = await _dapperService
                    .QueryAsync<PayrollResponseModel>("Sp_FilterPayrollByEmployeeCode"
                    , new { EmployeeCode = employeeCode},
                    commandType: CommandType.StoredProcedure);
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
                .AnyAsync(x => x.EmployeeName == requestModel.EmployeeName!.Trim() && x.IsActive);
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

    public async Task<int> DeletePayrollAsync(string pId)
    {
        try
        {
            var item = await _appDbContext.TblPayrolls
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PId == pId)
                ?? throw new Exception("No data found.");

            item.IsActive = false;
            _appDbContext.Entry(item).State = EntityState.Modified;

            return await _appDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> UpdatePayrollAsync(PayrollRequestModel requestModel, string pId)
    {
        try
        {
            var item = await _appDbContext.TblPayrolls
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PId == pId && x.IsActive)
                ?? throw new Exception("No data found.");

            if (!string.IsNullOrEmpty(requestModel.EmployeeName))
            {
                item.EmployeeName = requestModel.EmployeeName;
                var employee = await _appDbContext.TblEmployees
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.EmployeeName == requestModel.EmployeeName && x.IsActive)
                    ?? throw new Exception("Employee does not exist.");
            }

            if (!string.IsNullOrEmpty(requestModel.PayDate))
            {
                item.PayDate = requestModel.PayDate;
            }

            if (requestModel.GrossPay != 0)
            {
                item.GrossPay = requestModel.GrossPay;
            }

            if (requestModel.NetPay != 0)
            {
                item.NetPay = requestModel.NetPay;
            }

            if (requestModel.DeductionAmount != 0)
            {
                item.DeductionAmount = requestModel.DeductionAmount;
            }

            if (requestModel.BonusAmount != 0)
            {
                item.BonusAmount = requestModel.BonusAmount;
            }

            if (requestModel.TaxAmount != 0)
            {
                item.TaxAmount = requestModel.TaxAmount;
            }

            _appDbContext.Entry(item).State = EntityState.Modified;

            return await _appDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
using DotNet8.MiniPayrollManagementSystem.Api.Services.Employee;
using DotNet8.MiniPayrollManagementSystem.DbService.Entities;
using DotNet8.MiniPayrollManagementSystem.Models;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.MiniPayrollManagementSystem.Api.Repositories.Employee;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly GenerateEmployeeCodeService _generateEmployeeCodeService;

    public EmployeeRepository(AppDbContext appDbContext, GenerateEmployeeCodeService generateEmployeeCodeService)
    {
        _appDbContext = appDbContext;
        _generateEmployeeCodeService = generateEmployeeCodeService;
    }

    #region Get Employee List Async

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

    #endregion

    #region Create Employee Async

    public async Task<int> CreateEmployeeAsync(EmployeeRequestModel requestModel)
    {
        try
        {
            var dataModel = new TblEmployee
            {
                EmployeeName = requestModel.EmployeeName!,
                EmployeeCode = await _generateEmployeeCodeService.GenerateEmployeeCodeAsync(),
                Email = requestModel.Email!,
                PhoneNumber = requestModel.PhoneNumber!,
                HireDate = requestModel.HireDate!,
                Position = requestModel.Position!,
                Salary = requestModel.Salary,
                IsActive = true
            };
            await _appDbContext.TblEmployees.AddAsync(dataModel);

            return await _appDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion

    #region Delete Employee Async

    public async Task<int> DeleteEmployeeAsync(long id)
    {
        try
        {
            var item = await _appDbContext.TblEmployees
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EmployeeId == id)
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

    #endregion

    #region Update Employee Async

    public async Task<int> UpdateEmployeeAsync(EmployeeRequestModel requestModel, long id)
    {
        try
        {
            var item = await _appDbContext.TblEmployees
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EmployeeId == id && x.IsActive)
                ?? throw new Exception("No data found.");

            if (!string.IsNullOrEmpty(requestModel.EmployeeName))
            {
                item.EmployeeName = requestModel.EmployeeName;
            }

            if (!string.IsNullOrEmpty(requestModel.Email))
            {
                item.Email = requestModel.Email;
            }

            if (!string.IsNullOrEmpty(requestModel.PhoneNumber))
            {
                item.PhoneNumber = requestModel.PhoneNumber;
            }

            if (!string.IsNullOrEmpty(requestModel.HireDate))
            {
                item.HireDate = requestModel.HireDate;
            }

            if (!string.IsNullOrEmpty(requestModel.Position))
            {
                item.Position = requestModel.Position;
            }

            if (requestModel.Salary != default && requestModel.Salary != 0)
            {
                item.Salary = requestModel.Salary;
            }

            _appDbContext.Entry(item).State = EntityState.Modified;

            return await _appDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion
}
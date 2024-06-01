using DotNet8.MiniPayrollManagementSystem.Api.Validators.Employee;
using DotNet8.MiniPayrollManagementSystem.DbService.Entities;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace DotNet8.MiniPayrollManagementSystem.Api.Features.Employee;

public class BL_Employee
{
    private readonly DA_Employee _dA_Employee;
    private readonly EmployeeValidator _employeeValidator;
    private readonly AppDbContext _appDbContext;

    public BL_Employee(DA_Employee dA_Employee, EmployeeValidator employeeValidator, AppDbContext appDbContext)
    {
        _dA_Employee = dA_Employee;
        _employeeValidator = employeeValidator;
        _appDbContext = appDbContext;
    }

    public async Task<EmployeeListResponseModel> GetEmployeeListAsync()
    {
        return await _dA_Employee.GetEmployeeListAsync();
    }

    public async Task<int> CreateEmployeeAsync(EmployeeRequestModel requestModel)
    {
        ValidationResult validationResult = await _employeeValidator.ValidateAsync(requestModel);
        StringBuilder errors = new();

        if (!validationResult.IsValid)
        {
            validationResult.Errors.ForEach(err => errors.Append(err.ErrorMessage));
            throw new Exception(errors.ToString());
        }

        bool isEmailDuplicate = await _appDbContext.TblEmployees
            .AsNoTracking()
            .AnyAsync(x => x.Email == requestModel.Email && x.IsActive);
        if (isEmailDuplicate)
            throw new Exception("Employee with this email already exists.");

        return await _dA_Employee.CreateEmployeeAsync(requestModel);
    }
}
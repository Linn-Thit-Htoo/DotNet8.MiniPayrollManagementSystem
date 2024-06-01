﻿using DotNet8.MiniPayrollManagementSystem.Api.Services.Employee;
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

    public async Task<int> CreateEmployeeAsync(EmployeeRequestModel requestModel)
    {
        try
        {
            var dataModel = new TblEmployee
            {
                EmployeeName = requestModel.EmployeeName,
                EmployeeCode = await _generateEmployeeCodeService.GenerateEmployeeCodeAsync(),
                Email = requestModel.Email,
                PhoneNumber = requestModel.PhoneNumber,
                HireDate = requestModel.HireDate,
                Position = requestModel.Position,
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
}
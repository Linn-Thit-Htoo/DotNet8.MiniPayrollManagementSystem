﻿using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;

namespace DotNet8.MiniPayrollManagementSystem.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        Task<EmployeeListResponseModel> GetEmployeeListAsync();
    }
}
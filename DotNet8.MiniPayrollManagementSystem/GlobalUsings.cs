// Global using directives

global using System.Text;
global using DotNet8.MiniPayrollManagementSystem.Api.Commands.Employee.CreateEmployee;
global using DotNet8.MiniPayrollManagementSystem.Api.Commands.Employee.DeleteEmployee;
global using DotNet8.MiniPayrollManagementSystem.Api.Commands.Employee.UpdateEmployee;
global using DotNet8.MiniPayrollManagementSystem.Api.Queries.Employee.GetEmployeeListQuery;
global using DotNet8.MiniPayrollManagementSystem.Api.Repositories.Employee;
global using DotNet8.MiniPayrollManagementSystem.Api.Repositories.Payroll;
global using DotNet8.MiniPayrollManagementSystem.Api.Validators.Employee;
global using DotNet8.MiniPayrollManagementSystem.Api.Validators.Payroll;
global using DotNet8.MiniPayrollManagementSystem.DbService.Entities;
global using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
global using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
global using FluentValidation.Results;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Employee.CreateEmployee;

#region MyRegion

#endregion
public class CreateEmployeeCommand : IRequest<int>
{
    public EmployeeRequestModel EmployeeRequestModel { get; set; }
}
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Employee.UpdateEmployee;

public class UpdateEmployeeCommand : IRequest<int>
{
    public EmployeeRequestModel EmployeeRequestModel { get; set; }
    public long EmployeeId { get; set; }
}

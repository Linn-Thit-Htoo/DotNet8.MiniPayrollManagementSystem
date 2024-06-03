using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Employee.DeleteEmployee;

#region Delete Employee Command

#endregion
public class DeleteEmployeeCommand : IRequest<int>
{
    public long EmployeeId { get; set; }
}
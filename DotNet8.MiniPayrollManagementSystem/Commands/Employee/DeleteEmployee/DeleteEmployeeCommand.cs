namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Employee.DeleteEmployee;

#region Delete Employee Command

public class DeleteEmployeeCommand : IRequest<int>
{
    public long EmployeeId { get; set; }
}

#endregion
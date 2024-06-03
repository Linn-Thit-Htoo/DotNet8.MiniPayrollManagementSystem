using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Payroll.CreatePayroll;

#region Create Payroll Command

public class CreatePayrollCommand : IRequest<int>
{
    public PayrollRequestModel PayrollRequestModel { get; set; }
}

#endregion
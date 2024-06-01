using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Queries.Payroll.GetPayrollListByEmployeeQuery
{
    public class GetPayrollListByEmployeeQuery : IRequest<PayrollListResponseModel>
    {
        public string EmployeeCode { get; set; } = null!;
    }
}

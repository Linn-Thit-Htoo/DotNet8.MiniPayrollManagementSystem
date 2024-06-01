using DotNet8.MiniPayrollManagementSystem.Api.Queries.Payroll.GetPayrollListByEmployeeQuery;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Features.Payroll
{
    public class DA_Payroll
    {
        private readonly IMediator _mediator;

        public DA_Payroll(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<PayrollListResponseModel> GetPayrollByEmployeeAsync(string employeeCode)
        {
            try
            {
                var query = new GetPayrollListByEmployeeQuery() { EmployeeCode = employeeCode };
                return await _mediator.Send(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

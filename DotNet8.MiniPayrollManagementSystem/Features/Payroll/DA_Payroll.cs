using DotNet8.MiniPayrollManagementSystem.Api.Commands.Payroll.CreatePayroll;
using DotNet8.MiniPayrollManagementSystem.Api.Queries.Payroll.FilterPayrollListByEmployeeQuery;
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

        public async Task<IEnumerable<PayrollResponseModel>> GetPayrollByEmployeeAsync(string employeeCode)
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

        public async Task<int> CreatePayrollAsync(PayrollRequestModel requestModel)
        {
            try
            {
                var command = new CreatePayrollCommand() { PayrollRequestModel = requestModel };
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<PayrollResponseModel>> FilterPayrollListByEmployeeAsync(string employeeCode, string fromDate, string toDate)
        {
            var query = new FilterPayrollListByEmployeeQuery()
            {
                EmployeeCode = employeeCode,
                FromDate = fromDate,
                ToDate = toDate
            };

            return await _mediator.Send(query);
        }
    }
}

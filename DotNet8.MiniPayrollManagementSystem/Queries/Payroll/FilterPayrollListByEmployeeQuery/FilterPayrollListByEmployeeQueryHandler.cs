using DotNet8.MiniPayrollManagementSystem.Api.Repositories.Payroll;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Queries.Payroll.FilterPayrollListByEmployeeQuery
{
    public class FilterPayrollListByEmployeeQueryHandler
        : IRequestHandler<FilterPayrollListByEmployeeQuery, IEnumerable<PayrollResponseModel>>
    {
        private readonly IPayrollRepository _payrollRepository;

        public FilterPayrollListByEmployeeQueryHandler(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<IEnumerable<PayrollResponseModel>> Handle(FilterPayrollListByEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _payrollRepository.FilterPayrollListByEmployeeAsync(request.EmployeeCode, request.FromDate, request.ToDate);
        }
    }
}

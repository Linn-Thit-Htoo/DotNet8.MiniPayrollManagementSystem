using DotNet8.MiniPayrollManagementSystem.Api.Repositories.Payroll;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Queries.Payroll.GetPayrollListByEmployeeQuery
{
    public class GetPayrollListByEmployeeQueryHandler : IRequestHandler<GetPayrollListByEmployeeQuery, PayrollListResponseModel>
    {
        private readonly IPayrollRepository _payrollRepository;

        public GetPayrollListByEmployeeQueryHandler(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<PayrollListResponseModel> Handle(GetPayrollListByEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _payrollRepository.GetPayrollByEmployeeAsync(request.EmployeeCode);
        }
    }
}

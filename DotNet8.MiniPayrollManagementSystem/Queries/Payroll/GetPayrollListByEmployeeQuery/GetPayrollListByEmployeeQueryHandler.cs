using DotNet8.MiniPayrollManagementSystem.Api.Repositories.Payroll;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;

namespace DotNet8.MiniPayrollManagementSystem.Api.Queries.Payroll.GetPayrollListByEmployeeQuery;

#region Get Payroll List By Employee Query Handler

public class GetPayrollListByEmployeeQueryHandler : IRequestHandler<GetPayrollListByEmployeeQuery, IEnumerable<PayrollResponseModel>>
{
    private readonly IPayrollRepository _payrollRepository;

    public GetPayrollListByEmployeeQueryHandler(IPayrollRepository payrollRepository)
    {
        _payrollRepository = payrollRepository;
    }

    public async Task<IEnumerable<PayrollResponseModel>> Handle(GetPayrollListByEmployeeQuery request, CancellationToken cancellationToken)
    {
        return await _payrollRepository.GetPayrollListByEmployeeAsync(request.EmployeeCode, request.FromDate, request.ToDate);
    }
}

#endregion
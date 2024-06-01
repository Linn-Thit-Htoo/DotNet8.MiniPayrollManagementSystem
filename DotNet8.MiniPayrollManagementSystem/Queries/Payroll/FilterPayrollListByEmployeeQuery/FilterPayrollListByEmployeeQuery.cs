using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Queries.Payroll.FilterPayrollListByEmployeeQuery
{
    public class FilterPayrollListByEmployeeQuery : IRequest<IEnumerable<PayrollResponseModel>>
    {
        public string EmployeeCode { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}

using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
using DotNet8.MiniPayrollManagementSystem.Queries.Employee.GetEmployeeListQuery;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Features.Employee
{
    public class DA_Employee
    {
        private readonly IMediator _mediator;

        public DA_Employee(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<EmployeeListResponseModel> GetEmployeeListAsync()
        {
            try
            {
                var query = new GetEmployeeListQuery();
                var lst = await _mediator.Send(query);
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

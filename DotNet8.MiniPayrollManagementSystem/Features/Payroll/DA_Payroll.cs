namespace DotNet8.MiniPayrollManagementSystem.Api.Features.Payroll;

public class DA_Payroll
{
    private readonly IMediator _mediator;

    public DA_Payroll(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IEnumerable<PayrollResponseModel>> GetPayrollByEmployeeAsync(
        string employeeCode,
        string? fromDate = "",
        string? toDate = ""
    )
    {
        try
        {
            var query = new GetPayrollListByEmployeeQuery()
            {
                EmployeeCode = employeeCode,
                FromDate = fromDate,
                ToDate = toDate
            };
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

    public async Task<int> UpdatePayrollAsync(PayrollRequestModel requestModel, string pId)
    {
        try
        {
            var command = new UpdatePayrollCommand()
            {
                PayrollRequestModel = requestModel,
                PId = pId
            };
            return await _mediator.Send(command);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> DeletePayrollAsync(string pId)
    {
        try
        {
            var command = new DeletePayrollCommand() { PId = pId };
            return await _mediator.Send(command);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

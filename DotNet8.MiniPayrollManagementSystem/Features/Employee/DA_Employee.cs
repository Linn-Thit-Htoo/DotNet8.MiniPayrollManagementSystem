﻿namespace DotNet8.MiniPayrollManagementSystem.Api.Features.Employee;

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

    public async Task<int> CreateEmployeeAsync(EmployeeRequestModel requestModel)
    {
        try
        {
            var command = new CreateEmployeeCommand() { EmployeeRequestModel = requestModel };
            return await _mediator.Send(command);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> DeleteEmployeeAsync(long id)
    {
        try
        {
            var command = new DeleteEmployeeCommand() { EmployeeId = id };
            return await _mediator.Send(command);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> UpdateEmployeeAsync(EmployeeRequestModel requestModel, long id)
    {
        try
        {
            var command = new UpdateEmployeeCommand()
            {
                EmployeeId = id,
                EmployeeRequestModel = requestModel
            };
            return await _mediator.Send(command);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

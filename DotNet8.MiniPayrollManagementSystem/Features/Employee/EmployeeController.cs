using Microsoft.AspNetCore.Mvc;

namespace DotNet8.MiniPayrollManagementSystem.Api.Features.Employee;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly BL_Employee _bL_Employee;

    public EmployeeController(BL_Employee bL_Employee)
    {
        _bL_Employee = bL_Employee;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        try
        {
            var lst = await _bL_Employee.GetEmployeeListAsync();
            return Ok(lst);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
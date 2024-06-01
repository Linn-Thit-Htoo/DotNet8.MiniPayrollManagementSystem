using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet8.MiniPayrollManagementSystem.Api.Features;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IActionResult Content(object? obj)
    {
        return Content(JsonConvert.SerializeObject(obj), "application/json");
    }

    protected IActionResult InternalServerError(Exception ex)
    {
        return StatusCode(500, ex.Message);
    }

    protected IActionResult Created(string message)
    {
        return StatusCode(201, message);
    }

    protected IActionResult Accepted(string message)
    {
        return StatusCode(202, message);
    }
}
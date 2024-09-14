using BackendTestTask.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendTestTask.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecureExceptionController : Controller
{
    private readonly ISecurityExceptionLogService _securityExceptionLogService;

    public SecureExceptionController(ISecurityExceptionLogService securityExceptionLogService)
    {
        _securityExceptionLogService = securityExceptionLogService;
    }

    [HttpGet(Name = nameof(GetAll))]
    public async Task<IResult> GetAll(CancellationToken cancellationToken)
    {
        var logs = await _securityExceptionLogService.GetRange(cancellationToken);

        return TypedResults.Ok(logs);
    }
}

public abstract class BaseController : Controller
{
    protected readonly ILogger<BaseController> _logger;

    public BaseController(ILogger<BaseController> logger)
    {
        _logger = logger;
    }

    protected async Task<IActionResult> HandleExceptionAsync(Func<Task<IActionResult>> action)
    {
        try
        {
            return await action();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing the request");
            return BadRequest(new { error = ex.Message });
        }
    }

    protected bool ValidateModel(object model)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(new { errors });
        }
        return true;
    }

    // ... autres fonctionnalités communes (optionnelles)
}
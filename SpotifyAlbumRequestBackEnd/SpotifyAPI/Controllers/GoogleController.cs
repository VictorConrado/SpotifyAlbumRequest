using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/google")]
public class GoogleController : ControllerBase
{
    private readonly IGoogleClient _googleClient;

    public GoogleController(IGoogleClient googleClient)
    {
        _googleClient = googleClient;
    }

    [HttpGet("test")]
    public async Task<IActionResult> Test()
    {
        var result = await _googleClient.HelloWorld();
        return Ok(result);
    }
}

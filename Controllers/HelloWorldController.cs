using Microsoft.AspNetCore.Mvc;

namespace Platzi___API_Rest.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    public HelloWorldController(IHelloWorldService helloWorld)
    {
        helloWorldService = helloWorld;
    }

    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }
}
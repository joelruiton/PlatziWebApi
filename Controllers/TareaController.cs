using Microsoft.AspNetCore.Mvc;
using Platzi___API_Rest.Models;
using Platzi___API_Rest.Services;

namespace Platzi___API_Rest.Controllers;
[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareaService tareaService;

    public TareaController(ITareaService service)
    {
        tareaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareaService.Get());
    }
}
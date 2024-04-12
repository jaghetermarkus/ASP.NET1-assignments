using DataStore.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController(DataContext context) : ControllerBase
{
    public readonly DataContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var services = await _context.Services.ToListAsync();
            return Ok(services);
        }
        catch { }
        return Problem();
    }

}

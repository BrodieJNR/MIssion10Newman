using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MIssion10Newman.Data;

namespace MIssion10Newman.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BowlersController : ControllerBase
{
    private readonly BowlingContext _context;

    public BowlersController(BowlingContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetBowlers()
    {
        var bowlers = await _context.Bowlers
            .Include(b => b.Team)
            .Where(b => b.Team!.TeamName == "Marlins" || b.Team!.TeamName == "Sharks")
            .Select(b => new
            {
                b.BowlerFirstName,
                b.BowlerMiddleInit,
                b.BowlerLastName,
                TeamName = b.Team!.TeamName,
                b.BowlerAddress,
                b.BowlerCity,
                b.BowlerState,
                b.BowlerZip,
                b.BowlerPhoneNumber
            })
            .ToListAsync();

        return Ok(bowlers);
    }
}

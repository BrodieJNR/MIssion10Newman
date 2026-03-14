using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MIssion10Newman.Models;

namespace MIssion10Newman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlersController : ControllerBase
    {
        private readonly BowlingLeagueContext _context;

        public BowlersController(BowlingLeagueContext context)
        {
            _context = context;
        }

        // GET: api/Bowlers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetBowlers()
        {
            var bowlers = await _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
                .Select(b => new
                {
                    bowlerId = b.BowlerId,
                    firstName = b.BowlerFirstName,
                    middleInit = b.BowlerMiddleInit,
                    lastName = b.BowlerLastName,
                    teamName = b.Team.TeamName,
                    address = b.BowlerAddress,
                    city = b.BowlerCity,
                    state = b.BowlerState,
                    zip = b.BowlerZip,
                    phoneNumber = b.BowlerPhoneNumber
                })
                .ToListAsync();

            return Ok(bowlers);
        }
    }
}

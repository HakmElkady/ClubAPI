using Club.Data;
using Club.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClubController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClubs()
        {
            return Ok(await _context.Club.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllClubs(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Enter Valid Id !");
            }

            var result = await _context.Club.FindAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPost]
       public async Task<IActionResult> AddClub([FromBody] ClubDTO club)
        {
            if(club.ClubId < 0)
                return BadRequest("Id Not Valid");


            var result = await _context.Club.FirstOrDefaultAsync(x=> x.ClubId == club.ClubId);
            if (result is not null) 
            {
                return BadRequest("Club Is Already Exist !!!");
            }

            var c = new Clubs
            {
                ClubName = club.ClubName,
                Code = club.Code,
                PingTime = DateTime.Now,
                 
            };

            await _context.Club.AddAsync(c);
            await _context.SaveChangesAsync();
            return Ok(result);


        }

        [HttpPut]
        public async Task<IActionResult> UpdateClub(ClubDTO club)
        {
            var result = await _context.Club.FirstOrDefaultAsync(x => x.ClubId == club.ClubId);
            if (result is null || club.ClubId <= 0)
            {
                return NotFound("The Club Id Not Found !!!");

            }



            var c = new Clubs
            {
                ClubName = club.ClubName,
                Code = club.Code,

            };

            _context.Club.Update(c);
            await _context.SaveChangesAsync();
            return Ok(c);




        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub(int id)
        {

            var result = await _context.Club.FirstOrDefaultAsync(x => x.ClubId == id);

            if (result is null)
            {
                return BadRequest();
            }

            _context.Club.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();

        }

    }
}

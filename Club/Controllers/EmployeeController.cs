using Club.Data;
using Club.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _context.Employee.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            if (id <= 0)
            {
                return NotFound("The Employee Id Not Exist !!!");
            }

            var result = await _context.Employee.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (result == null)
            {
                return NotFound("The Employee Id Not Found !!!");
            }


            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDTO DTO)
        {
            if (DTO.EmployeeId > 0)
            {
                return NotFound("ID Must Be Zero (0)");
            }

            var result = await _context.Employee.FindAsync(DTO.EmployeeId);
            if (result is not null)
            {

                return BadRequest("Employee Is already Exist");

            }

            var emp = new Employee
            {

                Address = DTO.Address,
                BirthDate = DTO.BirthDate,
                Clubid = DTO.Clubid,
                FirstName = DTO.FirstName,
                LastName = DTO.LastName,
                Gender = DTO.Gender,
                Salary = DTO.Salary

            };

            await _context.Employee.AddAsync(emp);
            await _context.SaveChangesAsync();
            return Ok(emp);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDTO DTO)
        {
            var result = await _context.Employee.FirstOrDefaultAsync(x => x.EmployeeId == DTO.EmployeeId);
            if (result is null || DTO.EmployeeId <= 0)
            {
                return NotFound("The Employee Id Not Found !!!");

            }

            var emp = new Employee
            {

                Address = DTO.Address,
                BirthDate = DTO.BirthDate,
                Clubid = DTO.Clubid,
                FirstName = DTO.FirstName,
                LastName = DTO.LastName,
                Gender = DTO.Gender,
                Salary = DTO.Salary

            };

            _context.Employee.Update(emp);
            await _context.SaveChangesAsync();
            return Ok(emp);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {

            var result = await _context.Employee.FirstOrDefaultAsync(x => x.EmployeeId == id);

            if (result is null)
            {
                return BadRequest();
            }

            _context.Employee.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}

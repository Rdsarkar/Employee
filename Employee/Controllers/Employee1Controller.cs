using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee.Models;
using Employee.DTOs;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee1Controller : ControllerBase
    {
        private readonly ModelContext _context;

        public Employee1Controller(ModelContext context)
        {
            _context = context; 
                 
        }

        // GET: api/Employee1
        [HttpGet]
      
        public async Task<ActionResult<ResponseDto>> GetEmployee1s()
        {
            //return await _context.Employee1s.ToListAsync();
            List<Employee1> employee1s = await _context.Employee1s.ToListAsync();




            if (employee1s.Count <=0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
                {
                    Message = "Not Found",
                    Success = false,
                    Payload = null
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseDto
                {
                    Message = "Finally I have done this",
                    Success = true,
                    Payload = employee1s
                });
            }
        }

        // GET: api/Employee1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee1>> GetEmployee1(decimal? id)
        {
            return await _context.Employee1s.FindAsync(id);
        }

        // PUT: api/Employee1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee1(decimal? id, Employee1 employee1)
        {
            _context.Entry(employee1).State = EntityState.Modified;
            if (id != employee1.Id) 
            {
                return BadRequest();
            }
            await _context.SaveChangesAsync();
            return Ok();
            
        }

        // POST: api/Employee1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee1>> PostEmployee1(Employee1 employee1)
        {
            _context.Employee1s.Add(employee1);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Employee1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee1(decimal? id)
        {
            var employee1 = await _context.Employee1s.FindAsync(id);
            if (employee1 == null)
            {
                return BadRequest();
            }
            _context.Employee1s.Remove(employee1);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool Employee1Exists(int id)
        {
            return _context.Employee1s.Any(e => e.Id == id);
        }
    }
}

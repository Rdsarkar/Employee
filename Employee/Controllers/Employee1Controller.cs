using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee.Models;

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
        public async Task<ActionResult<IEnumerable<Employee1>>> GetEmployee1s()
        {
            return await _context.Employee1s.OrderBy(raj => raj.Id).ToListAsync();
        }

        // GET: api/Employee1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee1>> GetEmployee1(int id)
        {
            var employee1 = await _context.Employee1s.FindAsync(id);

            if (employee1 == null)
            {
                return NotFound();
            }

            return employee1;
        }

        // PUT: api/Employee1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee1(int id, Employee1 employee1)
        {
            if (id != employee1.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employee1Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employee1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee1>> PostEmployee1(Employee1 employee1)
        {
            _context.Employee1s.Add(employee1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee1", new { id = employee1.Id }, employee1);
        }

        // DELETE: api/Employee1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee1(int id)
        {
            var employee1 = await _context.Employee1s.FindAsync(id);
            if (employee1 == null)
            {
                return NotFound();
            }

            _context.Employee1s.Remove(employee1);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Employee1Exists(int id)
        {
            return _context.Employee1s.Any(e => e.Id == id);
        }
    }
}

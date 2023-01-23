using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T_Api_Time.Models;
using T_Api_Time.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace T_Api_Time.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly T_Api_TimeContext _dbContext;

        public StudentController(T_Api_TimeContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            if (_dbContext.Students is null)
                return NotFound();
            return await _dbContext.Students.ToListAsync();
        }

        // GET by Id action
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(long id)
        {
            if (_dbContext.Students is null)
                return NotFound();
            var student = await _dbContext.Students.FindAsync(id);
            if (student is null)
                return NotFound();
            return Ok(student);
        }


        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudent(int id, Student student)
        {
            if (id != student.Id)
                return BadRequest();
            _dbContext.Entry(student).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!StudentExists(id))
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

        private bool StudentExists(int id)
        {
            return (_dbContext.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(long id)
        {
            if (_dbContext.Students is null)
                return NotFound();

            var student = await _dbContext.Students.FindAsync(id);
            if (student is null)
                return NotFound();
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

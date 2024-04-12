using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apisaude.Context;
using apisaude.Models;

namespace apisaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassMedController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassMedController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ClassMed
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassMed>>> GetClassMeds()
        {
          if (_context.ClassMeds == null)
          {
              return NotFound();
          }
            return await _context.ClassMeds.ToListAsync();
        }

        // GET: api/ClassMed/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassMed>> GetClassMed(int id)
        {
          if (_context.ClassMeds == null)
          {
              return NotFound();
          }
            var classMed = await _context.ClassMeds.FindAsync(id);

            if (classMed == null)
            {
                return NotFound();
            }

            return classMed;
        }

        // PUT: api/ClassMed/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassMed(int id, ClassMed classMed)
        {
            if (id != classMed.CodClasse)
            {
                return BadRequest();
            }

            _context.Entry(classMed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassMedExists(id))
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

        // POST: api/ClassMed
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassMed>> PostClassMed(ClassMed classMed)
        {
          if (_context.ClassMeds == null)
          {
              return Problem("Entity set 'AppDbContext.ClassMeds'  is null.");
          }
            _context.ClassMeds.Add(classMed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassMed", new { id = classMed.CodClasse }, classMed);
        }

        // DELETE: api/ClassMed/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassMed(int id)
        {
            if (_context.ClassMeds == null)
            {
                return NotFound();
            }
            var classMed = await _context.ClassMeds.FindAsync(id);
            if (classMed == null)
            {
                return NotFound();
            }

            _context.ClassMeds.Remove(classMed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassMedExists(int id)
        {
            return (_context.ClassMeds?.Any(e => e.CodClasse == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vsc_webapi_dr.Models;

namespace vsc_webapi_dr.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Dbfiles")]
    public class DbfilesController : Controller
    {
        private readonly DailyReportsDevContext _context;

        public DbfilesController(DailyReportsDevContext context)
        {
            _context = context;
        }

        // GET: api/Dbfiles
        [HttpGet]
        public IEnumerable<Dbfile> GetDbfile()
        {
            return _context.Dbfile;
        }

        // GET: api/Dbfiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDbfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbfile = await _context.Dbfile.SingleOrDefaultAsync(m => m.Id == id);

            if (dbfile == null)
            {
                return NotFound();
            }

            return Ok(dbfile);
        }

        // PUT: api/Dbfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbfile([FromRoute] int id, [FromBody] Dbfile dbfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dbfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(dbfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbfileExists(id))
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

        // POST: api/Dbfiles
        [HttpPost]
        public async Task<IActionResult> PostDbfile([FromBody] Dbfile dbfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Dbfile.Add(dbfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDbfile", new { id = dbfile.Id }, dbfile);
        }

        // DELETE: api/Dbfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDbfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbfile = await _context.Dbfile.SingleOrDefaultAsync(m => m.Id == id);
            if (dbfile == null)
            {
                return NotFound();
            }

            _context.Dbfile.Remove(dbfile);
            await _context.SaveChangesAsync();

            return Ok(dbfile);
        }

        private bool DbfileExists(int id)
        {
            return _context.Dbfile.Any(e => e.Id == id);
        }
    }
}
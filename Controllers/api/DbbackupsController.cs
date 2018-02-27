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
    [Route("api/Dbbackups")]
    public class DbbackupsController : Controller
    {
        private readonly DailyReportsDevContext _context;

        public DbbackupsController(DailyReportsDevContext context)
        {
            _context = context;
        }

        // GET: api/Dbbackups
        [HttpGet]
        public IEnumerable<Dbbackup> GetDbbackup()
        {
            return _context.Dbbackup;
        }

        // GET: api/Dbbackups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDbbackup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbbackup = await _context.Dbbackup.SingleOrDefaultAsync(m => m.Id == id);

            if (dbbackup == null)
            {
                return NotFound();
            }

            return Ok(dbbackup);
        }

        // PUT: api/Dbbackups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbbackup([FromRoute] int id, [FromBody] Dbbackup dbbackup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dbbackup.Id)
            {
                return BadRequest();
            }

            _context.Entry(dbbackup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbbackupExists(id))
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

        // POST: api/Dbbackups
        [HttpPost]
        public async Task<IActionResult> PostDbbackup([FromBody] Dbbackup dbbackup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Dbbackup.Add(dbbackup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDbbackup", new { id = dbbackup.Id }, dbbackup);
        }

        // DELETE: api/Dbbackups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDbbackup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbbackup = await _context.Dbbackup.SingleOrDefaultAsync(m => m.Id == id);
            if (dbbackup == null)
            {
                return NotFound();
            }

            _context.Dbbackup.Remove(dbbackup);
            await _context.SaveChangesAsync();

            return Ok(dbbackup);
        }

        private bool DbbackupExists(int id)
        {
            return _context.Dbbackup.Any(e => e.Id == id);
        }
    }
}
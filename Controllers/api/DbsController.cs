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
    [Route("api/Dbs")]
    public class DbsController : Controller
    {
        private readonly DailyReportsDevContext _context;

        public DbsController(DailyReportsDevContext context)
        {
            _context = context;
        }

        // GET: api/Dbs
        [HttpGet]
        public IEnumerable<Db> GetDb()
        {
            return _context.Db;
        }

        // GET: api/Dbs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDb([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var db = await _context.Db.SingleOrDefaultAsync(m => m.Id == id);

            if (db == null)
            {
                return NotFound();
            }

            return Ok(db);
        }

        // PUT: api/Dbs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDb([FromRoute] int id, [FromBody] Db db)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != db.Id)
            {
                return BadRequest();
            }

            _context.Entry(db).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbExists(id))
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

        // POST: api/Dbs
        [HttpPost]
        public async Task<IActionResult> PostDb([FromBody] Db db)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Db.Add(db);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDb", new { id = db.Id }, db);
        }

        // DELETE: api/Dbs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDb([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var db = await _context.Db.SingleOrDefaultAsync(m => m.Id == id);
            if (db == null)
            {
                return NotFound();
            }

            _context.Db.Remove(db);
            await _context.SaveChangesAsync();

            return Ok(db);
        }

        private bool DbExists(int id)
        {
            return _context.Db.Any(e => e.Id == id);
        }
    }
}
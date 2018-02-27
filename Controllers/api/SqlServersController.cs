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
    [Route("api/SqlServers")]
    public class SqlServersController : Controller
    {
        private readonly DailyReportsDevContext _context;

        public SqlServersController(DailyReportsDevContext context)
        {
            _context = context;
        }

        // GET: api/SqlServers
        [HttpGet]
        public IEnumerable<SqlServer> GetSqlServer()
        {
            return _context.SqlServer;
        }

        // GET: api/SqlServers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSqlServer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sqlServer = await _context.SqlServer.SingleOrDefaultAsync(m => m.InstanceId == id);

            if (sqlServer == null)
            {
                return NotFound();
            }

            return Ok(sqlServer);
        }

        // PUT: api/SqlServers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSqlServer([FromRoute] string id, [FromBody] SqlServer sqlServer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sqlServer.InstanceId)
            {
                return BadRequest();
            }

            _context.Entry(sqlServer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SqlServerExists(id))
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

        // POST: api/SqlServers
        [HttpPost]
        public async Task<IActionResult> PostSqlServer([FromBody] SqlServer sqlServer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SqlServer.Add(sqlServer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SqlServerExists(sqlServer.InstanceId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSqlServer", new { id = sqlServer.InstanceId }, sqlServer);
        }

        // DELETE: api/SqlServers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSqlServer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sqlServer = await _context.SqlServer.SingleOrDefaultAsync(m => m.InstanceId == id);
            if (sqlServer == null)
            {
                return NotFound();
            }

            _context.SqlServer.Remove(sqlServer);
            await _context.SaveChangesAsync();

            return Ok(sqlServer);
        }

        private bool SqlServerExists(string id)
        {
            return _context.SqlServer.Any(e => e.InstanceId == id);
        }
    }
}
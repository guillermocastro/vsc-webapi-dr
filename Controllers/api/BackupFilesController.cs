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
    [Route("api/BackupFiles")]
    public class BackupFilesController : Controller
    {
        private readonly DailyReportsDevContext _context;

        public BackupFilesController(DailyReportsDevContext context)
        {
            _context = context;
        }

        // GET: api/BackupFiles
        [HttpGet]
        public IEnumerable<BackupFile> GetBackupFile()
        {
            return _context.BackupFile;
        }

        // GET: api/BackupFiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBackupFile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var backupFile = await _context.BackupFile.SingleOrDefaultAsync(m => m.Id == id);

            if (backupFile == null)
            {
                return NotFound();
            }

            return Ok(backupFile);
        }

        // PUT: api/BackupFiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBackupFile([FromRoute] int id, [FromBody] BackupFile backupFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != backupFile.Id)
            {
                return BadRequest();
            }

            _context.Entry(backupFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BackupFileExists(id))
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

        // POST: api/BackupFiles
        [HttpPost]
        public async Task<IActionResult> PostBackupFile([FromBody] BackupFile backupFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BackupFile.Add(backupFile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBackupFile", new { id = backupFile.Id }, backupFile);
        }

        // DELETE: api/BackupFiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBackupFile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var backupFile = await _context.BackupFile.SingleOrDefaultAsync(m => m.Id == id);
            if (backupFile == null)
            {
                return NotFound();
            }

            _context.BackupFile.Remove(backupFile);
            await _context.SaveChangesAsync();

            return Ok(backupFile);
        }

        private bool BackupFileExists(int id)
        {
            return _context.BackupFile.Any(e => e.Id == id);
        }
    }
}
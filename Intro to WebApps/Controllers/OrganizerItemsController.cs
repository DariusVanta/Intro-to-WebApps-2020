using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Intro_to_WebApps.Models;

namespace Intro_to_WebApps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizerItemsController : ControllerBase
    {
        private readonly OrganizersContext _context;

        public OrganizerItemsController(OrganizersContext context)
        {
            _context = context;
        }

        // GET: api/OrganizerItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizerItem>>> GetOrganizerItems()
        {
            return await _context.OrganizerItems.ToListAsync();
        }

        // GET: api/OrganizerItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizerItem>> GetOrganizerItem(long id)
        {
            var organizerItem = await _context.OrganizerItems.FindAsync(id);

            if (organizerItem == null)
            {
                return NotFound();
            }

            return organizerItem;
        }

        // PUT: api/OrganizerItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizerItem(long id, OrganizerItem organizerItem)
        {
            if (id != organizerItem.Id)
            {
                return BadRequest();
            }

            if (!OrganizerItemExists(id))
            {
                return NotFound(); 
            }

            _context.Entry(organizerItem).State = EntityState.Modified;

            //try
            //{
               await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!OrganizerItemExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
            return Ok(organizerItem);
        }

        // POST: api/OrganizerItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrganizerItem>> PostOrganizerItem(OrganizerItem organizerItem)
        {
            _context.OrganizerItems.Add(organizerItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizerItem", new { id = organizerItem.Id }, organizerItem);
        }

        // DELETE: api/OrganizerItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrganizerItem>> DeleteOrganizerItem(long id)
        {
            var organizerItem = await _context.OrganizerItems.FindAsync(id);
            if (organizerItem == null)
            {
                return NotFound();
            }

            _context.OrganizerItems.Remove(organizerItem);
           // _context.Entry(organizerItem).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return organizerItem;
        }

        private bool OrganizerItemExists(long id)
        {
            return _context.OrganizerItems.Any(e => e.Id == id);
        }
    }
}

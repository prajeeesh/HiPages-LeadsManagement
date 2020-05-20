using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeadManagementApi.Models;
using LeadManagementApi.Utils;
using MediatR;
using LeadManagementApi.Mediatr.Leads.Query;
using LeadManagementApi.Mediatr.Leads.Commands;


namespace LeadManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly LeadsDBContext _context;
        private readonly ILeadsUtils _leadsUtils;

        private readonly IMediator _mediator;
        public LeadsController(LeadsDBContext context,ILeadsUtils leadsUtils, IMediator mediator)
        {
            _context = context;
            _leadsUtils = leadsUtils;

            _mediator = mediator;
        }
        // GET: api/Lead
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> GetLeads()
        {
          //  var leads = await _mediator.Send(new GetAllLeadsQuery());
            //return await leads.ToList();
            // return await _context.Leads.ToListAsync();
            return await Task.Run(() => _mediator.Send(new GetAllLeadsQuery()));
        }

        [Route("[action]/{status}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> GetByStatus(string status)
        {
            return await _context.Leads
                .Where(lead =>lead.Status == status)
                .ToListAsync();
        }

        // GET: api/Lead/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lead>> GetLead(int id)
        {
            var lead = await _context.Leads.FindAsync(id);

            if (lead == null)
            {
                return NotFound();
            }

            return lead;
        }

        // PUT: api/Lead/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLead(int id, Lead lead)
        {
            lead.Id = id;
            var leadToUpdate = _context.Leads.SingleOrDefault(l => l.Id == id);
            
            if (leadToUpdate != null)
            {
                leadToUpdate.Status = "Accepted";
                //apply discount
                leadToUpdate.Price = _leadsUtils.ApplyDiscount(leadToUpdate.Price);
                // _context.Entry(lead).State = EntityState.Modified;

            }
            try
            {
                await _context.SaveChangesAsync();
                //Send email
                _leadsUtils.SendEmail(leadToUpdate.Email, "Lead Accepted", "Lead Accepted");
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadExists(id))
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

        // POST: api/Lead
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Lead>> PostLead(Lead lead)
        {
            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLead", new { id = lead.Id }, lead);
        }

        // DELETE: api/Lead/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lead>> DeleteLead(int id)
        {
            var leadToUpdate = _context.Leads.SingleOrDefault(l => l.Id == id);
            if (leadToUpdate != null)
            {
                leadToUpdate.Status = "Declined";
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadExists(id))
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

        private bool LeadExists(int id)
        {
            return _context.Leads.Any(e => e.Id == id);
        }
       
    }
}

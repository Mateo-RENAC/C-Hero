// IncidentsController.cs
using Microsoft.AspNetCore.Mvc;
using C_Hero.Models.Entities;
using C_Hero.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentModel>>> GetIncidents()
        {
            return Ok(await _incidentService.GetAllIncidentsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentModel>> GetIncidentModel(Guid id)
        {
            var incidentModel = await _incidentService.GetIncidentByIdAsync(id);
            if (incidentModel == null)
            {
                return NotFound();
            }
            return Ok(incidentModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidentModel(Guid id, IncidentModel incidentModel)
        {
            if (id != incidentModel.IncidentId)
            {
                return BadRequest();
            }

            await _incidentService.UpdateIncidentAsync(incidentModel);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<IncidentModel>> PostIncidentModel(IncidentModel incidentModel)
        {
            var createdIncident = await _incidentService.CreateIncidentAsync(incidentModel);
            return CreatedAtAction("GetIncidentModel", new { id = createdIncident.IncidentId }, createdIncident);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidentModel(Guid id)
        {
            await _incidentService.DeleteIncidentAsync(id);
            return NoContent();
        }
    }
}

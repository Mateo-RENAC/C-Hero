// RapportsController.cs
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
    public class RapportsController : ControllerBase
    {
        private readonly IRapportService _rapportService;

        public RapportsController(IRapportService rapportService)
        {
            _rapportService = rapportService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RapportModel>>> GetRapports()
        {
            return Ok(await _rapportService.GetAllRapportsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RapportModel>> GetRapportModel(Guid id)
        {
            var rapportModel = await _rapportService.GetRapportByIdAsync(id);
            if (rapportModel == null)
            {
                return NotFound();
            }
            return Ok(rapportModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRapportModel(Guid id, RapportModel rapportModel)
        {
            if (id != rapportModel.FK_Rapport)
            {
                return BadRequest();
            }

            await _rapportService.UpdateRapportAsync(rapportModel);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<RapportModel>> PostRapportModel(RapportModel rapportModel)
        {
            var createdRapport = await _rapportService.CreateRapportAsync(rapportModel);
            return CreatedAtAction("GetRapportModel", new { id = createdRapport.FK_Rapport }, createdRapport);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRapportModel(Guid id)
        {
            await _rapportService.DeleteRapportAsync(id);
            return NoContent();
        }
    }
}


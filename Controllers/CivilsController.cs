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
    public class CivilsController : ControllerBase
    {
        private readonly ICivilService _civilService;

        public CivilsController(ICivilService civilService)
        {
            _civilService = civilService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CivilModel>>> GetCivils()
        {
            return Ok(await _civilService.GetAllCivilsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CivilModel>> GetCivilModel(Guid id)
        {
            var civilModel = await _civilService.GetCivilByIdAsync(id);
            if (civilModel == null)
            {
                return NotFound();
            }
            return Ok(civilModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCivilModel(Guid id, CivilModel civilModel)
        {
            if (id != civilModel.PK_Civil)
            {
                return BadRequest();
            }

            await _civilService.UpdateCivilAsync(civilModel);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CivilModel>> PostCivilModel(CivilModel civilModel)
        {
            var createdCivil = await _civilService.CreateCivilAsync(civilModel);
            return CreatedAtAction("GetCivilModel", new { id = createdCivil.PK_Civil }, createdCivil);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCivilModel(Guid id)
        {
            await _civilService.DeleteCivilAsync(id);
            return NoContent();
        }
    }
}
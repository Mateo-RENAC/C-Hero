// CrisesController.cs
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
    public class CrisesController : ControllerBase
    {
        private readonly ICrisisService _crisisService;

        public CrisesController(ICrisisService crisisService)
        {
            _crisisService = crisisService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrisisModel>>> GetCrises()
        {
            return Ok(await _crisisService.GetAllCrisesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CrisisModel>> GetCrisisModel(Guid id)
        {
            var crisisModel = await _crisisService.GetCrisisByIdAsync(id);
            if (crisisModel == null)
            {
                return NotFound();
            }
            return Ok(crisisModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrisisModel(Guid id, CrisisModel crisisModel)
        {
            if (id != crisisModel.PK_Crisis)
            {
                return BadRequest();
            }

            await _crisisService.UpdateCrisisAsync(crisisModel);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CrisisModel>> PostCrisisModel(CrisisModel crisisModel)
        {
            var createdCrisis = await _crisisService.CreateCrisisAsync(crisisModel);
            return CreatedAtAction("GetCrisisModel", new { id = createdCrisis.PK_Crisis }, createdCrisis);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrisisModel(Guid id)
        {
            await _crisisService.DeleteCrisisAsync(id);
            return NoContent();
        }
    }
}

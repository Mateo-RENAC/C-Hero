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
    public class SuperVillainsController : ControllerBase
    {
        private readonly ISuperVillainService _superVillainService;

        public SuperVillainsController(ISuperVillainService superVillainService)
        {
            _superVillainService = superVillainService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperVillainModel>>> GetSuperVillains()
        {
            return Ok(await _superVillainService.GetAllSuperVillainsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperVillainModel>> GetSuperVillainModel(Guid id)
        {
            var superVillainModel = await _superVillainService.GetSuperVillainByIdAsync(id);
            if (superVillainModel == null)
            {
                return NotFound();
            }
            return Ok(superVillainModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperVillainModel(Guid id, SuperVillainModel superVillainModel)
        {
            if (id != superVillainModel.PK_SuperV)
            {
                return BadRequest();
            }

            await _superVillainService.UpdateSuperVillainAsync(superVillainModel);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<SuperVillainModel>> PostSuperVillainModel(SuperVillainModel superVillainModel)
        {
            var createdSuperVillain = await _superVillainService.CreateSuperVillainAsync(superVillainModel);
            return CreatedAtAction("GetSuperVillainModel", new { id = createdSuperVillain.PK_SuperV }, createdSuperVillain);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperVillainModel(Guid id)
        {
            await _superVillainService.DeleteSuperVillainAsync(id);
            return NoContent();
        }
    }
}
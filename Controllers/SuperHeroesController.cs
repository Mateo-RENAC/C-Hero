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
    public class SuperHeroesController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroesController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperHeroModel>>> GetSuperHeroes()
        {
            return Ok(await _superHeroService.GetAllSuperHeroesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHeroModel>> GetSuperHeroModel(Guid id)
        {
            var superHeroModel = await _superHeroService.GetSuperHeroByIdAsync(id);
            if (superHeroModel == null)
            {
                return NotFound();
            }
            return Ok(superHeroModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperHeroModel(Guid id, SuperHeroModel superHeroModel)
        {
            if (id != superHeroModel.PK_SuperH)
            {
                return BadRequest();
            }

            await _superHeroService.UpdateSuperHeroAsync(superHeroModel);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<SuperHeroModel>> PostSuperHeroModel(SuperHeroModel superHeroModel)
        {
            var createdSuperHero = await _superHeroService.CreateSuperHeroAsync(superHeroModel);
            return CreatedAtAction("GetSuperHeroModel", new { id = createdSuperHero.PK_SuperH }, createdSuperHero);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperHeroModel(Guid id)
        {
            await _superHeroService.DeleteSuperHeroAsync(id);
            return NoContent();
        }
    }
}
// MissionsController.cs
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
    public class MissionsController : ControllerBase
    {
        private readonly IMissionService _missionService;

        public MissionsController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissionModel>>> GetMissions()
        {
            return Ok(await _missionService.GetAllMissionsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MissionModel>> GetMissionModel(Guid id)
        {
            var missionModel = await _missionService.GetMissionByIdAsync(id);
            if (missionModel == null)
            {
                return NotFound();
            }
            return Ok(missionModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMissionModel(Guid id, MissionModel missionModel)
        {
            if (id != missionModel.PK_Mission)
            {
                return BadRequest();
            }

            await _missionService.UpdateMissionAsync(missionModel);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<MissionModel>> PostMissionModel(MissionModel missionModel)
        {
            var createdMission = await _missionService.CreateMissionAsync(missionModel);
            return CreatedAtAction("GetMissionModel", new { id = createdMission.PK_Mission }, createdMission);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMissionModel(Guid id)
        {
            await _missionService.DeleteMissionAsync(id);
            return NoContent();
        }
    }
}


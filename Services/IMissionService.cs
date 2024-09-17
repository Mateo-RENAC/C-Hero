// IMissionService.cs
using C_Hero.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public interface IMissionService
    {
        Task<IEnumerable<MissionModel>> GetAllMissionsAsync();
        Task<MissionModel> GetMissionByIdAsync(Guid id);
        Task<MissionModel> CreateMissionAsync(MissionModel missionModel);
        Task UpdateMissionAsync(MissionModel missionModel);
        Task DeleteMissionAsync(Guid id);
    }
}


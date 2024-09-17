// MissionService.cs
using C_Hero.Data;
using C_Hero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public class MissionService : IMissionService
    {
        private readonly ApplicationDbContext _context;

        public MissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MissionModel>> GetAllMissionsAsync()
        {
            return await _context.Missions
                .Include(m => m.Incident)
                .Include(m => m.Heroes)
                .ToListAsync();
        }

        public async Task<MissionModel> GetMissionByIdAsync(Guid id)
        {
            return await _context.Missions
                .Include(m => m.Incident)
                .Include(m => m.Heroes)
                .FirstOrDefaultAsync(m => m.PK_Mission == id);
        }

        public async Task<MissionModel> CreateMissionAsync(MissionModel missionModel)
        {
            _context.Missions.Add(missionModel);
            await _context.SaveChangesAsync();
            return missionModel;
        }

        public async Task UpdateMissionAsync(MissionModel missionModel)
        {
            _context.Entry(missionModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMissionAsync(Guid id)
        {
            var missionModel = await _context.Missions.FindAsync(id);
            if (missionModel != null)
            {
                _context.Missions.Remove(missionModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}


// RapportService.cs
using C_Hero.Data;
using C_Hero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public class RapportService : IRapportService
    {
        private readonly ApplicationDbContext _context;

        public RapportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RapportModel>> GetAllRapportsAsync()
        {
            return await _context.Set<RapportModel>()
                .Include(r => r.Civil)
                .Include(r => r.Orga)
                .Include(r => r.SuperHero)
                .Include(r => r.Mission)
                .Include(r => r.Crises)
                .ToListAsync();
        }

        public async Task<RapportModel> GetRapportByIdAsync(Guid id)
        {
            return await _context.Set<RapportModel>()
                .Include(r => r.Civil)
                .Include(r => r.Orga)
                .Include(r => r.SuperHero)
                .Include(r => r.Mission)
                .Include(r => r.Crises)
                .FirstOrDefaultAsync(r => r.FK_Rapport == id);
        }

        public async Task<RapportModel> CreateRapportAsync(RapportModel rapportModel)
        {
            _context.Set<RapportModel>().Add(rapportModel);
            await _context.SaveChangesAsync();
            return rapportModel;
        }

        public async Task UpdateRapportAsync(RapportModel rapportModel)
        {
            _context.Entry(rapportModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRapportAsync(Guid id)
        {
            var rapportModel = await _context.Set<RapportModel>().FindAsync(id);
            if (rapportModel != null)
            {
                _context.Set<RapportModel>().Remove(rapportModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}


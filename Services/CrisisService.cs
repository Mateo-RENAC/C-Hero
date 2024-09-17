// CrisisService.cs
using C_Hero.Data;
using C_Hero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public class CrisisService : ICrisisService
    {
        private readonly ApplicationDbContext _context;

        public CrisisService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CrisisModel>> GetAllCrisesAsync()
        {
            return await _context.Crises
                .Include(c => c.Dispute)
                .Include(c => c.Rapports)
                .ToListAsync();
        }

        public async Task<CrisisModel> GetCrisisByIdAsync(Guid id)
        {
            return await _context.Crises
                .Include(c => c.Dispute)
                .Include(c => c.Rapports)
                .FirstOrDefaultAsync(c => c.PK_Crisis == id);
        }

        public async Task<CrisisModel> CreateCrisisAsync(CrisisModel crisisModel)
        {
            _context.Crises.Add(crisisModel);
            await _context.SaveChangesAsync();
            return crisisModel;
        }

        public async Task UpdateCrisisAsync(CrisisModel crisisModel)
        {
            _context.Entry(crisisModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCrisisAsync(Guid id)
        {
            var crisisModel = await _context.Crises.FindAsync(id);
            if (crisisModel != null)
            {
                _context.Crises.Remove(crisisModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}

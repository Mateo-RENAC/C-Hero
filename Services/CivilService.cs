using C_Hero.Data;
using C_Hero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public class CivilService : ICivilService
    {
        private readonly ApplicationDbContext _context;

        public CivilService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CivilModel>> GetAllCivilsAsync()
        {
            return await _context.Civils.ToListAsync();
        }

        public async Task<CivilModel> GetCivilByIdAsync(Guid? id)
        {
            return await _context.Civils.FindAsync(id);
        }

        public async Task<CivilModel> CreateCivilAsync(CivilModel civilModel)
        {
            _context.Civils.Add(civilModel);
            await _context.SaveChangesAsync();
            return civilModel;
        }

        public async Task UpdateCivilAsync(CivilModel civilModel)
        {
            _context.Entry(civilModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCivilAsync(Guid? id)
        {
            var civilModel = await _context.Civils.FindAsync(id);
            if (civilModel != null)
            {
                _context.Civils.Remove(civilModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
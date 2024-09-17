using C_Hero.Data;
using C_Hero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public class SuperVillainService : ISuperVillainService
    {
        private readonly ApplicationDbContext _context;

        public SuperVillainService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SuperVillainModel>> GetAllSuperVillainsAsync()
        {
            return await _context.SuperVillains.ToListAsync();
        }

        public async Task<SuperVillainModel> GetSuperVillainByIdAsync(Guid id)
        {
            return await _context.SuperVillains.FindAsync(id);
        }

        public async Task<SuperVillainModel> CreateSuperVillainAsync(SuperVillainModel superVillainModel)
        {
            _context.SuperVillains.Add(superVillainModel);
            await _context.SaveChangesAsync();
            return superVillainModel;
        }

        public async Task UpdateSuperVillainAsync(SuperVillainModel superVillainModel)
        {
            _context.Entry(superVillainModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSuperVillainAsync(Guid id)
        {
            var superVillainModel = await _context.SuperVillains.FindAsync(id);
            if (superVillainModel != null)
            {
                _context.SuperVillains.Remove(superVillainModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
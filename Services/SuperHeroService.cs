using C_Hero.Data;
using C_Hero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly ApplicationDbContext _context;

        public SuperHeroService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SuperHeroModel>> GetAllSuperHeroesAsync()
        {
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHeroModel> GetSuperHeroByIdAsync(Guid id)
        {
            return await _context.SuperHeroes.FindAsync(id);
        }

        public async Task<SuperHeroModel> CreateSuperHeroAsync(SuperHeroModel superHeroModel)
        {
            _context.SuperHeroes.Add(superHeroModel);
            await _context.SaveChangesAsync();
            return superHeroModel;
        }

        public async Task UpdateSuperHeroAsync(SuperHeroModel superHeroModel)
        {
            _context.Entry(superHeroModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSuperHeroAsync(Guid id)
        {
            var superHeroModel = await _context.SuperHeroes.FindAsync(id);
            if (superHeroModel != null)
            {
                _context.SuperHeroes.Remove(superHeroModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
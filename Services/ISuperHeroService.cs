using C_Hero.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public interface ISuperHeroService
    {
        Task<IEnumerable<SuperHeroModel>> GetAllSuperHeroesAsync();
        Task<SuperHeroModel> GetSuperHeroByIdAsync(Guid id);
        Task<SuperHeroModel> CreateSuperHeroAsync(SuperHeroModel superHeroModel);
        Task UpdateSuperHeroAsync(SuperHeroModel superHeroModel);
        Task DeleteSuperHeroAsync(Guid id);
    }
}
using C_Hero.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public interface ISuperVillainService
    {
        Task<IEnumerable<SuperVillainModel>> GetAllSuperVillainsAsync();
        Task<SuperVillainModel> GetSuperVillainByIdAsync(Guid id);
        Task<SuperVillainModel> CreateSuperVillainAsync(SuperVillainModel superVillainModel);
        Task UpdateSuperVillainAsync(SuperVillainModel superVillainModel);
        Task DeleteSuperVillainAsync(Guid id);
    }
}
// ICrisisService.cs
using C_Hero.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public interface ICrisisService
    {
        Task<IEnumerable<CrisisModel>> GetAllCrisesAsync();
        Task<CrisisModel> GetCrisisByIdAsync(Guid id);
        Task<CrisisModel> CreateCrisisAsync(CrisisModel crisisModel);
        Task UpdateCrisisAsync(CrisisModel crisisModel);
        Task DeleteCrisisAsync(Guid id);
    }
}

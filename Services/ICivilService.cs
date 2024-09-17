using C_Hero.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public interface ICivilService
    {
        Task<IEnumerable<CivilModel>> GetAllCivilsAsync();
        Task<CivilModel> GetCivilByIdAsync(Guid id);
        Task<CivilModel> CreateCivilAsync(CivilModel civilModel);
        Task UpdateCivilAsync(CivilModel civilModel);
        Task DeleteCivilAsync(Guid id);
    }
}
// IRapportService.cs
using C_Hero.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public interface IRapportService
    {
        Task<IEnumerable<RapportModel>> GetAllRapportsAsync();
        Task<RapportModel> GetRapportByIdAsync(Guid id);
        Task<RapportModel> CreateRapportAsync(RapportModel rapportModel);
        Task UpdateRapportAsync(RapportModel rapportModel);
        Task DeleteRapportAsync(Guid id);
    }
}


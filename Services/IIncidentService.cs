// IIncidentService.cs
using C_Hero.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public interface IIncidentService
    {
        Task<IEnumerable<IncidentModel>> GetAllIncidentsAsync();
        Task<IncidentModel> GetIncidentByIdAsync(Guid id);
        Task<IncidentModel> CreateIncidentAsync(IncidentModel incidentModel);
        Task UpdateIncidentAsync(IncidentModel incidentModel);
        Task DeleteIncidentAsync(Guid id);
    }
}

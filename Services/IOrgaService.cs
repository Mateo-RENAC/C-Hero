using C_Hero.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public interface IOrgaService
    {
        Task<IEnumerable<OrgaModel>> GetAllOrgasAsync();
        Task<OrgaModel> GetOrgaByIdAsync(Guid id);
        Task<OrgaModel> CreateOrgaAsync(OrgaModel orgaModel);
        Task UpdateOrgaAsync(OrgaModel orgaModel);
        Task DeleteOrgaAsync(Guid id);
    }
}
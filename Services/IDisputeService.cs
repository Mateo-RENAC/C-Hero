// IDiputeService.cs
using C_Hero.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public interface IDisputeService
    {
        Task<IEnumerable<DisputeModel>> GetAllDisputesAsync();
        Task<DisputeModel> GetDisputeByIdAsync(Guid id);
        Task<DisputeModel> CreateDisputeAsync(DisputeModel disputeModel);
        Task UpdateDisputeAsync(DisputeModel disputeModel);
        Task DeleteDisputeAsync(Guid id);
    }
}

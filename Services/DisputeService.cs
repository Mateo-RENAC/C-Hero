// DisputeService.cs
using C_Hero.Data;
using C_Hero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public class DisputeService : IDisputeService
    {
        private readonly ApplicationDbContext _context;

        public DisputeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DisputeModel>> GetAllDisputesAsync()
        {
            return await _context.Disputes
                .Include(d => d.Orga)
                .Include(d => d.Civil)
                .ToListAsync();
        }

        public async Task<DisputeModel> GetDisputeByIdAsync(Guid id)
        {
            return await _context.Disputes
                .Include(d => d.Orga)
                .Include(d => d.Civil)
                .FirstOrDefaultAsync(d => d.PK_Dispute == id);
        }

        public async Task<DisputeModel> CreateDisputeAsync(DisputeModel disputeModel)
        {
            _context.Disputes.Add(disputeModel);
            await _context.SaveChangesAsync();
            return disputeModel;
        }

        public async Task UpdateDisputeAsync(DisputeModel disputeModel)
        {
            _context.Entry(disputeModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDisputeAsync(Guid id)
        {
            var disputeModel = await _context.Disputes.FindAsync(id);
            if (disputeModel != null)
            {
                _context.Disputes.Remove(disputeModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}


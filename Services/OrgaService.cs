using C_Hero.Data;
using C_Hero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public class OrgaService : IOrgaService
    {
        private readonly ApplicationDbContext _context;

        public OrgaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrgaModel>> GetAllOrgasAsync()
        {
            return await _context.Orgas.ToListAsync();
        }

        public async Task<OrgaModel> GetOrgaByIdAsync(Guid id)
        {
            return await _context.Orgas.FindAsync(id) ?? throw new ArgumentNullException(nameof(id));
        }

        public async Task<OrgaModel> CreateOrgaAsync(OrgaModel orgaModel)
        {
            _context.Orgas.Add(orgaModel);
            await _context.SaveChangesAsync();
            return orgaModel;
        }

        public async Task UpdateOrgaAsync(OrgaModel orgaModel)
        {
            _context.Entry(orgaModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrgaAsync(Guid id)
        {
            var orgaModel = await _context.Orgas.FindAsync(id);
            if (orgaModel != null)
            {
                _context.Orgas.Remove(orgaModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
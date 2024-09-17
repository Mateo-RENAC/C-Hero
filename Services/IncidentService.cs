// IncidentService.cs
using C_Hero.Data;
using C_Hero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly ApplicationDbContext _context;

        public IncidentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IncidentModel>> GetAllIncidentsAsync()
        {
            return await _context.Incidents
                .Include(i => i.Orga_Decleare)
                .Include(i => i.Civil_Decleare)
                .Include(i => i.Villains)
                .ToListAsync();
        }

        public async Task<IncidentModel> GetIncidentByIdAsync(Guid id)
        {
            return await _context.Incidents
                .Include(i => i.Orga_Decleare)
                .Include(i => i.Civil_Decleare)
                .Include(i => i.Villains)
                .FirstOrDefaultAsync(i => i.IncidentId == id);
        }

        public async Task<IncidentModel> CreateIncidentAsync(IncidentModel incidentModel)
        {
            _context.Incidents.Add(incidentModel);
            await _context.SaveChangesAsync();
            return incidentModel;
        }

        public async Task UpdateIncidentAsync(IncidentModel incidentModel)
        {
            _context.Entry(incidentModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIncidentAsync(Guid id)
        {
            var incidentModel = await _context.Incidents.FindAsync(id);
            if (incidentModel != null)
            {
                _context.Incidents.Remove(incidentModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}

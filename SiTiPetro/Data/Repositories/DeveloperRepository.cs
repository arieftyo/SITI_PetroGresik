using Microsoft.EntityFrameworkCore;
using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data.Repositories
{
    public class DeveloperRepository : Repository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(AplikasiContext context) : base(context)
        {

        }

        public async Task DeleteByDevId(int devId)
        {
            if (String.IsNullOrEmpty(devId.ToString())) throw new ArgumentNullException("entity");

            var developer = context.Developers.SingleOrDefault(s => s.devId == devId);
            context.Developers.Remove(developer);
            await context.SaveChangesAsync();
        }

        public async Task<List<Developer>> GetDeveloperByAplikasiId(int id)
        {
            if (String.IsNullOrEmpty(id.ToString())) throw new ArgumentNullException("entity");

            var developer = context.Developers.Where(a => a.aplikasiId == id);
            return await developer.ToListAsync();
        }

        public async Task<Developer> GetDeveloperByDevId(int devId)
        {
            return await context.Developers.FirstOrDefaultAsync(s => s.devId == devId);            
        }
    }
}

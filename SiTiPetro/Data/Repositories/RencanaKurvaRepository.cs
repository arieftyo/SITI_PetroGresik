using Microsoft.EntityFrameworkCore;
using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data.Repositories
{
    public class RencanaKurvaRepository : Repository<RencanaKurva>, IRencanaKurvaRepository
    {
        public RencanaKurvaRepository(AplikasiContext context) : base(context)
        {

        }

        public async Task<List<RencanaKurva>> GetRencanaKurvaByAplikasiId(int aplikasiId)
        {
            var rencanaKurvas = context.RencanaKurva.Where(a => a.aplikasiId == aplikasiId);
            return await rencanaKurvas.ToListAsync();
        }

        public async Task<List<RencanaKurva>> GetRencanaKurvaRealisasiNotZero(int aplikasiId)
        {
            var rencanaKurvas = context.RencanaKurva
                                .Where(a => a.aplikasiId == aplikasiId)
                                .Where(a => a.Realisasi != 0.0);
            return await rencanaKurvas.ToListAsync();
        }
    }
}

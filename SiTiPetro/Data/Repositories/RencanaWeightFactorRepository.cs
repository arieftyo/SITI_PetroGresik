using Microsoft.EntityFrameworkCore;
using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data.Repositories
{
    public class RencanaWeightFactorRepository : Repository<RencanaWeightFactor>, IRencanaWeightFactorRepository
    {
        public RencanaWeightFactorRepository(AplikasiContext context) : base(context)
        {

        }

        public async Task<RencanaWeightFactor> GetRencanaWeightFactorByAplikasiId(int aplikasiId)
        {
            return await context.RencanaWeightFactor.FirstOrDefaultAsync(s => s.AplikasiId == aplikasiId);
        }
    }
}

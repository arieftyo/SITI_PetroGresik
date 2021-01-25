using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data.Repositories
{
    public interface IRencanaWeightFactorRepository : IRepository<RencanaWeightFactor>
    {
        Task<RencanaWeightFactor> GetRencanaWeightFactorByAplikasiId(int aplikasiId);
    }
}

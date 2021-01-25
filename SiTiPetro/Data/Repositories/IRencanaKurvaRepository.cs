using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data.Repositories
{
    public interface IRencanaKurvaRepository : IRepository<RencanaKurva>
    {
        Task<List<RencanaKurva>> GetRencanaKurvaByAplikasiId(int apliaksiId);
        Task<List<RencanaKurva>> GetRencanaKurvaRealisasiNotZero(int aplikasiId);
    }
}

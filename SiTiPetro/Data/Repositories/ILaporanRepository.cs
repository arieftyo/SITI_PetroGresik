using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data.Repositories
{
    public interface ILaporanRepository : IRepository<Laporan>
    {
        Task<List<Laporan>> GetLaporanByAplikasiId(int apliaksiId);

        Task<Laporan> GetLaporanSameAplikasiIdAndFileName(int aplikasiId, string fileName);
    }
}

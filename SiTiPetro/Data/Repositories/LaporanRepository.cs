using Microsoft.EntityFrameworkCore;
using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data.Repositories
{
    public class LaporanRepository : Repository<Laporan>, ILaporanRepository
    {
        public LaporanRepository(AplikasiContext context) : base(context)
        {

        }

        public async Task<List<Laporan>> GetLaporanByAplikasiId(int aplikasiId)
        {
            var laporans = context.Laporan.Where(a => a.AplikasiId == aplikasiId);
            return await laporans.ToListAsync();
        }

        public async Task<Laporan> GetLaporanSameAplikasiIdAndFileName(int aplikasiId, string fileName)
        {
            var laporan = context.Laporan
                            .Where(l => l.AplikasiId == aplikasiId)
                            .Where(l => l.FileName.Equals(fileName))
                            .FirstOrDefaultAsync();
            return await laporan;
        }
    }
}

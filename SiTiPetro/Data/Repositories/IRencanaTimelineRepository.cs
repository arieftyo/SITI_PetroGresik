using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data.Repositories
{
    public interface IRencanaTimelineRepository : IRepository<RencanaTimeline>
    {
        Task<RencanaTimeline> GetRencanaTimelineByAplikasiId(int aplikasiId);
        Task UpdateRencanaTimelineRealisasiBrd(RencanaTimeline rencanaTimeline);
        Task UpdateRencanaTimelineRealisasiFinalBrd(RencanaTimeline rencanaTimeline);
        Task UpdateRencanaTimelineRealisasiPengadaan(RencanaTimeline rencanaTimeline);
        Task UpdateRencanaTimelineRealisasiDesainPrototype(RencanaTimeline rencanaTimeline);
        Task UpdateRencanaTimelineRealisasiPengembangan(RencanaTimeline rencanaTimeline);
        Task UpdateRencanaTimelineRealisasiTesting(RencanaTimeline rencanaTimeline);
        Task UpdateRencanaTimelineRealisasiEut(RencanaTimeline rencanaTimeline);
        Task UpdateRencanaTimelineRealisasiGoLive(RencanaTimeline rencanaTimeline);
        Task UpdateRencanaTimelineRealisasiSupport(RencanaTimeline rencanaTimeline);
        Task UpdateRencanaTimelineRealisasiClosing(RencanaTimeline rencanaTimeline);

    }
}

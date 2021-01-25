using Microsoft.EntityFrameworkCore;
using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data.Repositories
{
    public class RencanaTimelineRepository : Repository<RencanaTimeline>, IRencanaTimelineRepository
    {
        public RencanaTimelineRepository(AplikasiContext context) : base(context)
        {

        }

        public async Task<RencanaTimeline> GetRencanaTimelineByAplikasiId(int aplikasiId)
        {
            return await context.RencanaTimeline.FirstOrDefaultAsync(s => s.AplikasiId == aplikasiId);
        }

        public async Task UpdateRencanaTimelineRealisasiBrd(RencanaTimeline rencanaTimeline)
        {
            context.RencanaTimeline.Attach(rencanaTimeline);
            context.Entry(rencanaTimeline).Property(x => x.RealisasiBrdDate1).IsModified = true;
            context.Entry(rencanaTimeline).Property(x => x.RealisasiBrdDate2).IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task UpdateRencanaTimelineRealisasiClosing(RencanaTimeline rencanaTimeline)
        {
            context.RencanaTimeline.Attach(rencanaTimeline);
            context.Entry(rencanaTimeline).Property(x => x.RealisasiClosingDate1).IsModified = true;
            context.Entry(rencanaTimeline).Property(x => x.RealisasiClosingDate2).IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task UpdateRencanaTimelineRealisasiDesainPrototype(RencanaTimeline rencanaTimeline)
        {
            context.RencanaTimeline.Attach(rencanaTimeline);
            context.Entry(rencanaTimeline).Property(x => x.RealisasiDesainPrototypeDate1).IsModified = true;
            context.Entry(rencanaTimeline).Property(x => x.RealisasiDesainPrototypeDate2).IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task UpdateRencanaTimelineRealisasiEut(RencanaTimeline rencanaTimeline)
        {
            context.RencanaTimeline.Attach(rencanaTimeline);
            context.Entry(rencanaTimeline).Property(x => x.RealisasiEutDate1).IsModified = true;
            context.Entry(rencanaTimeline).Property(x => x.RealisasiEutDate2).IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task UpdateRencanaTimelineRealisasiFinalBrd(RencanaTimeline rencanaTimeline)
        {
            context.RencanaTimeline.Attach(rencanaTimeline);
            context.Entry(rencanaTimeline).Property(x => x.RealisasiFinalBrdDate1).IsModified = true;
            context.Entry(rencanaTimeline).Property(x => x.RealisasiFinalBrdDate2).IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task UpdateRencanaTimelineRealisasiGoLive(RencanaTimeline rencanaTimeline)
        {
            context.RencanaTimeline.Attach(rencanaTimeline);
            context.Entry(rencanaTimeline).Property(x => x.RealisasiGoLiveDate1).IsModified = true;
            context.Entry(rencanaTimeline).Property(x => x.RealisasiGoLiveDate2).IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task UpdateRencanaTimelineRealisasiPengadaan(RencanaTimeline rencanaTimeline)
        {
            context.RencanaTimeline.Attach(rencanaTimeline);
            context.Entry(rencanaTimeline).Property(x => x.RealisasiPengadaanDate1).IsModified = true;
            context.Entry(rencanaTimeline).Property(x => x.RealisasiPengadaanDate2).IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task UpdateRencanaTimelineRealisasiPengembangan(RencanaTimeline rencanaTimeline)
        {
            context.RencanaTimeline.Attach(rencanaTimeline);
            context.Entry(rencanaTimeline).Property(x => x.RealisasiPengembanganDate1).IsModified = true;
            context.Entry(rencanaTimeline).Property(x => x.RealisasiPengembanganDate2).IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task UpdateRencanaTimelineRealisasiSupport(RencanaTimeline rencanaTimeline)
        {
            context.RencanaTimeline.Attach(rencanaTimeline);
            context.Entry(rencanaTimeline).Property(x => x.RealisasiSupportDate1).IsModified = true;
            context.Entry(rencanaTimeline).Property(x => x.RealisasiSupportDate2).IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task UpdateRencanaTimelineRealisasiTesting(RencanaTimeline rencanaTimeline)
        {
            context.RencanaTimeline.Attach(rencanaTimeline);
            context.Entry(rencanaTimeline).Property(x => x.RealisasiTestingDate1).IsModified = true;
            context.Entry(rencanaTimeline).Property(x => x.RealisasiTestingDate2).IsModified = true;
            await context.SaveChangesAsync();
        }
    }
}

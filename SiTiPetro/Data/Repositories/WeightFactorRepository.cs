using Microsoft.EntityFrameworkCore;
using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data.Repositories
{
    public class WeightFactorRepository : Repository<WeightFactor>, IWeightFactorRepository
    {
        public WeightFactorRepository(AplikasiContext context) : base(context)
        {

        }

        public bool CheckWeightFactorExist(int aplikasiId)
        {
            return context.Set<WeightFactor>().Any(e => e.AplikasiId == aplikasiId);
        }

        public async Task<WeightFactor> GetWeightFactorByAplikasiId(int aplikasiId)
        {
            return await context.WeightFactor.AsNoTracking().Where(a => a.AplikasiId == aplikasiId).FirstOrDefaultAsync();
        }

        public async Task UpdateDataWeightFactor(WeightFactor weightFactor)
        {
            context.WeightFactor.Attach(weightFactor);
            context.Entry(weightFactor).Property(x => x.LinkMobileAndroid).IsModified = true;
            context.Entry(weightFactor).Property(x => x.LinkWebsite).IsModified = true;
            context.Entry(weightFactor).Property(x => x.LinkMobileiOs).IsModified = true;
            context.Entry(weightFactor).Property(x => x.Server).IsModified = true;
            context.Entry(weightFactor).Property(x => x.Database).IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task UpdateWeightFactorFile(WeightFactor weightFactor, string type)
        {
            context.WeightFactor.Attach(weightFactor);
            
            if(type.Equals("brd"))
            {
                context.Entry(weightFactor).Property(x => x.FileBrd).IsModified = true;
            }
            
            if (type.Equals("logo"))
            {
                context.Entry(weightFactor).Property(x => x.FileLogo).IsModified = true;
            }

            if(type.Equals("tor"))
            {
                context.Entry(weightFactor).Property(x => x.FileTor).IsModified = true;
            }

            if (type.Equals("okprpo"))
            {
                context.Entry(weightFactor).Property(x => x.FileOkPrPo).IsModified = true;
            }

            if (type.Equals("usermanual"))
            {
                context.Entry(weightFactor).Property(x => x.FileUserManualgembangan).IsModified = true;
            }

            if (type.Equals("uat"))
            {
                context.Entry(weightFactor).Property(x => x.FileUat).IsModified = true;
            }

            if (type.Equals("eut"))
            {
                context.Entry(weightFactor).Property(x => x.FileEut).IsModified = true;
            }

            if (type.Equals("ba"))
            {
                context.Entry(weightFactor).Property(x => x.FileBa).IsModified = true;
            }

            if (type.Equals("changerequest"))
            {
                context.Entry(weightFactor).Property(x => x.FileChangeRequest).IsModified = true;
            }

            if (type.Equals("ik"))
            {
                context.Entry(weightFactor).Property(x => x.FileIk).IsModified = true;
            }

            if (type.Equals("prosedur"))
            {
                context.Entry(weightFactor).Property(x => x.FileProsedur).IsModified = true;
            }

            await context.SaveChangesAsync();
        }
    }
}

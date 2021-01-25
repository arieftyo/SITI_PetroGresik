using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data.Repositories
{
    public class AplikasiRepository : Repository<Aplikasi>, IAplikasiRepository
    {
        public AplikasiRepository(AplikasiContext context) : base(context)
        {

        }

        public bool CheckAplikasiExist(int id)
        {
            return context.Set<Aplikasi>().Any(e => e.Id == id);
        }

        public async Task UpdateAplikasiPmBa(Aplikasi aplikasi)
        {
            context.Aplikasi.Attach(aplikasi);
            context.Entry(aplikasi).Property(x => x.pm).IsModified = true;
            context.Entry(aplikasi).Property(x => x.ba).IsModified = true;
            await context.SaveChangesAsync();
        }

        public async Task UpdateAplikasiUploadBrd(Aplikasi aplikasi)
        {
            context.Aplikasi.Attach(aplikasi);
            context.Entry(aplikasi).Property(x => x.upload_brd).IsModified = true;
            await context.SaveChangesAsync();
        }
    }
}

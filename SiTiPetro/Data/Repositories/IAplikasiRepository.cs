using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data.Repositories
{
    public interface IAplikasiRepository : IRepository<Aplikasi>
    {
        bool CheckAplikasiExist(int id);

        Task UpdateAplikasiPmBa(Aplikasi aplikasi);
        Task UpdateAplikasiUploadBrd(Aplikasi aplikasi);
    }
}

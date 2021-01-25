using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data.Repositories
{
    public interface IDeveloperRepository : IRepository<Developer>
    {
        Task<List<Developer>> GetDeveloperByAplikasiId(int aplikasiId);
        Task DeleteByDevId(int devId);
        Task<Developer> GetDeveloperByDevId(int devId);

    }
}

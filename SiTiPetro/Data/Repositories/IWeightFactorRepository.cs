using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data.Repositories
{
    public interface IWeightFactorRepository : IRepository<WeightFactor>
    {
        bool CheckWeightFactorExist(int aplikasiId);
        Task<WeightFactor> GetWeightFactorByAplikasiId(int aplikasiId);
        Task UpdateWeightFactorFile(WeightFactor weightFactor, string type);
        Task UpdateDataWeightFactor(WeightFactor weightFactor);
    }
}

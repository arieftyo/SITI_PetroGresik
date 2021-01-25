using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.ViewModels.WeightFactorViewModel
{
    public class DetailWeightFactorViewModel
    {
        public WeightFactor WeightFactor;
        public string AplikasiName { set; get; }
        public int AplikasiId { set; get; }
    }
}

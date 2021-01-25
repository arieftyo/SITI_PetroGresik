using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.ViewModels.RencanaKurvaViewModel
{
    public class DetailRencanaKurvaViewModel
    {
        public DetailRencanaKurvaViewModel()
        {
            listRencanaKurvas = new List<RencanaKurva>();
        }
        public List<RencanaKurva> listRencanaKurvas;

        public int aplikasiId;
    }
}

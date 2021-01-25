using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.ViewModels.RencanaKurvaViewModel
{
    public class EditRealisasiRencananKurvaViewModelcs
    {
        public EditRealisasiRencananKurvaViewModelcs()
        {
            listRencanaKurvas = new List<RencanaKurva>();
        }
        public List<RencanaKurva> listRencanaKurvas { set; get; }
        public int aplikasiId { set; get; }
    }
}

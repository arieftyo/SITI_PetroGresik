using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.ViewModels.RencanaWeightFactorViewModel
{
    public class EditRencanaWeightFactorViewModel
    {
        public int rencanaWeightFactorId;
        public int brd { set; get; }
        public int finalisasiBRD { set; get; }
        public int pengadaan { set; get; }
        public int desainPrototype { set; get; }
        public int pengembangan { set; get; }
        public int testing { set; get; }
        public int eut { set; get; }
        public int goLive { set; get; }
        public int support { set; get; }
        public int aplikasiId { set; get; }
    }
}

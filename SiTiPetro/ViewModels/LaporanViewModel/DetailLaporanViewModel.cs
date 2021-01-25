using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.ViewModels.LaporanViewModel
{
    public class DetailLaporanViewModel
    {
        public DetailLaporanViewModel()
        {
            listLaporans = new List<Laporan>();
        }
        public List<Laporan> listLaporans;

        public int AplikasiId;
    }
}

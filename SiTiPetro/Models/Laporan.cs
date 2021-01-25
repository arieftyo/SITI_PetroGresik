using SiTiPetro.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Models
{
    public class Laporan : IEntity
    {
        public int Id { get; set; }
        public int Bulan { get; set; }
        public string File { get; set; }
        public string FileName { get; set; }
        public int AplikasiId { get; set; }
    }
}

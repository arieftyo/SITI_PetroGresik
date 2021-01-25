using SiTiPetro.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Models
{
    public class RencanaKurva : IEntity
    {
        [Key]
        public int Id { set; get; }
        public int Bulan { set; get; }
        public int Minggu { set; get; }
        public double RencanProgres { set; get; }
        public double Realisasi { set; get; }
        public double Presentasi { set; get; }
        public int aplikasiId { set; get; }
        public string Deskripsi { set; get; }

    }
}

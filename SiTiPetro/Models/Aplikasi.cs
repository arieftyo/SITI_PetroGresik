using SiTiPetro.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Models
{
    public class Aplikasi : IEntity
    {
        public int Id { set; get; }
        public string nama { set; get; }
        public string deskripsi { set; get; }
        public string nomor_surat_dof { set; get; }
        public string direktorat { set; get; }
        public string kompartemen { set; get; }
        public string departermen { set; get; }
        public string upload_brd { set; get; }
        public string pic_unit_terkait { set; get; }
        public string nomer_hp { set; get; }
        public int tahun { set; get; }
        public int jenis_aplikasi { set; get; }
        public string rencana_anggaran { set; get; }
        public string pic_ti_pi_pg { set; get; }
        public int pengerjaan { set; get; }
        public string pm { set; get; }
        public string ba { set; get; }
        public RencanaTimeline rencanaTimeline { set; get; }
        public RencanaWeightFactor rencanaWeightFactor { set; get; } 
    }
}

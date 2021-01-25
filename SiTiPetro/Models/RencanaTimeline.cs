using SiTiPetro.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Models
{
    public class RencanaTimeline : IEntity
    {
        [Key]
        public int Id { set; get; }
        public string BrdDate1 { set; get; }
        public string BrdDate2 { set; get; }
        public string FinalBrdDate1 { set; get; }
        public string FinalBrdDate2 { set; get; }
        public string PengadaanDate1 { set; get; }
        public string PengadaanDate2 { set; get; }
        public string DesainPrototypeDate1 { set; get; }
        public string DesainPrototypeDate2 { set; get; }
        public string PengembanganDate1 { set; get; }
        public string PengembanganDate2 { set; get; }
        public string TestingDate1 { set; get; }
        public string TestingDate2 { set; get; }
        public string EutDate1 { set; get; }
        public string EutDate2 { set; get; }
        public string GoLiveDate1 { set; get; }
        public string GoLiveDate2 { set; get; }
        public string SupportDate1 { set; get; }
        public string SupportDate2 { set; get; }
        public string ClosingDate1 { set; get; }
        public string ClosingDate2 { set; get; }
        public int AplikasiId { set; get; }
        public string RealisasiBrdDate1 { set; get; }
        public string RealisasiBrdDate2 { set; get; }
        public string RealisasiFinalBrdDate1 { set; get; }
        public string RealisasiFinalBrdDate2 { set; get; }
        public string RealisasiPengadaanDate1 { set; get; }
        public string RealisasiPengadaanDate2 { set; get; }
        public string RealisasiDesainPrototypeDate1 { set; get; }
        public string RealisasiDesainPrototypeDate2 { set; get; }
        public string RealisasiPengembanganDate1 { set; get; }
        public string RealisasiPengembanganDate2 { set; get; }
        public string RealisasiTestingDate1 { set; get; }
        public string RealisasiTestingDate2 { set; get; }
        public string RealisasiEutDate1 { set; get; }
        public string RealisasiEutDate2 { set; get; }
        public string RealisasiGoLiveDate1 { set; get; }
        public string RealisasiGoLiveDate2 { set; get; }
        public string RealisasiSupportDate1 { set; get; }
        public string RealisasiSupportDate2 { set; get; }
        public string RealisasiClosingDate1 { set; get; }
        public string RealisasiClosingDate2 { set; get; }
    }
}

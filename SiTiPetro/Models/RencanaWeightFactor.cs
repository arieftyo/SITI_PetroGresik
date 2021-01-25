using SiTiPetro.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Models
{
    public class RencanaWeightFactor : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int BRD { get; set; }
        public int FinalisasiBRD { get; set; }
        public int Pengadaan { set; get; }
        public int DesainPrototype { set; get; }
        public int Pengembangan { get; set; }
        public int Testing { get; set; }
        public int EUT { get; set; }
        public int GoLive { get; set; }
        public int Support { get; set; }
        public int Closing { get; set; }
        public int AplikasiId { set; get; }
    }
}

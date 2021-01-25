using SiTiPetro.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Models
{
    public class Developer : IEntity
    {
        [Key]
        public int devId { set; get; }
        public string nama { set; get; }
        public int aplikasiId { set; get; }
        public IList<Aplikasi> aplikasi { set; get; }
        public int Id { get; set; }
    }
}

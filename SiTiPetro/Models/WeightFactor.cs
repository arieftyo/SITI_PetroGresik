using SiTiPetro.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Models
{
    public class WeightFactor : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string FileBrd { set; get; }
        public string FileLogo { set; get; }
        public string FileTor { set; get; }
        public string FileOkPrPo { set; get; }
        public string FileUserManualgembangan { set; get; }
        public string FileUat { set; get; }
        public string FileEut { set; get; }
        public string FileBa { set; get; }
        public string FileChangeRequest { set; get; }
        public string FileIk { set; get; }
        public string FileProsedur { set; get; }
        public string LinkWebsite { set; get; }
        public string LinkMobileAndroid { set; get; }
        public string LinkMobileiOs { set; get; }
        public string Server { set; get; }
        public string Database { set; get;}
        public int AplikasiId { set; get; }
    }
}

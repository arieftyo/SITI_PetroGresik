using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.ViewModels.RencanaTimelineViewModel
{
    public class EditRencanaTimelineViewModel
    {
        public int rencanaTimelineId { set; get; }
        public string dateBrd { set; get; }
        public string dateFinalBrd { set; get; }
        public string datePengadaan { set; get; }
        public string dateDesainPrototype { set; get; }
        public string datePengembangan { set; get; }
        public string dateTesting { set; get; }
        public string dateEut { set; get; }
        public string dateGoLive { set; get; }
        public string dateSupport { set; get; }
        public string dateClosing { set; get; }
        public int aplikasiId { set; get; }
    }
}

using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.ViewModels.RencanaTimelineViewModel
{
    public class DetailRencanaTimelineViewModel
    {
        public RencanaTimeline rencanaTimeline { set; get; }
        public string aplikasiName { set; get; }
        public int aplikasiId { set; get; }
    }
}

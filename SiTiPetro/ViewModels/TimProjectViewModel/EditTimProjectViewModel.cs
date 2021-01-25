using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.ViewModels.TimProjectViewModel
{
    public class EditTimProjectViewModel
    {
        public EditTimProjectViewModel()
        {
            devName = new List<string>();
        }
        public int id { set; get; }
        public string pm { set; get; }
        public string ba { set; get; }

        public List<string> devName { set; get; }

    }
}

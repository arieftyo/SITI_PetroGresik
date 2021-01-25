using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiTiPetro.Data.Repositories;
using SiTiPetro.Models;
using SiTiPetro.ViewModels.RencanaWeightFactorViewModel;

namespace SiTiPetro.Controllers
{
    public class RencanaWeightFactorController : Controller
    {
        private IRencanaWeightFactorRepository _rencanaWeightFactorRepository;
        private IAplikasiRepository _aplikasiRepository;

        public RencanaWeightFactorController(IRencanaWeightFactorRepository rencanaWeightFactorRepository, IAplikasiRepository aplikasiRepository)
        {
            this._rencanaWeightFactorRepository = rencanaWeightFactorRepository;
            this._aplikasiRepository = aplikasiRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplikasi = await _aplikasiRepository.GetById((int)id);

            if (aplikasi == null)
            {
                return NotFound();
            }

            var rencanaWeightFactor = await _rencanaWeightFactorRepository.GetRencanaWeightFactorByAplikasiId((int)id);

            var model = new DetailRencanaWeightFactorViewModel()
            {
                rencanaWeightFactor = rencanaWeightFactor,
                aplikasiName = aplikasi.nama,
                aplikasiId = aplikasi.Id,
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var aplikasi = await _aplikasiRepository.GetById(id);

            if (aplikasi == null)
            {
                return NotFound();
            }

            var model = new RencanaWeightFactor()
            {
                AplikasiId = id
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int aplikasiId, int brd, int finalisasiBRD, int pengadaan, 
            int desainPrototype, int pengembangan, int testing, int eut, int goLive, int support)
        {
            var model = new RencanaWeightFactor()
            {
                BRD = brd,
                FinalisasiBRD = finalisasiBRD,
                Pengadaan = pengadaan,
                DesainPrototype = desainPrototype,
                Pengembangan = pengembangan,
                Testing = testing,
                EUT = eut,
                GoLive = goLive,
                Support = support,
                AplikasiId = aplikasiId
            };

            if (ModelState.IsValid)
            {
                await _rencanaWeightFactorRepository.Insert(model);
                return RedirectToAction("Details", "Aplikasis", new { id = aplikasiId });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var aplikasi = await _aplikasiRepository.GetById((int)id);

            if (aplikasi == null)
            {
                return NotFound();
            }

            var rencanaWeightFactor = await _rencanaWeightFactorRepository.GetRencanaWeightFactorByAplikasiId((int)id);

            var model = new EditRencanaWeightFactorViewModel()
            {
                brd = rencanaWeightFactor.BRD,
                finalisasiBRD = rencanaWeightFactor.FinalisasiBRD,
                pengadaan = rencanaWeightFactor.Pengadaan,
                desainPrototype = rencanaWeightFactor.DesainPrototype,
                pengembangan = rencanaWeightFactor.Pengembangan,
                testing = rencanaWeightFactor.Testing,
                eut = rencanaWeightFactor.EUT,
                goLive = rencanaWeightFactor.EUT,
                support = rencanaWeightFactor.Support,
                aplikasiId = aplikasi.Id,
                rencanaWeightFactorId = rencanaWeightFactor.Id
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int aplikasiId, int brd, int finalisasiBRD, int pengadaan,
            int desainPrototype, int pengembangan, int testing, int eut, int goLive, int support, int rencanaWeightFactorId)
        {
            var model = new RencanaWeightFactor()
            {
                BRD = brd,
                FinalisasiBRD = finalisasiBRD,
                Pengadaan = pengadaan,
                DesainPrototype = desainPrototype,
                Pengembangan = pengembangan,
                Testing = testing,
                EUT = eut,
                GoLive = goLive,
                Support = support,
                AplikasiId = aplikasiId,
                Id = rencanaWeightFactorId
            };

            if (ModelState.IsValid)
            {
                await _rencanaWeightFactorRepository.Update(model);
                return RedirectToAction("Details", "Aplikasis", new { id = aplikasiId });
            }
            return View(model);
        }
    }
}

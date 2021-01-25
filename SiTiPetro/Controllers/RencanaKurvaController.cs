using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiTiPetro.Data;
using SiTiPetro.Data.Repositories;
using SiTiPetro.Models;
using SiTiPetro.ViewModels.RencanaKurvaViewModel;

namespace SiTiPetro.Controllers
{
    public class RencanaKurvaController : Controller
    {
        private IRencanaKurvaRepository _rencanaKurvaRepository;
        private IAplikasiRepository _aplikasiRepository;
        public RencanaKurvaController (IRencanaKurvaRepository rencanaKurvaRepository, IAplikasiRepository aplikasiRepository)
        {
            this._rencanaKurvaRepository = rencanaKurvaRepository;
            this._aplikasiRepository = aplikasiRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {

            var rencanaKurvas = await _rencanaKurvaRepository.GetRencanaKurvaByAplikasiId(id);
            var model = new DetailRencanaKurvaViewModel()
            {
                listRencanaKurvas = rencanaKurvas,
                aplikasiId = id
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id)
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

            var model = new RencanaKurva()
            {
                aplikasiId = aplikasi.Id
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int aplikasiId, int bulan, int minggu, float rencanaProgres, float realisasi, float presentase)
        {
            var rencanaKurva = new RencanaKurva()
            {
                aplikasiId = aplikasiId,
                Bulan = bulan,
                Minggu = minggu,
                RencanProgres = Math.Round((Double)rencanaProgres, 2),
                Realisasi = Math.Round((Double)0, 2),
                Presentasi = Math.Round((Double)presentase, 2)
            };
            if (ModelState.IsValid)
            {
                await _rencanaKurvaRepository.Insert(rencanaKurva);
                return RedirectToAction("Detail", "RencanaKurva", new { id = aplikasiId });
            }
            return View(rencanaKurva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int aplikasiId)
        {
            await _rencanaKurvaRepository.Delete(id);
            return RedirectToAction("Detail", "RencanaKurva", new { id = aplikasiId });
        }

        [HttpGet]
        public async Task<IActionResult> Realisasi(int? id)
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

            var rencanaKurvas = await _rencanaKurvaRepository.GetRencanaKurvaByAplikasiId((int)id);

            var model = new EditRealisasiRencananKurvaViewModelcs()
            {
               aplikasiId = aplikasi.Id,
               listRencanaKurvas = rencanaKurvas
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRealisasi(int id, int aplikasiId, int bulan, int minggu, float rencanaProgres, 
            float realisasi, float presentase, string deskripsi)
        {
            var model = new RencanaKurva()
            {
                Id = id,
                aplikasiId = aplikasiId,
                Bulan = bulan,
                Minggu = minggu,
                RencanProgres = Math.Round((Double)rencanaProgres, 2),
                Realisasi = Math.Round((Double)realisasi, 2),
                Presentasi = Math.Round((Double)presentase, 2),
                Deskripsi = deskripsi
            };

            if (ModelState.IsValid)
            {
                await _rencanaKurvaRepository.Update(model);
                return RedirectToAction("Realisasi", "RencanaKurva", new { id = aplikasiId });
            }
            return RedirectToAction("Realisasi", "RencanaKurva", new { id = aplikasiId });
        }
    }
}

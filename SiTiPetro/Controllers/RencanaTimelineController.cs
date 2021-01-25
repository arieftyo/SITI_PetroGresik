using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiTiPetro.Data;
using SiTiPetro.Data.Repositories;
using SiTiPetro.Models;
using SiTiPetro.ViewModels.RencanaTimelineViewModel;

namespace SiTiPetro.Controllers
{
    public class RencanaTimelineController : Controller
    {
        private IAplikasiRepository _aplikasiRepository;
        private IRencanaTimelineRepository _rencanaTimelineRepository;
        public RencanaTimelineController(IAplikasiRepository aplikasiRepository, IRencanaTimelineRepository rencanaTimelineRepository)
        {
            this._aplikasiRepository = aplikasiRepository;
            this._rencanaTimelineRepository = rencanaTimelineRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var aplikasi = await _aplikasiRepository.GetById(id);
            
            if (aplikasi == null)
            {
                return NotFound();
            }
            
            var model = new RencanaTimeline()
            {
                AplikasiId = id
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int aplikasiId, string dateBrd, string dateFinalisasiBrd, 
            string datePengadaan, string dateDesainPrototype, string datePengembangan, string dateTesting, 
            string dateEut, string dateGolive, string dateSupport, string dateClosing)
        {
            var model = new RencanaTimeline()
            {
                BrdDate1 = getFirstDate(dateBrd),
                BrdDate2 = getSecondDate(dateBrd),
                FinalBrdDate1 = getFirstDate(dateFinalisasiBrd),
                FinalBrdDate2 = getSecondDate(dateFinalisasiBrd),
                PengadaanDate1 = getFirstDate(datePengadaan),
                PengadaanDate2 = getSecondDate(datePengadaan),
                DesainPrototypeDate1 = getFirstDate(dateDesainPrototype),
                DesainPrototypeDate2 = getSecondDate(dateDesainPrototype),
                PengembanganDate1 = getFirstDate(datePengembangan),
                PengembanganDate2 = getSecondDate(datePengembangan),
                TestingDate1 = getFirstDate(dateTesting),
                TestingDate2 = getSecondDate(dateTesting),
                EutDate1 = getFirstDate(dateEut),
                EutDate2 = getSecondDate(dateEut),
                GoLiveDate1 = getFirstDate(dateGolive),
                GoLiveDate2 = getSecondDate(dateGolive),
                SupportDate1 = getFirstDate(dateSupport),
                SupportDate2 = getSecondDate(dateSupport),
                ClosingDate1 = getFirstDate(dateClosing),
                ClosingDate2 = getSecondDate(dateClosing),
                AplikasiId = aplikasiId
            };

            if (ModelState.IsValid)
            {
                await _rencanaTimelineRepository.Insert(model);
                return RedirectToAction("Details", "Aplikasis", new { id = aplikasiId });
            }
            return View(model);
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

            var rencanaTimeline = await _rencanaTimelineRepository.GetRencanaTimelineByAplikasiId((int)id);

            var model = new DetailRencanaTimelineViewModel()
            {
                rencanaTimeline = rencanaTimeline,
                aplikasiName = aplikasi.nama,
                aplikasiId = aplikasi.Id,
            };

            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var aplikasi = await _aplikasiRepository.GetById((int)id);

            if (aplikasi == null)
            {
                return NotFound();
            }

            var rencanaTimeline = await _rencanaTimelineRepository.GetRencanaTimelineByAplikasiId((int)id);

            var model = new EditRencanaTimelineViewModel()
            {
                aplikasiId = aplikasi.Id,
                dateBrd = string.Concat(rencanaTimeline.BrdDate1, " - ", rencanaTimeline.BrdDate2),
                dateFinalBrd = string.Concat(rencanaTimeline.FinalBrdDate1, " - ", rencanaTimeline.FinalBrdDate2),
                datePengadaan = string.Concat(rencanaTimeline.PengadaanDate1, " - ", rencanaTimeline.PengadaanDate2),
                dateDesainPrototype = string.Concat(rencanaTimeline.DesainPrototypeDate1, " - ", rencanaTimeline.DesainPrototypeDate2),
                datePengembangan = string.Concat(rencanaTimeline.PengembanganDate1, " - ", rencanaTimeline.PengembanganDate2),
                dateTesting = string.Concat(rencanaTimeline.TestingDate1, " - ", rencanaTimeline.TestingDate2),
                dateEut = string.Concat(rencanaTimeline.EutDate1, " - ", rencanaTimeline.EutDate2),
                dateGoLive = string.Concat(rencanaTimeline.GoLiveDate1, " - ", rencanaTimeline.GoLiveDate2),
                dateSupport = string.Concat(rencanaTimeline.SupportDate1, " - ", rencanaTimeline.SupportDate2),
                dateClosing = string.Concat(rencanaTimeline.ClosingDate1, " - ", rencanaTimeline.ClosingDate2),
                rencanaTimelineId = rencanaTimeline.Id
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int aplikasiId, string dateBrd, string dateFinalisasiBrd,
           string datePengadaan, string dateDesainPrototype, string datePengembangan, string dateTesting,
           string dateEut, string dateGolive, string dateSupport, string dateClosing, int rencanaId)
        {
            var model = new RencanaTimeline()
            {
                BrdDate1 = getFirstDate(dateBrd),
                BrdDate2 = getSecondDate(dateBrd),
                FinalBrdDate1 = getFirstDate(dateFinalisasiBrd),
                FinalBrdDate2 = getSecondDate(dateFinalisasiBrd),
                PengadaanDate1 = getFirstDate(datePengadaan),
                PengadaanDate2 = getSecondDate(datePengadaan),
                DesainPrototypeDate1 = getFirstDate(dateDesainPrototype),
                DesainPrototypeDate2 = getSecondDate(dateDesainPrototype),
                PengembanganDate1 = getFirstDate(datePengembangan),
                PengembanganDate2 = getSecondDate(datePengembangan),
                TestingDate1 = getFirstDate(dateTesting),
                TestingDate2 = getSecondDate(dateTesting),
                EutDate1 = getFirstDate(dateEut),
                EutDate2 = getSecondDate(dateEut),
                GoLiveDate1 = getFirstDate(dateGolive),
                GoLiveDate2 = getSecondDate(dateGolive),
                SupportDate1 = getFirstDate(dateSupport),
                SupportDate2 = getSecondDate(dateSupport),
                ClosingDate1 = getFirstDate(dateClosing),
                ClosingDate2 = getSecondDate(dateClosing),
                AplikasiId = aplikasiId,
                Id = rencanaId
            };

            if (ModelState.IsValid)
            {
                await _rencanaTimelineRepository.Update(model);
                return RedirectToAction("Details", "Aplikasis", new { id = aplikasiId });
            }
            return View(model);
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

            var rencanaTimeline = await _rencanaTimelineRepository.GetRencanaTimelineByAplikasiId((int)id);

            var model = new RealisasiRencanaTimelineViewModel()
            {
                rencanaTimeline = rencanaTimeline,
                aplikasiName = aplikasi.nama,
                aplikasiId = aplikasi.Id,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRealisasiBrd(int? id, string dateBrd, int aplikasiId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifiedRencanaTimeline = new RencanaTimeline()
            {
                Id = (int)id,
                RealisasiBrdDate1 = getFirstDate(dateBrd),
                RealisasiBrdDate2 = getSecondDate(dateBrd)
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiBrd(modifiedRencanaTimeline);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aplikasiRepository.CheckAplikasiExist(modifiedRencanaTimeline.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
            }
            return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRealisasiFinalisasiBrd(int? id, string dateFinalisasiBrd, int aplikasiId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifiedRencanaTimeline = new RencanaTimeline()
            {
                Id = (int)id,
                RealisasiFinalBrdDate1 = getFirstDate(dateFinalisasiBrd),
                RealisasiFinalBrdDate2 = getSecondDate(dateFinalisasiBrd)
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiFinalBrd(modifiedRencanaTimeline);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aplikasiRepository.CheckAplikasiExist(modifiedRencanaTimeline.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
            }
            return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRealisasiPengadaan(int? id, string datePengadaan, int aplikasiId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifiedRencanaTimeline = new RencanaTimeline()
            {
                Id = (int)id,
                RealisasiPengadaanDate1 = getFirstDate(datePengadaan),
                RealisasiPengadaanDate2 = getSecondDate(datePengadaan)
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiPengadaan(modifiedRencanaTimeline);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aplikasiRepository.CheckAplikasiExist(modifiedRencanaTimeline.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
            }
            return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRealisasiDesainPrototype(int? id, string dateDesainPrototype, int aplikasiId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifiedRencanaTimeline = new RencanaTimeline()
            {
                Id = (int)id,
                RealisasiDesainPrototypeDate1 = getFirstDate(dateDesainPrototype),
                RealisasiDesainPrototypeDate2 = getSecondDate(dateDesainPrototype)
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiDesainPrototype(modifiedRencanaTimeline);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aplikasiRepository.CheckAplikasiExist(modifiedRencanaTimeline.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
            }
            return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRealisasiPengembangan(int? id, string datePengembangan, int aplikasiId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifiedRencanaTimeline = new RencanaTimeline()
            {
                Id = (int)id,
                RealisasiPengembanganDate1 = getFirstDate(datePengembangan),
                RealisasiPengembanganDate2 = getSecondDate(datePengembangan)
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiPengembangan(modifiedRencanaTimeline);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aplikasiRepository.CheckAplikasiExist(modifiedRencanaTimeline.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
            }
            return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRealisasiTesting(int? id, string dateTesting, int aplikasiId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifiedRencanaTimeline = new RencanaTimeline()
            {
                Id = (int)id,
                RealisasiTestingDate1 = getFirstDate(dateTesting),
                RealisasiTestingDate2 = getSecondDate(dateTesting)
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiTesting(modifiedRencanaTimeline);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aplikasiRepository.CheckAplikasiExist(modifiedRencanaTimeline.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
            }
            return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRealisasiEut(int? id, string dateEut, int aplikasiId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifiedRencanaTimeline = new RencanaTimeline()
            {
                Id = (int)id,
                RealisasiEutDate1 = getFirstDate(dateEut),
                RealisasiEutDate2 = getSecondDate(dateEut)
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiEut(modifiedRencanaTimeline);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aplikasiRepository.CheckAplikasiExist(modifiedRencanaTimeline.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
            }
            return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRealisasiGoLive(int? id, string dateGoLive, int aplikasiId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifiedRencanaTimeline = new RencanaTimeline()
            {
                Id = (int)id,
                RealisasiGoLiveDate1 = getFirstDate(dateGoLive),
                RealisasiGoLiveDate2 = getSecondDate(dateGoLive)
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiGoLive(modifiedRencanaTimeline);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aplikasiRepository.CheckAplikasiExist(modifiedRencanaTimeline.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
            }
            return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRealisasiSupport(int? id, string dateSupport, int aplikasiId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifiedRencanaTimeline = new RencanaTimeline()
            {
                Id = (int)id,
                RealisasiSupportDate1 = getFirstDate(dateSupport),
                RealisasiSupportDate2 = getSecondDate(dateSupport)
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiSupport(modifiedRencanaTimeline);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aplikasiRepository.CheckAplikasiExist(modifiedRencanaTimeline.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
            }
            return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRealisasiClosing(int? id, string dateClosing, int aplikasiId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifiedRencanaTimeline = new RencanaTimeline()
            {
                Id = (int)id,
                RealisasiClosingDate1 = getFirstDate(dateClosing),
                RealisasiClosingDate2 = getSecondDate(dateClosing)
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiClosing(modifiedRencanaTimeline);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aplikasiRepository.CheckAplikasiExist(modifiedRencanaTimeline.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
            }
            return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRealisasi (int? id, string type, int aplikasiId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifiedRencanaTimeline = new RencanaTimeline()
            {
                Id = (int)id,
                RealisasiBrdDate1 = null,
                RealisasiBrdDate2 = null,
                RealisasiFinalBrdDate1 = null,
                RealisasiFinalBrdDate2 = null,
                RealisasiPengadaanDate1 = null,
                RealisasiPengadaanDate2 = null,
                RealisasiDesainPrototypeDate1 = null,
                RealisasiDesainPrototypeDate2 = null,
                RealisasiPengembanganDate1 = null,
                RealisasiPengembanganDate2 = null,
                RealisasiTestingDate1 = null,
                RealisasiTestingDate2 = null,
                RealisasiEutDate1 = null,
                RealisasiEutDate2 = null,
                RealisasiGoLiveDate1 = null,
                RealisasiGoLiveDate2 = null,
                RealisasiSupportDate1 = null,
                RealisasiSupportDate2 = null,
                RealisasiClosingDate1 = null,
                RealisasiClosingDate2 = null
            };

            if (ModelState.IsValid)
            {
                try
                {
                    if(type.Equals("Brd"))
                        await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiBrd(modifiedRencanaTimeline);
                    else if(type.Equals("FinalisasiBrd"))
                        await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiFinalBrd(modifiedRencanaTimeline);
                    else if (type.Equals("Pengadaan"))
                        await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiPengadaan(modifiedRencanaTimeline);
                    else if (type.Equals("DesainPrototype"))
                        await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiDesainPrototype(modifiedRencanaTimeline);
                    else if (type.Equals("Pengembangan"))
                        await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiPengembangan(modifiedRencanaTimeline);
                    else if (type.Equals("Testing"))
                        await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiTesting(modifiedRencanaTimeline);
                    else if (type.Equals("Eut"))
                        await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiEut(modifiedRencanaTimeline);
                    else if (type.Equals("GoLive"))
                        await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiGoLive(modifiedRencanaTimeline);
                    else if (type.Equals("Support"))
                        await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiSupport(modifiedRencanaTimeline);
                    else if (type.Equals("Closing"))
                        await _rencanaTimelineRepository.UpdateRencanaTimelineRealisasiClosing(modifiedRencanaTimeline);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aplikasiRepository.CheckAplikasiExist(modifiedRencanaTimeline.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
            }
            return RedirectToAction("Realisasi", "RencanaTimeline", new { id = aplikasiId });
        }


        public string getFirstDate(string date)
        {
            string[] dateValue = date.Split(" - ");
            return dateValue[0];
        }
        public string getSecondDate(string date)
        {
            string[] dateValue = date.Split(" - ");
            return dateValue[1];
        }



    }
}

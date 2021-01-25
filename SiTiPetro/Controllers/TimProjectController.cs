using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SiTiPetro.Data;
using SiTiPetro.Data.Repositories;
using SiTiPetro.Models;
using SiTiPetro.ViewModels.TimProjectViewModel;

namespace SiTiPetro.Controllers
{
    public class TimProjectController : Controller
    {
        private IAplikasiRepository _aplikasiRepository;
        private IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;
        public TimProjectController(IAplikasiRepository aplikasiRepository, IDeveloperRepository developerRepository,  IMapper mapper)
        {
            this._aplikasiRepository = aplikasiRepository;
            this._developerRepository = developerRepository;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Aplikasi aplikasi = await _aplikasiRepository.GetById(id);
         

            if (aplikasi == null)
            {
                ViewBag.ErrorMessage = $"Aplikasi with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditTimProjectViewModel
            {
                id = aplikasi.Id,
                pm = aplikasi.pm,
                ba = aplikasi.ba
            };

            List<Developer> developers = await _developerRepository.GetDeveloperByAplikasiId(aplikasi.Id);

            Tuple<EditTimProjectViewModel, List<Developer>> tuple = new Tuple<EditTimProjectViewModel, List<Developer>>(model, developers);

            return View(tuple);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("id,pm,ba")] EditTimProjectViewModel model)
        {
            if(id != model.id)
            {
                ViewBag.ErrorMessage = $"Aplikasi with Id = {id} cannot be found";
                return View("NotFound");
            }
            var modifiedApilikasi = new Aplikasi()
            {
                Id = model.id,
                pm = model.pm,
                ba = model.ba
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _aplikasiRepository.UpdateAplikasiPmBa(modifiedApilikasi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aplikasiRepository.CheckAplikasiExist(model.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Aplikasis", new { id = id });
            }
            return RedirectToAction("Details", "Aplikasis", new { id = id });
        }

        public async Task<IActionResult> AddDev(int id, string devName)
        {

            Developer developer = new Developer()
            {
                aplikasiId = id,
                nama = devName
            };

            if(ModelState.IsValid)
            {

                await _developerRepository.Insert(developer);
                return RedirectToAction("Details", "Aplikasis", new { id = id });
            }
            return RedirectToAction("Details", "Aplikasis", new { id = id });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int devId)
        {
            var developer = await _developerRepository.GetDeveloperByDevId(devId);
            await _developerRepository.DeleteByDevId(devId);
            return RedirectToAction("Details", "Aplikasis", new { id = developer.aplikasiId });
        }
    }
}

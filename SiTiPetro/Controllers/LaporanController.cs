using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiTiPetro.Data.Repositories;
using SiTiPetro.Models;
using SiTiPetro.ViewModels.LaporanViewModel;

namespace SiTiPetro.Controllers
{
    public class LaporanController : Controller
    {
        private ILaporanRepository _laporanRepository;
        private IAplikasiRepository _aplikasiRepository;

        public LaporanController(ILaporanRepository laporanRepository, IAplikasiRepository aplikasiRepository)
        {
            this._aplikasiRepository = aplikasiRepository;
            this._laporanRepository = laporanRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            if (!_aplikasiRepository.CheckAplikasiExist((int)Id))
            {
                return NotFound();
            }

            var laporans = await _laporanRepository.GetLaporanByAplikasiId((int)Id);

            var model = new DetailLaporanViewModel()
            {
                listLaporans = laporans,
                AplikasiId = (int)Id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Detail(IFormFile file, int aplikasiId, int bulan)
        {
            var laporans = await _laporanRepository.GetLaporanByAplikasiId(aplikasiId);

            var model = new DetailLaporanViewModel()
            {
                listLaporans = laporans,
                AplikasiId = aplikasiId
            };

            if (file == null || file.Length == 0)
            {
                ViewData["error"] = "File belum diinputkan";
                return View(model);
            }

            string extension = Path.GetExtension(file.FileName);
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/laporan/" + aplikasiId);
            
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var pathFile = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/files/laporan/" + aplikasiId, file.FileName);
            
            
            if (await _laporanRepository.GetLaporanSameAplikasiIdAndFileName(aplikasiId, file.FileName) != null)
            {
                ViewData["error"] = "File dengan nama yang sama sudah tersedia. Ubah nama file yang anda upload";
                return View(model);
            }
            
            var laporanNew = new Laporan()
            {
                AplikasiId = aplikasiId,
                FileName = file.FileName,
                File = pathFile,
                Bulan = bulan
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _laporanRepository.Insert(laporanNew);

                    using (var stream = new FileStream(pathFile, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                catch (Exception e)
                {
                 
                     throw e;
                }
                
                return RedirectToAction("Detail", "Laporan", new { id = aplikasiId });
            }
            return RedirectToAction("Detail", "Laporan", new { id = aplikasiId });
        }

        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");


            var memory = new MemoryStream();
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(filename), Path.GetFileName(filename));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".ppt", "application/vnd.ms-powerpoint" },
                {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int aplikasiId)
        {
            var laporan = await _laporanRepository.GetById(id);
            
            if(laporan == null)
            {
                return NotFound();
            }

            System.IO.File.Delete(laporan.File);

            await _laporanRepository.Delete(id);

            return RedirectToAction("Detail", "Laporan", new { id = aplikasiId });
        }
    }
}

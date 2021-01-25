using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiTiPetro.Data;
using SiTiPetro.Data.Repositories;
using SiTiPetro.Models;
using SiTiPetro.ViewModels.AplikasiViewModel;

namespace SiTiPetro.Controllers
{
    public class AplikasisController : Controller
    {
        private IAplikasiRepository _aplikasiRepository;
        private IDeveloperRepository _developerRepository;
        private IRencanaKurvaRepository _rencanaKurvaRepository;
        private readonly IMapper _mapper;
        public AplikasisController(IAplikasiRepository aplikasiRepository, IDeveloperRepository developerRepository, 
            IRencanaKurvaRepository rencanaKurvaRepository, IMapper mapper)
        {
            this._aplikasiRepository = aplikasiRepository;
            this._developerRepository = developerRepository;
            this._rencanaKurvaRepository = rencanaKurvaRepository;
            this._mapper = mapper;
        }

        // GET: Aplikasis
        public async Task<IActionResult> Index()
        {
            return View(await _aplikasiRepository.GetAll());
        }

        // GET: Aplikasis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Aplikasi aplikasi = await _aplikasiRepository.GetById((int)id);

            if (aplikasi == null)
            {
                return NotFound();
            }

            List<Developer> developer = await _developerRepository.GetDeveloperByAplikasiId(aplikasi.Id);
            
            if (developer == null)
            {
                return NotFound();
            }

            Tuple<Aplikasi, List<Developer>> tuple = new Tuple<Aplikasi, List<Developer>>(aplikasi, developer);

            return View(tuple);
        }

        // GET: Aplikasis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aplikasis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, string nama, string deskripsi, string nomor_surat_dof,
            string direktorat, string kompartemen, string departermen, string pic_unit_terkait, string nomer_hp,
            int tahun,int jenis_aplikasi,string rencana_anggaran)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");
            string extension = Path.GetExtension(file.FileName);
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/files/brd_aplikasi", "filebrd_" + nama +
                        "_" + departermen + extension);
            var aplikasi = new Aplikasi()
            {
                nama = nama,
                deskripsi = deskripsi,
                nomor_surat_dof = nomor_surat_dof,
                direktorat = direktorat,
                kompartemen = kompartemen,
                departermen = departermen,
                pic_unit_terkait = pic_unit_terkait,
                nomer_hp = nomer_hp,
                tahun = tahun,
                jenis_aplikasi = jenis_aplikasi,
                rencana_anggaran = rencana_anggaran,
                upload_brd = path
            };

            if (ModelState.IsValid)
            {
                try
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                catch(Exception)
                {
                    throw;
                }

                try
                {
                    await _aplikasiRepository.Insert(aplikasi);
                }
                catch(DbUpdateConcurrencyException)
                {
                    throw;
                }
               
                return RedirectToAction(nameof(Index));
            }
            return View(aplikasi);
        }

        // GET: Aplikasis/Edit/5
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
            return View(aplikasi);
        }

        // POST: Aplikasis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nama,deskripsi,nomor_surat_dof,direktorat,kompartemen,departermen,upload_brd,pic_unit_terkait,nomer_hp,tahun,jenis_aplikasi,rencana_anggaran, pic_ti_pi_pg, pengerjaan, pm, ba")] Aplikasi aplikasi)
        {
            if (id != aplikasi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _aplikasiRepository.Update(aplikasi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aplikasiRepository.CheckAplikasiExist(aplikasi.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aplikasi);
        }

        // GET: Aplikasis/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

            return View(aplikasi);
        }

        // POST: Aplikasis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _aplikasiRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Realisasi()
        {
            return View(await _aplikasiRepository.GetAll());
        }

        public async Task<IActionResult> Progres()
        {
            IEnumerable<Aplikasi> aplikasis = await _aplikasiRepository.GetAll();

            List<ProgresAplikasiViewModel> models = new List<ProgresAplikasiViewModel>();

            foreach (var aplikasi in aplikasis)
            {
                double progres = 0;
                var kurvas = await _rencanaKurvaRepository.GetRencanaKurvaRealisasiNotZero(aplikasi.Id);

                if (kurvas.Count != 0)
                {
                    var lastmonthkurva = kurvas.OrderByDescending(k => k.Bulan).FirstOrDefault();
                    
                    foreach (var kurva in kurvas)
                    {
                        progres += kurva.Realisasi;
                    }
                    models.Add(new ProgresAplikasiViewModel()
                    {
                        AplikasiName = aplikasi.nama,
                        Tahun = aplikasi.tahun,
                        Bulan = lastmonthkurva.Bulan,
                        Progres = progres,
                        ProgresDot = progres.ToString(CultureInfo.GetCultureInfo("en-GB"))
                });
                }
                else
                {
                    models.Add(new ProgresAplikasiViewModel()
                    {
                        AplikasiName = aplikasi.nama,
                        Tahun = aplikasi.tahun,
                        Bulan = 0,
                        Progres = 0,
                        ProgresDot = "0"
                    });
                }

            }
            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> EditFileBrd(IFormFile file, int id, string departemen, string nama, string upload_brd)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");
            string extension = Path.GetExtension(file.FileName);
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/files/brd_aplikasi", "filebrd_" + nama +
                        "_" + departemen + extension);
           

            var modifiedAplikasi = new Aplikasi()
            {
                Id = id,
                upload_brd = path
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _aplikasiRepository.UpdateAplikasiUploadBrd(modifiedAplikasi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_aplikasiRepository.CheckAplikasiExist(modifiedAplikasi.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                //delete File exist
                System.IO.File.Delete(upload_brd);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return RedirectToAction("Details", "Aplikasis", new { id = id });
            }
            return RedirectToAction("Details", "Aplikasis", new { id = id });
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
    }
}

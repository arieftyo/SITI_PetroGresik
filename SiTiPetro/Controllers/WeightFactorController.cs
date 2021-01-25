using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using SiTiPetro.Data.Repositories;
using SiTiPetro.Models;
using SiTiPetro.ViewModels.WeightFactorViewModel;

namespace SiTiPetro.Controllers
{
    public class WeightFactorController : Controller
    {
        private IAplikasiRepository _aplikasiRepository;
        private IWeightFactorRepository _weightFactorRepository;
        
        public WeightFactorController(IAplikasiRepository aplikasiRepository, IWeightFactorRepository weightFactorRepository)
        {
            this._aplikasiRepository = aplikasiRepository;
            this._weightFactorRepository = weightFactorRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

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
            
            var weightFactor = await _weightFactorRepository.GetWeightFactorByAplikasiId((int)id);

            if(weightFactor == null)
            {
                weightFactor = new WeightFactor()
                {
                    AplikasiId = aplikasi.Id
                };
               await _weightFactorRepository.Insert(weightFactor);
            }

            var model = new DetailWeightFactorViewModel()
            {
                WeightFactor = weightFactor,
                AplikasiName = aplikasi.nama,
                AplikasiId = aplikasi.Id,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file, int id, int aplikasiId, string type)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");
            string extension = Path.GetExtension(file.FileName);
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/files/"+ type, "file"+type+
                        "_" + aplikasiId.ToString() + extension);
           
            var modifiedWeightFactor = new WeightFactor()
            {
                Id = id
            };

            WeightFactor weightFactor = await _weightFactorRepository.GetWeightFactorByAplikasiId(aplikasiId);

            if (type.Equals("brd"))
            {
                if(weightFactor.FileBrd != null)
                {
                    System.IO.File.Delete(weightFactor.FileBrd);
                }
                modifiedWeightFactor.FileBrd = path;
            }

            if (type.Equals("logo"))
            {
                if (weightFactor.FileLogo != null)
                {
                    System.IO.File.Delete(weightFactor.FileLogo);
                }
                modifiedWeightFactor.FileLogo = path;
            }

            if (type.Equals("tor"))
            {
                if (weightFactor.FileTor != null)
                {
                    System.IO.File.Delete(weightFactor.FileTor);
                }
                modifiedWeightFactor.FileTor = path;
            }

            if (type.Equals("okprpo"))
            {
                if (weightFactor.FileOkPrPo != null)
                {
                    System.IO.File.Delete(weightFactor.FileOkPrPo);
                }
                modifiedWeightFactor.FileOkPrPo = path;
            }

            if (type.Equals("usermanual"))
            {
                if (weightFactor.FileUserManualgembangan != null)
                {
                    System.IO.File.Delete(weightFactor.FileUserManualgembangan);
                }
                modifiedWeightFactor.FileUserManualgembangan = path;
            }

            if (type.Equals("uat"))
            {
                if (weightFactor.FileUat != null)
                {
                    System.IO.File.Delete(weightFactor.FileUat);
                }
                modifiedWeightFactor.FileUat = path;
            }

            if (type.Equals("eut"))
            {
                if (weightFactor.FileEut != null)
                {
                    System.IO.File.Delete(weightFactor.FileEut);
                }
                modifiedWeightFactor.FileEut = path;
            }

            if (type.Equals("ba"))
            {
                if (weightFactor.FileBa != null)
                {
                    System.IO.File.Delete(weightFactor.FileBa);
                }
                modifiedWeightFactor.FileBa = path;
            }

            if (type.Equals("changerequest"))
            {
                if (weightFactor.FileChangeRequest != null)
                {
                    System.IO.File.Delete(weightFactor.FileChangeRequest);
                }
                modifiedWeightFactor.FileChangeRequest = path;
            }
            
            if (type.Equals("ik"))
            {
                if (weightFactor.FileIk != null)
                {
                    System.IO.File.Delete(weightFactor.FileIk);
                }
                modifiedWeightFactor.FileIk = path;
            }

            if (type.Equals("prosedur"))
            {
                if (weightFactor.FileProsedur != null)
                {
                    System.IO.File.Delete(weightFactor.FileProsedur);
                }
                modifiedWeightFactor.FileProsedur = path;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _weightFactorRepository.UpdateWeightFactorFile(modifiedWeightFactor, type);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_weightFactorRepository.CheckWeightFactorExist(modifiedWeightFactor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return RedirectToAction("Detail", "WeightFactor", new { id = aplikasiId });
            }
            return RedirectToAction("Detail", "WeightFactor", new { id = aplikasiId });
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

       [HttpPost]
        public async Task<IActionResult> EditData(int? id, int aplikasiId, string linkWebsite, string linkMobileAndorid, string linkMobileiOs, string server, string database)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifiedWeightFactor = new WeightFactor()
            {
                Id = (int)id,
                LinkWebsite = linkWebsite,
                LinkMobileAndroid = linkMobileAndorid,
                LinkMobileiOs = linkMobileiOs,
                Server = server,
                Database = database
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _weightFactorRepository.UpdateDataWeightFactor(modifiedWeightFactor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_weightFactorRepository.CheckWeightFactorExist(modifiedWeightFactor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
              
                return RedirectToAction("Detail", "WeightFactor", new { id = aplikasiId });
            }
            return RedirectToAction("Detail", "WeightFactor", new { id = aplikasiId });
        }


    }
}

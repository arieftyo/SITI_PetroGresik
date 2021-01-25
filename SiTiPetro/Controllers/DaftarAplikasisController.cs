using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiTiPetro.Data;

namespace SiTiPetro.Controllers
{
    public class DaftarAplikasisController : Controller
    {

        private readonly AplikasiContext _context;

        public DaftarAplikasisController(AplikasiContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aplikasi.ToListAsync());
        }

        // GET: Aplikasis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplikasi = await _context.Aplikasi.FindAsync(id);
            if (aplikasi == null)
            {
                return NotFound();
            }
            return View(aplikasi);
        }
    }
}

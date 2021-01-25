using Microsoft.EntityFrameworkCore;
using SiTiPetro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data
{
    public class AplikasiContext : DbContext
    {
        public AplikasiContext (DbContextOptions<AplikasiContext> options
            ) : base(options)
        {

        }
        public DbSet<Aplikasi> Aplikasi { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<RencanaTimeline> RencanaTimeline { get; set; }
        public DbSet<RencanaKurva> RencanaKurva { get; set; }
        public DbSet<RencanaWeightFactor> RencanaWeightFactor { get; set; }
        public DbSet<WeightFactor> WeightFactor { get; set; }
        public DbSet<Laporan> Laporan { get; set; }
    }
}

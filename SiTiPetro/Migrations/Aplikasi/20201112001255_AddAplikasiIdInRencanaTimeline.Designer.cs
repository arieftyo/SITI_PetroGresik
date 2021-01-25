﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiTiPetro.Data;

namespace SiTiPetro.Migrations.Aplikasi
{
    [DbContext(typeof(AplikasiContext))]
    [Migration("20201112001255_AddAplikasiIdInRencanaTimeline")]
    partial class AddAplikasiIdInRencanaTimeline
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SiTiPetro.Models.Aplikasi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeveloperdevId")
                        .HasColumnType("int");

                    b.Property<string>("ba")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("departermen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("deskripsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direktorat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("jenis_aplikasi")
                        .HasColumnType("int");

                    b.Property<string>("kompartemen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomer_hp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomor_surat_dof")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pengerjaan")
                        .HasColumnType("int");

                    b.Property<string>("pic_ti_pi_pg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pic_unit_terkait")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rencana_anggaran")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tahun")
                        .HasColumnType("int");

                    b.Property<string>("upload_brd")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperdevId");

                    b.ToTable("Aplikasi");
                });

            modelBuilder.Entity("SiTiPetro.Models.Developer", b =>
                {
                    b.Property<int>("devId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("aplikasiId")
                        .HasColumnType("int");

                    b.Property<string>("nama")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("devId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("SiTiPetro.Models.Aplikasi", b =>
                {
                    b.HasOne("SiTiPetro.Models.Developer", null)
                        .WithMany("aplikasi")
                        .HasForeignKey("DeveloperdevId");
                });
#pragma warning restore 612, 618
        }
    }
}

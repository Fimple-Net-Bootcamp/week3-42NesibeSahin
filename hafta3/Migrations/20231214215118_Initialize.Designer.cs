﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hafta3.Entities;

#nullable disable

namespace hafta3.Migrations
{
    [DbContext(typeof(ProjeDB))]
    [Migration("20231214215118_Initialize")]
    partial class Initialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("hafta3.Entities.Aktiviteler", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EvcilHayvanID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isSilindi")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("EvcilHayvanID");

                    b.ToTable("Aktiviteler");
                });

            modelBuilder.Entity("hafta3.Entities.Besinler", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EvcilHayvanID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isSilindi")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("EvcilHayvanID");

                    b.ToTable("Besinler");
                });

            modelBuilder.Entity("hafta3.Entities.EvcilHayvanlar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Kodu")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KullaniciID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tur")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isSilindi")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("KullaniciID");

                    b.ToTable("EvcilHayvanlar");
                });

            modelBuilder.Entity("hafta3.Entities.Kullanici", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isSilindi")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("hafta3.Entities.SaglikDurumlari", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DurumAdi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EvcilHayvanID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HastaMi")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isSilindi")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("EvcilHayvanID");

                    b.ToTable("SaglikDurumlari");
                });

            modelBuilder.Entity("hafta3.Entities.Aktiviteler", b =>
                {
                    b.HasOne("hafta3.Entities.EvcilHayvanlar", "EvcilHayvanlar")
                        .WithMany("Aktiviteler")
                        .HasForeignKey("EvcilHayvanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EvcilHayvanlar");
                });

            modelBuilder.Entity("hafta3.Entities.Besinler", b =>
                {
                    b.HasOne("hafta3.Entities.EvcilHayvanlar", "EvcilHayvanlar")
                        .WithMany("Besinler")
                        .HasForeignKey("EvcilHayvanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EvcilHayvanlar");
                });

            modelBuilder.Entity("hafta3.Entities.EvcilHayvanlar", b =>
                {
                    b.HasOne("hafta3.Entities.Kullanici", "Kullanici")
                        .WithMany("EvcilHayvanlar")
                        .HasForeignKey("KullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("hafta3.Entities.SaglikDurumlari", b =>
                {
                    b.HasOne("hafta3.Entities.EvcilHayvanlar", "EvcilHayvanlar")
                        .WithMany("SaglikDurumlari")
                        .HasForeignKey("EvcilHayvanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EvcilHayvanlar");
                });

            modelBuilder.Entity("hafta3.Entities.EvcilHayvanlar", b =>
                {
                    b.Navigation("Aktiviteler");

                    b.Navigation("Besinler");

                    b.Navigation("SaglikDurumlari");
                });

            modelBuilder.Entity("hafta3.Entities.Kullanici", b =>
                {
                    b.Navigation("EvcilHayvanlar");
                });
#pragma warning restore 612, 618
        }
    }
}

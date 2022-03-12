﻿// <auto-generated />
using System;
using KinderGarten.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KinderGarten.Data.Migrations
{
    [DbContext(typeof(KinderGartenContext))]
    [Migration("20210305214346_RoditeljModel")]
    partial class RoditeljModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KinderGarten.Models.Dijete", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("GrupaID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PosebnePotrebe")
                        .HasColumnType("bit");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PutanjaSlike")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoditeljID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GrupaID");

                    b.HasIndex("RoditeljID");

                    b.ToTable("Dijete");
                });

            modelBuilder.Entity("KinderGarten.Models.DijeteIzlet", b =>
                {
                    b.Property<int>("DijeteID")
                        .HasColumnType("int");

                    b.Property<int>("IzletID")
                        .HasColumnType("int");

                    b.HasKey("DijeteID", "IzletID");

                    b.HasIndex("IzletID");

                    b.ToTable("DijeteIzlet");
                });

            modelBuilder.Entity("KinderGarten.Models.DijeteOvlastenaOsoba", b =>
                {
                    b.Property<int>("DijeteID")
                        .HasColumnType("int");

                    b.Property<int>("OvlastenaOsobaID")
                        .HasColumnType("int");

                    b.HasKey("DijeteID", "OvlastenaOsobaID");

                    b.HasIndex("OvlastenaOsobaID");

                    b.ToTable("DijeteOvlastenaOsoba");
                });

            modelBuilder.Entity("KinderGarten.Models.Drzava", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("KinderGarten.Models.Evidencija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DijeteID")
                        .HasColumnType("int");

                    b.Property<bool>("Odlazak")
                        .HasColumnType("bit");

                    b.Property<int>("OvlastenaOsobaID")
                        .HasColumnType("int");

                    b.Property<int>("RadniListID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Vrijeme")
                        .HasColumnType("datetime2");

                    b.Property<int>("ZaposlenikID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DijeteID");

                    b.HasIndex("OvlastenaOsobaID");

                    b.HasIndex("RadniListID");

                    b.HasIndex("ZaposlenikID");

                    b.ToTable("Evidencija");
                });

            modelBuilder.Entity("KinderGarten.Models.Grad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostanskiBroj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("KinderGarten.Models.Grupa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Grupa");
                });

            modelBuilder.Entity("KinderGarten.Models.Izlet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumIzletaDo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumIzletaOd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lokacija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZaposlenikID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ZaposlenikID");

                    b.ToTable("Izlet");
                });

            modelBuilder.Entity("KinderGarten.Models.OvlastenaOsoba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktivan")
                        .HasColumnType("bit");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PutanjaSlike")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StrucnaSpremaID")
                        .HasColumnType("int");

                    b.Property<bool>("Zaposlen")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("StrucnaSpremaID");

                    b.ToTable("OvlastenaOsoba");
                });

            modelBuilder.Entity("KinderGarten.Models.RadniList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("GrupaID")
                        .HasColumnType("int");

                    b.Property<int>("Zaposlenik1ID")
                        .HasColumnType("int");

                    b.Property<int>("Zaposlenik2ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GrupaID");

                    b.HasIndex("Zaposlenik1ID");

                    b.HasIndex("Zaposlenik2ID");

                    b.ToTable("RadniList");
                });

            modelBuilder.Entity("KinderGarten.Models.Roditelj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PutanjaSlike")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roditelj");
                });

            modelBuilder.Entity("KinderGarten.Models.Seminar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Certifikat")
                        .HasColumnType("bit");

                    b.Property<int>("GradID")
                        .HasColumnType("int");

                    b.Property<DateTime>("VrijemeSeminaraDo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VrijemeSeminaraOd")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("GradID");

                    b.ToTable("Seminar");
                });

            modelBuilder.Entity("KinderGarten.Models.StrucnaSprema", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("StrucnaSprema");
                });

            modelBuilder.Entity("KinderGarten.Models.Uplata", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumUplate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DijeteID")
                        .HasColumnType("int");

                    b.Property<decimal>("Iznos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OvlastenaOsobaID")
                        .HasColumnType("int");

                    b.Property<int>("VrstaUplateID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DijeteID");

                    b.HasIndex("OvlastenaOsobaID");

                    b.HasIndex("VrstaUplateID");

                    b.ToTable("Uplata");
                });

            modelBuilder.Entity("KinderGarten.Models.VrstaUplate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Vrsta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("VrstaUplate");
                });

            modelBuilder.Entity("KinderGarten.Models.Zanimanje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Zanimanje");
                });

            modelBuilder.Entity("KinderGarten.Models.Zaposlenik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PutanjaSlike")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StrucnaSpremaID")
                        .HasColumnType("int");

                    b.Property<int>("ZanimanjeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StrucnaSpremaID");

                    b.HasIndex("ZanimanjeID");

                    b.ToTable("Zaposlenik");
                });

            modelBuilder.Entity("KinderGarten.Models.ZaposlenikSeminar", b =>
                {
                    b.Property<int>("ZaposlenikID")
                        .HasColumnType("int");

                    b.Property<int>("SeminarID")
                        .HasColumnType("int");

                    b.HasKey("ZaposlenikID", "SeminarID");

                    b.HasIndex("SeminarID");

                    b.ToTable("ZaposlenikSeminar");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("KinderGarten.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("KinderGarten.Models.Dijete", b =>
                {
                    b.HasOne("KinderGarten.Models.Grupa", "Grupa")
                        .WithMany()
                        .HasForeignKey("GrupaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinderGarten.Models.Roditelj", "Roditelj")
                        .WithMany()
                        .HasForeignKey("RoditeljID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinderGarten.Models.DijeteIzlet", b =>
                {
                    b.HasOne("KinderGarten.Models.Dijete", "Dijete")
                        .WithMany()
                        .HasForeignKey("DijeteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinderGarten.Models.Izlet", "Izlet")
                        .WithMany()
                        .HasForeignKey("IzletID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinderGarten.Models.DijeteOvlastenaOsoba", b =>
                {
                    b.HasOne("KinderGarten.Models.Dijete", "Dijete")
                        .WithMany()
                        .HasForeignKey("DijeteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinderGarten.Models.OvlastenaOsoba", "OvlastenaOsoba")
                        .WithMany()
                        .HasForeignKey("OvlastenaOsobaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinderGarten.Models.Evidencija", b =>
                {
                    b.HasOne("KinderGarten.Models.Dijete", "Dijete")
                        .WithMany()
                        .HasForeignKey("DijeteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinderGarten.Models.OvlastenaOsoba", "OvlastenaOsoba")
                        .WithMany()
                        .HasForeignKey("OvlastenaOsobaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinderGarten.Models.RadniList", "RadniList")
                        .WithMany()
                        .HasForeignKey("RadniListID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinderGarten.Models.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinderGarten.Models.Grad", b =>
                {
                    b.HasOne("KinderGarten.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinderGarten.Models.Izlet", b =>
                {
                    b.HasOne("KinderGarten.Models.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinderGarten.Models.OvlastenaOsoba", b =>
                {
                    b.HasOne("KinderGarten.Models.StrucnaSprema", "StrucnaSprema")
                        .WithMany()
                        .HasForeignKey("StrucnaSpremaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinderGarten.Models.RadniList", b =>
                {
                    b.HasOne("KinderGarten.Models.Grupa", "Grupa")
                        .WithMany()
                        .HasForeignKey("GrupaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinderGarten.Models.Zaposlenik", "ZaposlenikPrvaSmjena")
                        .WithMany()
                        .HasForeignKey("Zaposlenik1ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinderGarten.Models.Zaposlenik", "ZaposlenikDrugaSmjena")
                        .WithMany()
                        .HasForeignKey("Zaposlenik2ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinderGarten.Models.Seminar", b =>
                {
                    b.HasOne("KinderGarten.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinderGarten.Models.Uplata", b =>
                {
                    b.HasOne("KinderGarten.Models.Dijete", "Dijete")
                        .WithMany()
                        .HasForeignKey("DijeteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinderGarten.Models.OvlastenaOsoba", "OvlastenaOsoba")
                        .WithMany()
                        .HasForeignKey("OvlastenaOsobaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinderGarten.Models.VrstaUplate", "VrstaUplate")
                        .WithMany()
                        .HasForeignKey("VrstaUplateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinderGarten.Models.Zaposlenik", b =>
                {
                    b.HasOne("KinderGarten.Models.StrucnaSprema", "StrucnaSprema")
                        .WithMany()
                        .HasForeignKey("StrucnaSpremaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinderGarten.Models.Zanimanje", "Zanimanje")
                        .WithMany()
                        .HasForeignKey("ZanimanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinderGarten.Models.ZaposlenikSeminar", b =>
                {
                    b.HasOne("KinderGarten.Models.Seminar", "Seminar")
                        .WithMany()
                        .HasForeignKey("SeminarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KinderGarten.Models.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IZ.Model.DBModels
{
    public partial class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IzvjestajDefinicija> IzvjestajDefinicija { get; set; }
        public virtual DbSet<IzvjestajElementi> IzvjestajElementi { get; set; }
        public virtual DbSet<IzvjestajTip> IzvjestajTip { get; set; }
        public virtual DbSet<IzvjestajXsdshema> IzvjestajXsdshema { get; set; }
        public virtual DbSet<IzvjestajiGenerisani> IzvjestajiGenerisani { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=DesignSaoOsig1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IzvjestajDefinicija>(entity =>
            {
                entity.ToTable("IzvjestajDefinicija", "Agencija");

                entity.Property(e => e.DatumAzuriranja).HasColumnType("datetime");

                entity.Property(e => e.DatumUnosa)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IzvjestajXsdshemaiId).HasColumnName("IzvjestajXSDshemaiId");

                entity.Property(e => e.KorisnikAzurirao)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('dbo')");

                entity.Property(e => e.KorisnikUnosa)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('dbo')");

                entity.Property(e => e.KratkiNaziv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.IzvjestajTip)
                    .WithMany(p => p.IzvjestajDefinicija)
                    .HasForeignKey(d => d.IzvjestajTipId)
                    .HasConstraintName("FK_IzvjestajDefinicija_IzvjestajTip");

                entity.HasOne(d => d.IzvjestajXsdshemai)
                    .WithMany(p => p.IzvjestajDefinicija)
                    .HasForeignKey(d => d.IzvjestajXsdshemaiId)
                    .HasConstraintName("FK_IzvjestajDefinicija_IzvjestajXSDshema");
            });

            modelBuilder.Entity<IzvjestajElementi>(entity =>
            {
                entity.ToTable("IzvjestajElementi", "Agencija");

                entity.Property(e => e.DatumAzuriranja).HasColumnType("datetime");

                entity.Property(e => e.DatumUnosa)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Element)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ElementVrijednosti)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.KorisnikAzurirao)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('dbo')");

                entity.Property(e => e.KorisnikUnosa)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('dbo')");

                entity.HasOne(d => d.IzvjestajDefinicija)
                    .WithMany(p => p.IzvjestajElementi)
                    .HasForeignKey(d => d.IzvjestajDefinicijaId)
                    .HasConstraintName("FK_IzvjestajElementi_IzvjestajDefinicija");
            });

            modelBuilder.Entity<IzvjestajTip>(entity =>
            {
                entity.ToTable("IzvjestajTip", "Agencija");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IzvjestajXsdshema>(entity =>
            {
                entity.HasKey(e => e.IzvjestajXsdshemaiId);

                entity.ToTable("IzvjestajXSDshema", "Agencija");

                entity.Property(e => e.IzvjestajXsdshemaiId).HasColumnName("IzvjestajXSDshemaiId");

                entity.Property(e => e.DatumAzuriranja).HasColumnType("datetime");

                entity.Property(e => e.DatumUnosa)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HederXls)
                    .IsRequired()
                    .HasColumnName("HederXLS");

                entity.Property(e => e.KorisnikAzurirao)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('dbo')");

                entity.Property(e => e.KorisnikUnosa)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('dbo')");

                entity.Property(e => e.Shema)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IzvjestajiGenerisani>(entity =>
            {
                entity.ToTable("IzvjestajiGenerisani", "Agencija");

                entity.Property(e => e.DatumAzuriranja).HasColumnType("datetime");

                entity.Property(e => e.DatumDo).HasColumnType("datetime");

                entity.Property(e => e.DatumKreiranja).HasColumnType("date");

                entity.Property(e => e.DatumOd).HasColumnType("datetime");

                entity.Property(e => e.DatumUnosa)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImportedExcel)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Izvjestaj)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.IzvjestajXsdshemaiId).HasColumnName("IzvjestajXSDshemaiId");

                entity.Property(e => e.KorisnikAzurirao)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('dbo')");

                entity.Property(e => e.KorisnikUnosa)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('dbo')");

                entity.Property(e => e.NazivXmlfajla)
                    .IsRequired()
                    .HasColumnName("NazivXMLFajla")
                    .HasMaxLength(250);

                entity.HasOne(d => d.IzvjestajDefinicija)
                    .WithMany(p => p.IzvjestajiGenerisani)
                    .HasForeignKey(d => d.IzvjestajDefinicijaId)
                    .HasConstraintName("FK_IzvjestajGenerisani_IzvjestajDefinicija");

                entity.HasOne(d => d.IzvjestajXsdshemai)
                    .WithMany(p => p.IzvjestajiGenerisani)
                    .HasForeignKey(d => d.IzvjestajXsdshemaiId)
                    .HasConstraintName("FK_IzvjestajGenerisani_IzvjestajXSDshema");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

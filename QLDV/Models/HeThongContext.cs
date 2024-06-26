﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLDV.Models
{
    public partial class HeThongContext : DbContext
    {
        public HeThongContext()
        {
        }

        public HeThongContext(DbContextOptions<HeThongContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CanBo> CanBoes { get; set; }
        public virtual DbSet<ChucNang> ChucNangs { get; set; }
        public virtual DbSet<Diem> Diems { get; set; }
        public virtual DbSet<DiemDanh> DiemDanhs { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<Khhl> Khhls { get; set; }
        public virtual DbSet<KhhlDv> KhhlDvs { get; set; }
        public virtual DbSet<LichHl> LichHls { get; set; }
        public virtual DbSet<LoaiDonVi> LoaiDonVis { get; set; }
        public virtual DbSet<LoaiTb> LoaiTbs { get; set; }
        public virtual DbSet<NhomTb> NhomTbs { get; set; }
        public virtual DbSet<QCn> QCns { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThietBi> ThietBis { get; set; }
        public virtual DbSet<Tkdiem> Tkdiems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=MyDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CanBo>(entity =>
            {
                entity.ToTable("CanBo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CapBac).HasMaxLength(20);

                entity.Property(e => e.Cccd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CCCD");

                entity.Property(e => e.ChucVu).HasMaxLength(20);

                entity.Property(e => e.HocHam).HasMaxLength(20);

                entity.Property(e => e.HocVi).HasMaxLength(20);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Quequan).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.HasOne(d => d.IdDonViNavigation)
                    .WithMany(p => p.CanBoes)
                    .HasForeignKey(d => d.IdDonVi)
                    .HasConstraintName("FK_CanBo_DonVi");
            });

            modelBuilder.Entity<ChucNang>(entity =>
            {
                entity.ToTable("ChucNang");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ten)
                    .HasMaxLength(10)
                    .HasColumnName("ten");
            });

            modelBuilder.Entity<Diem>(entity =>
            {
                entity.HasKey(e => new { e.HocVienId, e.Khhlid })
                    .HasName("PK__Diem__3F7816F777879B20");

                entity.ToTable("Diem");

                entity.Property(e => e.HocVienId).HasColumnName("HocVienID");

                entity.Property(e => e.Khhlid).HasColumnName("KHHLID");

                entity.Property(e => e.Diem1).HasColumnName("Diem");

                entity.HasOne(d => d.HocVien)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.HocVienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diem_HocVien");
            });

            modelBuilder.Entity<DiemDanh>(entity =>
            {
                entity.HasKey(e => new { e.HocVienId, e.LichHlid });

                entity.ToTable("DiemDanh");

                entity.Property(e => e.HocVienId).HasColumnName("HocVienID");

                entity.Property(e => e.LichHlid).HasColumnName("LichHLid");

                entity.Property(e => e.Comat).HasColumnName("comat");

                entity.HasOne(d => d.HocVien)
                    .WithMany(p => p.DiemDanhs)
                    .HasForeignKey(d => d.HocVienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiemDanh_HocVien");

                entity.HasOne(d => d.LichHl)
                    .WithMany(p => p.DiemDanhs)
                    .HasForeignKey(d => d.LichHlid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiemDanh_Lich_HL");
            });

            modelBuilder.Entity<DonVi>(entity =>
            {
                entity.ToTable("DonVi");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.IdLoaiDv).HasColumnName("IdLoaiDV");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.SoHieu)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Ten)
                    .HasMaxLength(50)
                    .HasColumnName("ten");

                entity.HasOne(d => d.IdCapTrenNavigation)
                    .WithMany(p => p.InverseIdCapTrenNavigation)
                    .HasForeignKey(d => d.IdCapTren)
                    .HasConstraintName("FK_DonVi_DonVi");

                entity.HasOne(d => d.IdLoaiDvNavigation)
                    .WithMany(p => p.DonVis)
                    .HasForeignKey(d => d.IdLoaiDv)
                    .HasConstraintName("FK_DonVi_LoaiDonVi");
            });

            modelBuilder.Entity<HocVien>(entity =>
            {
                entity.ToTable("HocVien");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CapBac).HasMaxLength(20);

                entity.Property(e => e.Cccd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CCCD");

                entity.Property(e => e.Gioitinh).HasMaxLength(20);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Quequan).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.HasOne(d => d.IdDonViNavigation)
                    .WithMany(p => p.HocViens)
                    .HasForeignKey(d => d.IdDonVi)
                    .HasConstraintName("FK_HocVien_DonVi");
            });

            modelBuilder.Entity<Khhl>(entity =>
            {
                entity.ToTable("KHHL");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdDv).HasColumnName("idDV");

                entity.Property(e => e.IdKhcha).HasColumnName("idKHCha");

                entity.Property(e => e.MaKhhl)
                    .HasMaxLength(20)
                    .HasColumnName("MaKHHL")
                    .IsFixedLength(true);

                entity.Property(e => e.Ngaylap)
                    .HasColumnType("date")
                    .HasColumnName("ngaylap");

                entity.Property(e => e.Noidung)
                    .HasMaxLength(100)
                    .HasColumnName("noidung");

                entity.Property(e => e.Tgbatdau)
                    .HasColumnType("date")
                    .HasColumnName("tgbatdau");

                entity.Property(e => e.Tgketthuc)
                    .HasColumnType("date")
                    .HasColumnName("tgketthuc");

                entity.Property(e => e.Tongnbuoihoc).HasColumnName("tongnbuoihoc");

                entity.Property(e => e.Tongtiethoc).HasColumnName("tongtiethoc");

                entity.HasOne(d => d.IdDvNavigation)
                    .WithMany(p => p.Khhls)
                    .HasForeignKey(d => d.IdDv)
                    .HasConstraintName("FK_KHHL_DonVi2");

                entity.HasOne(d => d.IdKhchaNavigation)
                    .WithMany(p => p.InverseIdKhchaNavigation)
                    .HasForeignKey(d => d.IdKhcha)
                    .HasConstraintName("FK_KHHL_KHHL");
            });

            modelBuilder.Entity<KhhlDv>(entity =>
            {
                entity.HasKey(e => new { e.IdDv, e.IdKhhl });

                entity.ToTable("KHHL_DV");

                entity.Property(e => e.IdDv).HasColumnName("idDV");

                entity.Property(e => e.IdKhhl).HasColumnName("idKHHL");

                entity.HasOne(d => d.IdDvNavigation)
                    .WithMany(p => p.KhhlDvs)
                    .HasForeignKey(d => d.IdDv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KHHL_DV_DonVi");

                entity.HasOne(d => d.IdKhhlNavigation)
                    .WithMany(p => p.KhhlDvs)
                    .HasForeignKey(d => d.IdKhhl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KHHL_DV_KHHL");
            });

            modelBuilder.Entity<LichHl>(entity =>
            {
                entity.ToTable("Lich_HL");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdKhhl).HasColumnName("IdKHHL");

                entity.Property(e => e.Ngay)
                    .HasColumnType("date")
                    .HasColumnName("ngay");

                entity.Property(e => e.Tietbatdau).HasColumnName("tietbatdau");

                entity.Property(e => e.Tietketthuc).HasColumnName("tietketthuc");

                entity.Property(e => e.Tongtiethoc).HasColumnName("tongtiethoc");

                entity.HasOne(d => d.IdKhhlNavigation)
                    .WithMany(p => p.LichHls)
                    .HasForeignKey(d => d.IdKhhl)
                    .HasConstraintName("FK_Lich_HL_KHHL");
            });

            modelBuilder.Entity<LoaiDonVi>(entity =>
            {
                entity.ToTable("LoaiDonVi");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TenNhom).HasMaxLength(50);
            });

            modelBuilder.Entity<LoaiTb>(entity =>
            {
                entity.ToTable("LoaiTb");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Donvi)
                    .HasMaxLength(50)
                    .HasColumnName("donvi");

                entity.Property(e => e.IdNhomTb).HasColumnName("IdNhomTB");

                entity.Property(e => e.SoLuong)
                    .HasColumnName("soLuong")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TenLoai).HasMaxLength(50);

                entity.HasOne(d => d.IdNhomTbNavigation)
                    .WithMany(p => p.LoaiTbs)
                    .HasForeignKey(d => d.IdNhomTb)
                    .HasConstraintName("FK_LoaiTB_NhomTB");
            });

            modelBuilder.Entity<NhomTb>(entity =>
            {
                entity.ToTable("NhomTB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TenNhom).HasMaxLength(50);
            });

            modelBuilder.Entity<QCn>(entity =>
            {
                entity.HasKey(e => new { e.IdCn, e.IdQuyen });

                entity.ToTable("Q_CN");

                entity.Property(e => e.IdCn).HasColumnName("idCN");

                entity.Property(e => e.IdQuyen).HasColumnName("idQuyen");

                entity.HasOne(d => d.IdCnNavigation)
                    .WithMany(p => p.QCns)
                    .HasForeignKey(d => d.IdCn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Q_CN_ChucNang");

                entity.HasOne(d => d.IdQuyenNavigation)
                    .WithMany(p => p.QCns)
                    .HasForeignKey(d => d.IdQuyen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Q_CN_Quyen");
            });

            modelBuilder.Entity<Quyen>(entity =>
            {
                entity.ToTable("Quyen");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ten)
                    .HasMaxLength(20)
                    .HasColumnName("ten");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.ToTable("TaiKhoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdCb).HasColumnName("idCB");

                entity.Property(e => e.IdQuyen).HasColumnName("idQuyen");

                entity.Property(e => e.Mk)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MK");

                entity.Property(e => e.TenTk)
                    .HasMaxLength(50)
                    .HasColumnName("tenTK");

                entity.HasOne(d => d.IdCbNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.IdCb)
                    .HasConstraintName("FK_TaiKhoan_CanBo");

                entity.HasOne(d => d.IdQuyenNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.IdQuyen)
                    .HasConstraintName("FK_TaiKhoan_Quyen");
            });

            modelBuilder.Entity<ThietBi>(entity =>
            {
                entity.ToTable("ThietBi");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Donvi)
                    .HasMaxLength(50)
                    .HasColumnName("donvi");

                entity.Property(e => e.IdLoaiTb).HasColumnName("IdLoaiTB");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.Property(e => e.TenTb)
                    .HasMaxLength(50)
                    .HasColumnName("tenTB");

                entity.HasOne(d => d.IdDonViNavigation)
                    .WithMany(p => p.ThietBis)
                    .HasForeignKey(d => d.IdDonVi)
                    .HasConstraintName("FK_ThieBi_DonVi");

                entity.HasOne(d => d.IdLoaiTbNavigation)
                    .WithMany(p => p.ThietBis)
                    .HasForeignKey(d => d.IdLoaiTb)
                    .HasConstraintName("FK_ThieBi_LoaiTB");
            });

            modelBuilder.Entity<Tkdiem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TKDiem");

                entity.Property(e => e.IdDv).HasColumnName("idDv");

                entity.Property(e => e.IdDvcha).HasColumnName("idDVcha");

                entity.Property(e => e.MaKhhl).HasColumnName("MaKHHL");

                entity.Property(e => e.TenKhhl)
                    .HasMaxLength(100)
                    .HasColumnName("TenKHHL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

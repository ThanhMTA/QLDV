using System;
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
        public virtual DbSet<ChuyenCan> ChuyenCans { get; set; }
        public virtual DbSet<Diem> Diems { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<Khhl> Khhls { get; set; }
        public virtual DbSet<LoaiDonVi> LoaiDonVis { get; set; }
        public virtual DbSet<LoaiTb> LoaiTbs { get; set; }
        public virtual DbSet<Nhom> Nhoms { get; set; }
        public virtual DbSet<NhomTb> NhomTbs { get; set; }
        public virtual DbSet<NhomTk> NhomTks { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<QuyenNhom> QuyenNhoms { get; set; }
        public virtual DbSet<QuyenTk> QuyenTks { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThietBi> ThietBis { get; set; }

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

            modelBuilder.Entity<ChuyenCan>(entity =>
            {
                entity.HasKey(e => new { e.HocVienId, e.IdKhhl })
                    .HasName("PK__ChuyenCa__4222BE7C5CA5C9FA");

                entity.ToTable("ChuyenCan");

                entity.Property(e => e.HocVienId).HasColumnName("HocVienID");

                entity.Property(e => e.IdKhhl).HasColumnName("ID_KHHL");

                entity.HasOne(d => d.HocVien)
                    .WithMany(p => p.ChuyenCans)
                    .HasForeignKey(d => d.HocVienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChuyenCan_HocVien");

                entity.HasOne(d => d.IdKhhlNavigation)
                    .WithMany(p => p.ChuyenCans)
                    .HasForeignKey(d => d.IdKhhl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChuyenCan_KHHL");
            });

            modelBuilder.Entity<Diem>(entity =>
            {
                entity.HasKey(e => new { e.HocVienId, e.Khhlid })
                    .HasName("PK__Diem__EB0811D7DBC78853");

                entity.ToTable("Diem");

                entity.Property(e => e.HocVienId).HasColumnName("HocVienID");

                entity.Property(e => e.Khhlid).HasColumnName("KHHLID");

                entity.Property(e => e.Diem1).HasColumnName("Diem");

                entity.HasOne(d => d.HocVien)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.HocVienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diem_HocVien");

                entity.HasOne(d => d.Khhl)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.Khhlid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diem_KHHL");
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
                    .WithMany(p => p.HocViens)
                    .HasForeignKey(d => d.IdDonVi)
                    .HasConstraintName("FK_HocVien_DonVi");
            });

            modelBuilder.Entity<Khhl>(entity =>
            {
                entity.ToTable("KHHL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DonViId).HasColumnName("DonViID");

                entity.Property(e => e.NgayLap).HasColumnType("date");

                entity.Property(e => e.TenMonHoc)
                    .HasMaxLength(30)
                    .HasColumnName("tenMonHoc");

                entity.HasOne(d => d.DonVi)
                    .WithMany(p => p.Khhls)
                    .HasForeignKey(d => d.DonViId)
                    .HasConstraintName("FK_KHHL_DonVi");
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

            modelBuilder.Entity<Nhom>(entity =>
            {
                entity.ToTable("Nhom");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ten)
                    .HasMaxLength(20)
                    .HasColumnName("ten");
            });

            modelBuilder.Entity<NhomTb>(entity =>
            {
                entity.ToTable("NhomTB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TenNhom).HasMaxLength(50);
            });

            modelBuilder.Entity<NhomTk>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Nhom_TK");

                entity.Property(e => e.IdNhom).HasColumnName("idNhom");

                entity.Property(e => e.IdTk).HasColumnName("idTK");

                entity.HasOne(d => d.IdNhomNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdNhom)
                    .HasConstraintName("FK_Nhom_TK_Nhom");

                entity.HasOne(d => d.IdTkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTk)
                    .HasConstraintName("FK_Nhom_TK_TaiKhoan");
            });

            modelBuilder.Entity<Quyen>(entity =>
            {
                entity.ToTable("Quyen");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ten)
                    .HasMaxLength(20)
                    .HasColumnName("ten");
            });

            modelBuilder.Entity<QuyenNhom>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Quyen_nhom");

                entity.Property(e => e.IdNhom).HasColumnName("idNhom");

                entity.Property(e => e.IdQuyen).HasColumnName("idQuyen");

                entity.HasOne(d => d.IdNhomNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdNhom)
                    .HasConstraintName("FK_Quyen_nhom_Nhom");

                entity.HasOne(d => d.IdQuyenNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdQuyen)
                    .HasConstraintName("FK_Quyen_nhom_Quyen");
            });

            modelBuilder.Entity<QuyenTk>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Quyen_TK");

                entity.Property(e => e.IdQuyen).HasColumnName("idQuyen");

                entity.Property(e => e.IdTk).HasColumnName("idTK");

                entity.HasOne(d => d.IdQuyenNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdQuyen)
                    .HasConstraintName("FK_Quyen_TK_Quyen");

                entity.HasOne(d => d.IdTkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTk)
                    .HasConstraintName("FK_Quyen_TK_TaiKhoan");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.ToTable("TaiKhoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdCb).HasColumnName("idCB");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

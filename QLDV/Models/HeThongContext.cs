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

        public virtual DbSet<BaiHoc> BaiHocs { get; set; }
        public virtual DbSet<CanBo> CanBoes { get; set; }
        public virtual DbSet<ChuyenCan> ChuyenCans { get; set; }
        public virtual DbSet<Diem> Diems { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<HocKi> HocKis { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<HocVienLopHoc> HocVienLopHocs { get; set; }
        public virtual DbSet<Khhl> Khhls { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<LoaiDonVi> LoaiDonVis { get; set; }
        public virtual DbSet<LoaiTb> LoaiTbs { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<NamHoc> NamHocs { get; set; }
        public virtual DbSet<Nhom> Nhoms { get; set; }
        public virtual DbSet<NhomDaoTao> NhomDaoTaos { get; set; }
        public virtual DbSet<NhomTb> NhomTbs { get; set; }
        public virtual DbSet<NhomTk> NhomTks { get; set; }
        public virtual DbSet<NoiDung> NoiDungs { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<QuyenNhom> QuyenNhoms { get; set; }
        public virtual DbSet<QuyenTk> QuyenTks { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThieBi> ThieBis { get; set; }

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

            modelBuilder.Entity<BaiHoc>(entity =>
            {
                entity.ToTable("BaiHoc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DonViId).HasColumnName("DonViID");

                entity.Property(e => e.MonHocId).HasColumnName("MonHocID");

                entity.Property(e => e.TenBaiHoc)
                    .HasMaxLength(100)
                    .HasColumnName("tenBaiHoc");

                entity.HasOne(d => d.DonVi)
                    .WithMany(p => p.BaiHocs)
                    .HasForeignKey(d => d.DonViId)
                    .HasConstraintName("FK_BaiHoc_DonVi");

                entity.HasOne(d => d.MonHoc)
                    .WithMany(p => p.BaiHocs)
                    .HasForeignKey(d => d.MonHocId)
                    .HasConstraintName("FK_BaiHoc_MonHoc");
            });

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
                entity.HasKey(e => new { e.HocVienId, e.MonHocId })
                    .HasName("PK__Diem__EB0811D7DBC78853");

                entity.ToTable("Diem");

                entity.Property(e => e.HocVienId).HasColumnName("HocVienID");

                entity.Property(e => e.MonHocId).HasColumnName("MonHocID");

                entity.HasOne(d => d.HocVien)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.HocVienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diem_HocVien");

                entity.HasOne(d => d.MonHoc)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.MonHocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diem_MonHoc");
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

            modelBuilder.Entity<HocKi>(entity =>
            {
                entity.ToTable("HocKi");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NamHoc)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.NamHocId).HasColumnName("NamHocID");

                entity.Property(e => e.NgayBatDau).HasColumnType("date");

                entity.Property(e => e.NgayKetThuc).HasColumnType("date");

                entity.HasOne(d => d.NamHocNavigation)
                    .WithMany(p => p.HocKis)
                    .HasForeignKey(d => d.NamHocId)
                    .HasConstraintName("FK_HocKi_NamHoc");
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

                entity.Property(e => e.LopH)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

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

                entity.HasOne(d => d.IdKhoaHocNavigation)
                    .WithMany(p => p.HocViens)
                    .HasForeignKey(d => d.IdKhoaHoc)
                    .HasConstraintName("FK_HocVien_KhoaHoc");

                entity.HasOne(d => d.IdNhomDaoTaoNavigation)
                    .WithMany(p => p.HocViens)
                    .HasForeignKey(d => d.IdNhomDaoTao)
                    .HasConstraintName("FK_HocVien_NhomDaoTao");
            });

            modelBuilder.Entity<HocVienLopHoc>(entity =>
            {
                entity.HasKey(e => new { e.HocVienId, e.LopHocId });

                entity.ToTable("HocVien_LopHoc");

                entity.Property(e => e.HocVienId).HasColumnName("HocVienID");

                entity.Property(e => e.LopHocId).HasColumnName("LopHocID");

                entity.HasOne(d => d.HocVien)
                    .WithMany(p => p.HocVienLopHocs)
                    .HasForeignKey(d => d.HocVienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HocVien_LopHoc_HocVien");

                entity.HasOne(d => d.LopHoc)
                    .WithMany(p => p.HocVienLopHocs)
                    .HasForeignKey(d => d.LopHocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HocVien_LopHoc_LopHoc");
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
            });

            modelBuilder.Entity<KhoaHoc>(entity =>
            {
                entity.ToTable("KhoaHoc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdNhomDaoTao).HasColumnName("idNhomDaoTao");

                entity.Property(e => e.Ngaybatdau)
                    .HasColumnType("date")
                    .HasColumnName("ngaybatdau");

                entity.Property(e => e.Ngayketthuc)
                    .HasColumnType("date")
                    .HasColumnName("ngayketthuc");

                entity.Property(e => e.TenKhoa).HasMaxLength(50);

                entity.HasOne(d => d.IdNhomDaoTaoNavigation)
                    .WithMany(p => p.KhoaHocs)
                    .HasForeignKey(d => d.IdNhomDaoTao)
                    .HasConstraintName("FK_KhoaHoc_NhomDaoTao");
            });

            modelBuilder.Entity<LoaiDonVi>(entity =>
            {
                entity.ToTable("LoaiDonVi");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TenNhom).HasMaxLength(50);
            });

            modelBuilder.Entity<LoaiTb>(entity =>
            {
                entity.ToTable("LoaiTB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdNhomTb).HasColumnName("IdNhomTB");

                entity.Property(e => e.TenLoai).HasMaxLength(50);

                entity.HasOne(d => d.IdNhomTbNavigation)
                    .WithMany(p => p.LoaiTbs)
                    .HasForeignKey(d => d.IdNhomTb)
                    .HasConstraintName("FK_LoaiTB_NhomTB");
            });

            modelBuilder.Entity<LopHoc>(entity =>
            {
                entity.ToTable("LopHoc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiaDiem).HasMaxLength(50);

                entity.Property(e => e.GiaoVienChinhId).HasColumnName("GiaoVienChinhID");

                entity.Property(e => e.GiaoVienId).HasColumnName("GiaoVienID");

                entity.Property(e => e.HocKiId).HasColumnName("HocKiID");

                entity.Property(e => e.TenLopHoc).HasMaxLength(50);

                entity.HasOne(d => d.GiaoVienChinh)
                    .WithMany(p => p.LopHocGiaoVienChinhs)
                    .HasForeignKey(d => d.GiaoVienChinhId)
                    .HasConstraintName("FK_LopHoc_CanBo");

                entity.HasOne(d => d.GiaoVien)
                    .WithMany(p => p.LopHocGiaoViens)
                    .HasForeignKey(d => d.GiaoVienId)
                    .HasConstraintName("FK_LopHoc_CanBo1");

                entity.HasOne(d => d.HocKi)
                    .WithMany(p => p.LopHocs)
                    .HasForeignKey(d => d.HocKiId)
                    .HasConstraintName("FK_LopHoc_HocKi");
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.ToTable("MonHoc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdKhhl).HasColumnName("ID_KHHL");

                entity.Property(e => e.TenMonHoc)
                    .HasMaxLength(30)
                    .HasColumnName("tenMonHoc");

                entity.HasOne(d => d.IdKhhlNavigation)
                    .WithMany(p => p.MonHocs)
                    .HasForeignKey(d => d.IdKhhl)
                    .HasConstraintName("FK_MonHoc_KHHL");
            });

            modelBuilder.Entity<NamHoc>(entity =>
            {
                entity.ToTable("NamHoc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NamHoc1)
                    .HasMaxLength(10)
                    .HasColumnName("NamHoc")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayBatDau).HasColumnType("date");

                entity.Property(e => e.NgayKetThuc).HasColumnType("date");
            });

            modelBuilder.Entity<Nhom>(entity =>
            {
                entity.ToTable("Nhom");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ten)
                    .HasMaxLength(20)
                    .HasColumnName("ten");
            });

            modelBuilder.Entity<NhomDaoTao>(entity =>
            {
                entity.ToTable("NhomDaoTao");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TenNhom).HasMaxLength(50);
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

            modelBuilder.Entity<NoiDung>(entity =>
            {
                entity.ToTable("NoiDung");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BaiHocId).HasColumnName("BaiHocID");

                entity.Property(e => e.GiaoVienId).HasColumnName("GiaoVienID");

                entity.Property(e => e.NoiDungBaiHoc).HasMaxLength(100);

                entity.Property(e => e.ThoiGianLap).HasColumnType("date");

                entity.HasOne(d => d.BaiHoc)
                    .WithMany(p => p.NoiDungs)
                    .HasForeignKey(d => d.BaiHocId)
                    .HasConstraintName("FK_NoiDung_BaiHoc");

                entity.HasOne(d => d.GiaoVien)
                    .WithMany(p => p.NoiDungs)
                    .HasForeignKey(d => d.GiaoVienId)
                    .HasConstraintName("FK_NoiDung_CanBo");
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

            modelBuilder.Entity<ThieBi>(entity =>
            {
                entity.ToTable("ThieBi");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdLoaiTb).HasColumnName("IdLoaiTB");

                entity.Property(e => e.TenTb)
                    .HasMaxLength(50)
                    .HasColumnName("tenTB");

                entity.HasOne(d => d.IdDonViNavigation)
                    .WithMany(p => p.ThieBis)
                    .HasForeignKey(d => d.IdDonVi)
                    .HasConstraintName("FK_ThieBi_DonVi");

                entity.HasOne(d => d.IdLoaiTbNavigation)
                    .WithMany(p => p.ThieBis)
                    .HasForeignKey(d => d.IdLoaiTb)
                    .HasConstraintName("FK_ThieBi_LoaiTB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class HocVien
    {
        public HocVien()
        {
            ChuyenCans = new HashSet<ChuyenCan>();
            Diems = new HashSet<Diem>();
            HocVienLopHocs = new HashSet<HocVienLopHoc>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Quequan { get; set; }
        public string CapBac { get; set; }
        public string ChucVu { get; set; }
        public string HocHam { get; set; }
        public string HocVi { get; set; }
        public string Sdt { get; set; }
        public string Cccd { get; set; }
        public int? IdDonVi { get; set; }
        public int? IdNhomDaoTao { get; set; }
        public int? IdKhoaHoc { get; set; }
        public string LopH { get; set; }

        public virtual DonVi IdDonViNavigation { get; set; }
        public virtual KhoaHoc IdKhoaHocNavigation { get; set; }
        public virtual NhomDaoTao IdNhomDaoTaoNavigation { get; set; }
        public virtual ICollection<ChuyenCan> ChuyenCans { get; set; }
        public virtual ICollection<Diem> Diems { get; set; }
        public virtual ICollection<HocVienLopHoc> HocVienLopHocs { get; set; }
    }
}

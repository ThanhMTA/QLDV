using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class DonVi
    {
        public DonVi()
        {
            BaiHocs = new HashSet<BaiHoc>();
            CanBoes = new HashSet<CanBo>();
            HocViens = new HashSet<HocVien>();
            InverseIdCapTrenNavigation = new HashSet<DonVi>();
            ThietBis = new HashSet<ThietBi>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public int? IdCapTren { get; set; }
        public int? IdLoaiDv { get; set; }
        public string SoHieu { get; set; }

        public virtual DonVi IdCapTrenNavigation { get; set; }
        public virtual LoaiDonVi IdLoaiDvNavigation { get; set; }
        public virtual ICollection<BaiHoc> BaiHocs { get; set; }
        public virtual ICollection<CanBo> CanBoes { get; set; }
        public virtual ICollection<HocVien> HocViens { get; set; }
        public virtual ICollection<DonVi> InverseIdCapTrenNavigation { get; set; }
        public virtual ICollection<ThietBi> ThietBis { get; set; }
    }
}

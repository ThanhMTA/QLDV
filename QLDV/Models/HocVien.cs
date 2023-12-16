using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class HocVien
    {
        public HocVien()
        {
            DiemDanhs = new HashSet<DiemDanh>();
            Diems = new HashSet<Diem>();
            HvKhhls = new HashSet<HvKhhl>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Quequan { get; set; }
        public string CapBac { get; set; }
        public string Sdt { get; set; }
        public string Cccd { get; set; }
        public int? IdDonVi { get; set; }

        public virtual DonVi IdDonViNavigation { get; set; }
        public virtual ICollection<DiemDanh> DiemDanhs { get; set; }
        public virtual ICollection<Diem> Diems { get; set; }
        public virtual ICollection<HvKhhl> HvKhhls { get; set; }
    }
}

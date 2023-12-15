using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class CanBo
    {
        public CanBo()
        {
            TaiKhoans = new HashSet<TaiKhoan>();
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

        public virtual DonVi IdDonViNavigation { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}

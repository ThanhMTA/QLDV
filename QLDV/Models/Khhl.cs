using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class Khhl
    {
        public Khhl()
        {
            HvKhhls = new HashSet<HvKhhl>();
            KhhlDvs = new HashSet<KhhlDv>();
            LichHls = new HashSet<LichHl>();
        }

        public int Id { get; set; }
        public string Noidung { get; set; }
        public DateTime? Tgbatdau { get; set; }
        public DateTime? Tgketthuc { get; set; }
        public double? Tongtiethoc { get; set; }
        public DateTime? Ngaylap { get; set; }
        public string MaKhhl { get; set; }
        public int? IdDv { get; set; }

        public virtual DonVi IdDvNavigation { get; set; }
        public virtual ICollection<HvKhhl> HvKhhls { get; set; }
        public virtual ICollection<KhhlDv> KhhlDvs { get; set; }
        public virtual ICollection<LichHl> LichHls { get; set; }
    }
}

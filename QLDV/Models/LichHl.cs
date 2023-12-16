using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class LichHl
    {
        public LichHl()
        {
            DiemDanhs = new HashSet<DiemDanh>();
        }

        public int Id { get; set; }
        public DateTime? Ngay { get; set; }
        public int? Tietbatdau { get; set; }
        public int? Tietketthuc { get; set; }
        public int? Tongtiethoc { get; set; }
        public int? IdKhhl { get; set; }

        public virtual Khhl IdKhhlNavigation { get; set; }
        public virtual ICollection<DiemDanh> DiemDanhs { get; set; }
    }
}

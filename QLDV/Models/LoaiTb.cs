using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class LoaiTb
    {
        public LoaiTb()
        {
            ThieBis = new HashSet<ThieBi>();
        }

        public int Id { get; set; }
        public string TenLoai { get; set; }
        public int? IdNhomTb { get; set; }

        public virtual NhomTb IdNhomTbNavigation { get; set; }
        public virtual ICollection<ThieBi> ThieBis { get; set; }
    }
}

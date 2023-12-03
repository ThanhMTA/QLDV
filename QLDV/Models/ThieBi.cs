using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class ThieBi
    {
        public ThieBi()
        {
            CapPhats = new HashSet<CapPhat>();
        }

        public int Id { get; set; }
        public string TenTb { get; set; }
        public int? IdLoaiTb { get; set; }

        public virtual LoaiTb IdLoaiTbNavigation { get; set; }
        public virtual ICollection<CapPhat> CapPhats { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class NhomTb
    {
        public NhomTb()
        {
            LoaiTbs = new HashSet<LoaiTb>();
        }

        public int Id { get; set; }
        public string TenNhom { get; set; }

        public virtual ICollection<LoaiTb> LoaiTbs { get; set; }
    }
}

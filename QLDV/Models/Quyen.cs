using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class Quyen
    {
        public Quyen()
        {
            QCns = new HashSet<QCn>();
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }

        public virtual ICollection<QCn> QCns { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}

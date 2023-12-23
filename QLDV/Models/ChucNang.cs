using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class ChucNang
    {
        public ChucNang()
        {
            QCns = new HashSet<QCn>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }

        public virtual ICollection<QCn> QCns { get; set; }
    }
}

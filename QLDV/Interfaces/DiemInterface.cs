using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLDV.Views;

namespace QLDV.Interfaces
{
    public interface DiemInterface
    {
        List<HocVienView> GetAll(int khhl,string dv );
        void Update(DiemView loai);
    }
}

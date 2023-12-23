using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Interfaces
{
    public interface TaiKhoanInterface
    {
        List<TaiKhoanView> GetAll();
        void Add(TaiKhoanView loai);
        void Update(TaiKhoanView loai);
        void Delete(int id);
    }
}

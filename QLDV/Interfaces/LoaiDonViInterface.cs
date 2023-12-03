using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Interfaces
{
    public interface LoaiDonViInterface
    {
        List<LoaiDonViView> GetAll();
        LoaiDonViView GetByID(int id);
        LoaiDonViView Add(LoaiDonViView loai);
        void Update(LoaiDonViView loai);
        void Delete(int id);
        List<LoaiDonViView> Search(string search);
    }
}

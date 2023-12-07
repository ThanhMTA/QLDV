using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Interfaces
{
    public interface CanBoInterface
    {
        List<CanBoView> GetAll(int id);
        CanBoView GetByID(int id);
        CanBoView Add(CanBoView loai);
        void Update(CanBoView loai);
        void Delete(int id);
        List<CanBoView> Search(string search);
        List<CanBoView> GetToDonVi (int id);
    }
}

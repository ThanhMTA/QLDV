using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Interfaces
{
    public interface DonViInterface
    {
        List<DonViView> GetAll();
        DonViView GetByID(int id);
        DonViView Add(DonViView loai);
        void Update(DonViView loai);
        void Delete(int id);
        List<DonViView> Search(string search);
        List<DonViView> GetAllSubordinates(int id);
        List<DonViView> GetAllLoai(int id);
    }
}

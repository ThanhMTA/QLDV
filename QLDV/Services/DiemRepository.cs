using Microsoft.EntityFrameworkCore;
using QLDV.Interfaces;
using QLDV.Models;
using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Services
{
    public class DiemRepository : DiemInterface
    {
        private readonly HeThongContext _context;

        public DiemRepository(HeThongContext context)
        {
            _context = context;
        }
        public List<HocVienView> GetAll(int khhl,string dv)
        {
            var subordinates = new List<HocVienView>();

            var idDV = _context.DonVis
                    .Where(lo => lo.Ten == dv)
                    .Select(lo => lo.Id)
                    .SingleOrDefault();
            var loais = _context.DiemHVs.FromSqlRaw($"GetAllDiemHV {idDV},{khhl}").ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new HocVienView
                {
                    Id = subUnit.Id,
                    Ten = subUnit.Ten,
                    Ngaysinh = subUnit.Ngaysinh,
                    Quequan = subUnit.Quequan,
                    CapBac = subUnit.CapBac,
                    Sdt = subUnit.Sdt,
                    Cccd = subUnit.Cccd,
                    Diem=subUnit.Diem
                });



            }
            return subordinates;
        }
        public void Update(HocVienView loai)
        {
            throw new NotImplementedException();
        }
    }
}

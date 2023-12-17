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
            var loais = _context.Diems
            .FromSqlRaw($"EXEC GetAllDiemHV {idDV}, {khhl}" )
            .ToList();
   

            foreach (var subUnit in loais)
            {


                subordinates.Add(new HocVienView
                {
                    Id = subUnit.HocVienId,
                    Ten = _context.HocViens
                    .Where(lo => lo.Id == subUnit.HocVienId)
                    .Select(lo => lo.Ten)
                    .SingleOrDefault(),
                    Ngaysinh = _context.HocViens
                    .Where(lo => lo.Id == subUnit.HocVienId)
                    .Select(lo => lo.Ngaysinh)
                    .SingleOrDefault(),
                    Quequan = _context.HocViens
                    .Where(lo => lo.Id == subUnit.HocVienId)
                    .Select(lo => lo.Quequan)
                    .SingleOrDefault(),
                   CapBac= _context.HocViens
                    .Where(lo => lo.Id == subUnit.HocVienId)
                    .Select(lo => lo.CapBac)
                    .SingleOrDefault(),
                    Sdt = _context.HocViens
                    .Where(lo => lo.Id == subUnit.HocVienId)
                    .Select(lo => lo.Sdt)
                    .SingleOrDefault(),
                   Cccd = _context.HocViens
                    .Where(lo => lo.Id == subUnit.HocVienId)
                    .Select(lo => lo.Cccd)
                    .SingleOrDefault(),
                    Diem = subUnit.Diem1
                });



            }
            return subordinates;
        }
        public void Update(DiemView loai)
        {
            var hv = loai.HocVienId;
            var khhl = loai.Khhlid;
            var diem = loai.Diem1;
            _context.Database.ExecuteSqlInterpolated($"GetUpdateDiemHV {hv}, {khhl},{diem}");
        }
    }
}

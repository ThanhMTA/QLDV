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
    public class DiemDanhRepository : DiemDanhInterface
    {
        private readonly HeThongContext _context;

        public DiemDanhRepository(HeThongContext context)
        {
            _context = context;
        }
        public List<HocVienView> GetAll(int lichl, string dv)
        {
            var subordinates = new List<HocVienView>();

            var idDV = _context.DonVis
                    .Where(lo => lo.Ten == dv)
                    .Select(lo => lo.Id)
                    .SingleOrDefault();
            var loais = _context.DiemDanhs
            .FromSqlRaw($"EXEC GetAllDDHV {idDV}, {lichl}")
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
                    CapBac = _context.HocViens
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
                    Comat = subUnit.Comat
                });



            }
            return subordinates;
        }

        public List<DVHLView> GetDV(int lichhl)
        {
            var subordinates = new List<DVHLView>();


            var loais = _context.KhhlDvs.FromSqlRaw($"GetDDDV {lichhl}").ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new DVHLView
                {
                    IdKhhl = subUnit.IdKhhl,
                    DonVi = _context.DonVis
                        .Where(lo => lo.Id == subUnit.IdDv)
                        .Select(lo => lo.Ten)
                        .SingleOrDefault()
                });



            }
            return subordinates;
        }

        public void Update(DiemDanhView loai)
        {
            var hv = loai.HocVienId;
            var khhl = loai.LichHlid;
            var DiemDanh = loai.Comat;
            _context.Database.ExecuteSqlInterpolated($"GetUpdateDiemDanhHV {hv}, {khhl},{DiemDanh}");
        }
    }
}

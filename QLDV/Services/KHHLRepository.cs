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
    public class KHHLRepository : KHHLInterface
    {
        private readonly HeThongContext _context;

        public KHHLRepository(HeThongContext context)
        {
            _context = context;
        }
        #region add
        public void Add(KHHLView TB)
        {
            var ma = TB.MaKhhl;
            var noidung = TB.Noidung;
            var tgbatdau = TB.Tgbatdau;
            var tgKetThuc = TB.Tgketthuc;
            var sotiet = TB.Tongtiethoc;
            var ngayLap = TB.Ngaylap;
            var idDonVi = _context.DonVis
                     .Where(lo => lo.Ten == TB.DonVi)
                     .Select(lo => lo.Id)
                     .SingleOrDefault();

            _context.Database.ExecuteSqlInterpolated($"exec  AddKHHL {ma},{noidung},{tgbatdau}, {tgKetThuc},{sotiet},{ngayLap},{idDonVi}");
        }
        #endregion
        #region delete 

        public void Delete(int id)
        {
            _context.Database.ExecuteSqlInterpolated($"exec DeleteKHHL {id}");
        }
        #endregion
        #region getall
        public List<KHHLView> GetAll()
        {
            var subordinates = new List<KHHLView>();

            string proc = "exec GetALLKHHL";
            var loais = _context.Khhls.FromSqlRaw(proc).ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new KHHLView
                {
                    Id = subUnit.Id,
                    MaKhhl=subUnit.MaKhhl,
                    Noidung=subUnit.Noidung, 
                    Tgbatdau=subUnit.Tgbatdau, 
                    Tgketthuc=subUnit.Tgketthuc,
                    Tongtiethoc=subUnit.Tongtiethoc,
                    Ngaylap=subUnit.Ngaylap,
                    DonVi = _context.DonVis
                    .Where(lo => lo.Id == subUnit.IdDv)
                    .Select(lo => lo.Ten)
                    .SingleOrDefault()
                });



            }
            return subordinates;
        }
        public List<KHHLView> GetID(int id)
        {
            var subordinates = new List<KHHLView>();

        
            var loais = _context.Khhls.FromSqlRaw("GetIdKHHL {0}",id).ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new KHHLView
                {
                    Id = subUnit.Id,
                    MaKhhl = subUnit.MaKhhl,
                    Noidung = subUnit.Noidung,
                    Tgbatdau = subUnit.Tgbatdau,
                    Tgketthuc = subUnit.Tgketthuc,
                    Tongtiethoc = subUnit.Tongtiethoc,
                    Ngaylap = subUnit.Ngaylap,
                    DonVi = _context.DonVis
                    .Where(lo => lo.Id == subUnit.IdDv)
                    .Select(lo => lo.Ten)
                    .SingleOrDefault()
                });



            }
            return subordinates;
        }
        #endregion
        #region Filter 
        public List<KHHLView> Filter(int idDV)
        {
            var subordinates = new List<KHHLView>();


            var loais = _context.Khhls.FromSqlRaw(" FilterKHHL {0}", idDV).ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new KHHLView
                {
                    Id = subUnit.Id,
                    MaKhhl = subUnit.MaKhhl,
                    Noidung = subUnit.Noidung,
                    Tgbatdau = subUnit.Tgbatdau,
                    Tgketthuc = subUnit.Tgketthuc,
                    Tongtiethoc = subUnit.Tongtiethoc,
                    Ngaylap = subUnit.Ngaylap,
                    DonVi = _context.DonVis
                    .Where(lo => lo.Id == subUnit.IdDv)
                    .Select(lo => lo.Ten)
                    .SingleOrDefault()
                });



            }
            return subordinates;
        }
        #endregion
        #region search 
        public List<KHHLView> Search(string search, int idDV)
        {
            var subordinates = new List<KHHLView>();

            // Lấy đơn vị dựa trên ID



            var subordinateUnits = _context.Khhls.FromSqlRaw("SearchHV {0},{1}", search, idDV).ToList();

            foreach (var subUnit in subordinateUnits)
            {


                subordinates.Add(new KHHLView
                {
                    Id = subUnit.Id,
                    MaKhhl = subUnit.MaKhhl,
                    Noidung = subUnit.Noidung,
                    Tgbatdau = subUnit.Tgbatdau,
                    Tgketthuc = subUnit.Tgketthuc,
                    Tongtiethoc = subUnit.Tongtiethoc,
                    Ngaylap = subUnit.Ngaylap,
                    DonVi = _context.DonVis
                    .Where(lo => lo.Id == subUnit.IdDv)
                    .Select(lo => lo.Ten)
                    .SingleOrDefault()
                });



            }


            return subordinates;
        }
        #endregion
        #region Update 
        public void Update(KHHLView TB)
        {
            var id = TB.Id;
            var ma = TB.MaKhhl;
            var noidung = TB.Noidung;
            var tgbatdau = TB.Tgbatdau;
            var tgKetThuc = TB.Tgketthuc;
            var sotiet = TB.Tongtiethoc;
            var ngayLap = TB.Ngaylap;
            var idDonVi = _context.DonVis
                     .Where(lo => lo.Ten == TB.DonVi)
                     .Select(lo => lo.Id)
                     .SingleOrDefault();
            _context.Database.ExecuteSqlInterpolated($"UpdateKHHL {id}, {ma},{noidung},{tgbatdau}, {tgKetThuc},{sotiet},{ngayLap},{idDonVi}");
        }
        #endregion

    }
}

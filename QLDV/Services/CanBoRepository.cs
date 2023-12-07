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
    public class CanBoRepository : CanBoInterface
    {
        private readonly HeThongContext _context;

        public CanBoRepository(HeThongContext context)
        {
            _context = context;
        }
        #region add 
        public CanBoView Add(CanBoView cb)
        {
            var idDonVi = _context.DonVis
                                       .Where(lo => lo.Ten == cb.DonVi)
                                       .Select(lo => lo.Id)
                                       .SingleOrDefault();
            var _Cb = new CanBo
            {
                Ten =cb.Ten ,
                Sdt = cb.Sdt,
                Quequan = cb.Quequan,
                Ngaysinh=cb.Ngaysinh,
                CapBac=cb.CapBac, 
                ChucVu=cb.ChucVu, 
                HocHam=cb.HocHam, 
                HocVi=cb.HocVi,
                Cccd=cb.Cccd,
                IdDonVi=idDonVi
               
                           


            };
            _context.Add(_Cb);
            _context.SaveChanges();
            var DonVi = _context.DonVis
                                       .Where(lo => lo.Id == _Cb.IdDonVi)
                                       .Select(lo => lo.Ten)
                                       .SingleOrDefault();
            return new CanBoView
            {
                Ten = _Cb.Ten,
                Sdt = _Cb.Sdt,
                Quequan = _Cb.Quequan,
                Ngaysinh = _Cb.Ngaysinh,
                CapBac = _Cb.CapBac,
                ChucVu = _Cb.ChucVu,
                HocHam = _Cb.HocHam,
                HocVi = _Cb.HocVi,
                Cccd = _Cb.Cccd,
                DonVi = DonVi
            };
        }
        #endregion
        #region delete 
        public void Delete(int id)
        {
            var CanBo = _context.CanBoes.SingleOrDefault(lo => lo.Id == id);
            if (CanBo != null)
            {
                _context.Remove(CanBo);
                _context.SaveChanges();
            }
        }
        #endregion
        #region loc theo don vi 
        public List<CanBoView> GetAll(int id)
        {
            var subordinates = new List<CanBoView>();

            // Lấy đơn vị dựa trên ID
            //var unit = _context.DonVis.SingleOrDefault(d => d.Id == id);
            var unit = _context.CanBoes.FromSqlRaw("EXEC FilterCanBo {0}", id).ToList();


            if (unit != null)
            {
                //var subordinateunits = GetSubordinateUnits(unit);

                foreach (var subUnit in unit)
                {
                    var DonVi = _context.DonVis
                                          .Where(lo => lo.Id == subUnit.IdDonVi)
                                          .Select(lo => lo.Ten)
                                          .SingleOrDefault();
                    subordinates.Add(new CanBoView
                    {
                        Ten = subUnit.Ten,
                        Sdt = subUnit.Sdt,
                        Quequan = subUnit.Quequan,
                        Ngaysinh = subUnit.Ngaysinh,
                        CapBac = subUnit.CapBac,
                        ChucVu = subUnit.ChucVu,
                        HocHam = subUnit.HocHam,
                        HocVi = subUnit.HocVi,
                        Cccd = subUnit.Cccd,
                        DonVi = DonVi
                    });
                }
            }

            return subordinates;
        }
        #endregion

        public CanBoView GetByID(int id)
        {
            throw new NotImplementedException();
        }
        #region loc can bo theo don vi 
        public List<CanBoView> GetToDonVi(int id)
        {
            var subordinates = new List<CanBoView>();

            // Lấy đơn vị dựa trên ID
            //var unit = _context.DonVis.SingleOrDefault(d => d.Id == id);
            var unit = _context.CanBoes.FromSqlRaw("EXEC FilterCanBo {0}", id).ToList();


            if (unit != null)
            {
                //var subordinateunits = GetSubordinateUnits(unit);

                foreach (var subUnit in unit)
                {
                    var DonVi = _context.DonVis
                                          .Where(lo => lo.Id == subUnit.IdDonVi)
                                          .Select(lo => lo.Ten)
                                          .SingleOrDefault();
                    subordinates.Add(new CanBoView
                    {
                        Ten = subUnit.Ten,
                        Sdt = subUnit.Sdt,
                        Quequan = subUnit.Quequan,
                        Ngaysinh = subUnit.Ngaysinh,
                        CapBac = subUnit.CapBac,
                        ChucVu = subUnit.ChucVu,
                        HocHam = subUnit.HocHam,
                        HocVi = subUnit.HocVi,
                        Cccd = subUnit.Cccd,
                        DonVi = DonVi
                    });
                }
            }

            return subordinates;
        }
        #endregion
        #region search 
        public List<CanBoView> Search(string search)
        {
            var subordinates = new List<CanBoView>();

            // Lấy đơn vị dựa trên ID
            //var unit = _context.DonVis.SingleOrDefault(d => d.Id == id);
            var unit = _context.CanBoes.FromSqlRaw("Exec SearchCanBo {0}", search).ToList();


            if (unit != null)
            {
                //var subordinateunits = GetSubordinateUnits(unit);

                foreach (var subUnit in unit)
                {
                    var DonVi = _context.DonVis
                                          .Where(lo => lo.Id == subUnit.IdDonVi)
                                          .Select(lo => lo.Ten)
                                          .SingleOrDefault();
                    subordinates.Add(new CanBoView
                    {
                        Ten = subUnit.Ten,
                        Sdt = subUnit.Sdt,
                        Quequan = subUnit.Quequan,
                        Ngaysinh = subUnit.Ngaysinh,
                        CapBac = subUnit.CapBac,
                        ChucVu = subUnit.ChucVu,
                        HocHam = subUnit.HocHam,
                        HocVi = subUnit.HocVi,
                        Cccd = subUnit.Cccd,
                        DonVi = DonVi
                    });
                }
            }

            return subordinates;
        }
        #endregion
        #region Update
        public void Update(CanBoView CanBo)
        {
            
                var _CanBo = _context.CanBoes.SingleOrDefault(lo => lo.Id == CanBo.Id);
            _CanBo.Ten = CanBo.Ten;
            _CanBo.Sdt = CanBo.Sdt;
            _CanBo.Quequan = CanBo.Quequan;
            _CanBo.Ngaysinh = CanBo.Ngaysinh;
            _CanBo.CapBac = CanBo.CapBac;
            _CanBo.ChucVu = CanBo.ChucVu;
            _CanBo.HocHam = CanBo.HocHam;
            _CanBo.HocVi = CanBo.HocVi;
            _CanBo.Cccd = CanBo.Cccd;
            _CanBo.IdDonVi = _context.DonVis
                                          .Where(lo => lo.Ten == CanBo.Ten)
                                          .Select(lo => lo.Id)
                                          .SingleOrDefault(); ;

           _context.SaveChanges();
            
        }
        #endregion
    }
}

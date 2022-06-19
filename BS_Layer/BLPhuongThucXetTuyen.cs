using System.Data;
using UI.BD_Layer;
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLPhuongThucXetTuyen
    {
       /* public Table<PhuongThucXetTuyen> LayPhuongThucXetTuyen()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.PhuongThucXetTuyens;
        }

        public bool ThemPhuongThucXetTuyen(string TenPT, string MaPT, string HeDT, DateTime TGBD, DateTime TGKT, string Anh, string NoiDung, string PTCha, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            PhuongThucXetTuyen xt = new PhuongThucXetTuyen();
            xt.TenPhuongThuc = TenPT;
            xt.MaPhuongThuc = MaPT;
            xt.HeDaoTao = HeDaoTao;
            xt.ThoiGianBatDau = TGBD;
            xt.ThoiGianKetThuc = TGKT;
            xt.HinhAnh = Anh;
            xt.NoiDung = NoiDung;
            xt.PhuongThucCha = PTCha;

            qlTS.PhuongThucXetTuyens.InsertOnSubmit(xt);
            qlTS.PhuongThucXetTuyens.Context.SubmitChanges();
            return true;
        }
        public bool XoaPhuongThucXetTuyen(ref string err, string MaPhuongThuc)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from tp in qlTS.PhuongThucXetTuyens
                          where tp.MaPhuongThuc == MaPhuongThuc
                          select tp;

            qlTS.PhuongThucXetTuyens.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }
        public bool SuaPhuongThuc(ref string err, string TenPT, string MaPT, string HeDT, DateTime TGBD, DateTime TGKT, string Anh, string NoiDung, string PTCha)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.PhuongThucXetTuyens
                           where ts.MaPhuongThuc == MaPT
                           select ts).SingleOrDefault();
            if (tsQuery != null)
            {
                tsQuery.TenPhuongThuc = TenPT;
                tsQuery.MaPhuongThuc = MaPT;
                tsQuery.HeDaoTao = HeDaoTao;
                tsQuery.ThoiGianBatDau = TGBD;
                tsQuery.ThoiGianKetThuc = TGKT;
                tsQuery.HinhAnh = Anh;
                tsQuery.NoiDung = NoiDung;
                tsQuery.PhuongThucCha = PTCha;
                qlTS.SubmitChanges();
            }
            return true;
        }
*/
        
        public Table<PhuongThucXetTuyen> LayPhuongThucXetTuyen()
        {
            QuanLiTuyenSinhDataContext slts = new QuanLiTuyenSinhDataContext();

            return slts.PhuongThucXetTuyens;
        }
        public bool ThemPhuongThucXetTuyen(string TenPT, string MaPT, string HeDT, DateTime TGBD , DateTime TGKT, string Anh, string NoiDung, string PTCha,ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            PhuongThucXetTuyen dsut = new PhuongThucXetTuyen();
            dsut.TenPhuongThuc = TenPT;
            dsut.MaPhuongThuc = MaPT;
            dsut.HeDaoTao = HeDT;
            dsut.ThoiGianBatDau = TGBD;
            dsut.ThoiGianKetThuc = TGKT;
            dsut.HinhAnh = Anh;
            dsut.NoiDung = NoiDung;
            dsut.PhuongThucCha = PTCha;

            db.PhuongThucXetTuyens.InsertOnSubmit(dsut);
            db.PhuongThucXetTuyens.Context.SubmitChanges();
            return true;
        }
        public bool XoaPhuongThucXetTuyen(ref string err, string MaPhuongThuc)
        {
            QuanLiTuyenSinhDataContext qlBH = new QuanLiTuyenSinhDataContext();
            var tpQuery = from hd in qlBH.PhuongThucXetTuyens
                          where hd.MaPhuongThuc == MaPhuongThuc
                          select hd;
            qlBH.PhuongThucXetTuyens.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }
        public bool SuaPhuongThuc(ref string err, string TenPT, string MaPT, string HeDT, DateTime TGBD, DateTime TGKT, string Anh, string NoiDung, string PTCha)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            var dsut = (from UT in db.PhuongThucXetTuyens
                        where UT.MaPhuongThuc == MaPT
                        select UT).SingleOrDefault();
            if (dsut != null)
            {
                dsut.TenPhuongThuc = TenPT;
                dsut.HeDaoTao = HeDT;
                dsut.ThoiGianBatDau = TGBD;
                dsut.ThoiGianKetThuc = TGKT;
                dsut.HinhAnh = Anh;
                dsut.NoiDung = NoiDung;
                dsut.PhuongThucCha = PTCha;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}

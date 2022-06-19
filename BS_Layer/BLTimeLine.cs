using System.Data;
using UI.BD_Layer;
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Windows.Forms;

namespace UI.BS_Layer
{
    internal class BLTimeLine
    {
        /*public Table<TimeLine> LayTimeLine()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.TimeLines;
        }

        public bool ThemTimeLine(string TenSuKien, DateTime BatDau, DateTime KetThuc, string HeDaoTao, string NoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            TimeLine tl = new TimeLine();
            tl.TenSuKien = TenSuKien;
            tl.ThoiGianBatDau = BatDau;
            tl.ThoiGianKetThuc = KetThuc;
            tl.HeDaoTao = HeDaoTao;
            tl.NoiDung = NoiDung;

            qlTS.TimeLines.InsertOnSubmit(tl);
            qlTS.TimeLines.Context.SubmitChanges();
            return true;
        }

        public bool XoaBangTin(ref string err, string TieuDe)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from ts in qlTS.TimeLines
                          where ts.TenSuKien == TieuDe
                          select ts;

            qlTS.TimeLines.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }

        public bool SuaBangTin(ref string err, string TenSK, DateTime NgayDang, DateTime KetThuc, string HDT, string NoiDung)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.TimeLines
                           where ts.TenSuKien == TenSK
                           select ts).SingleOrDefault();
            if(tsQuery != null)
            {
                tsQuery.ThoiGianBatDau = NgayDang;
                tsQuery.ThoiGianKetThuc = KetThuc;
                tsQuery.HeDaoTao = HDT;
                tsQuery.NoiDung = NoiDung;
            }
            return true;
        }*/
        
        public Table<TimeLine> LayTimeLine()
        {
            QuanLiTuyenSinhDataContext slts = new QuanLiTuyenSinhDataContext();

            return slts.TimeLines;
        }
        public bool ThemTimeLine(string TenSuKien, DateTime BatDau, DateTime KetThuc, string HeDaoTao, string NoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            TimeLine dsut = new TimeLine();
            dsut.TenSuKien = TenSuKien;
            dsut.ThoiGianBatDau = BatDau.Date;
            dsut.ThoiGianKetThuc = KetThuc.Date;
            dsut.HeDaoTao = HeDaoTao;
            dsut.NoiDung = NoiDung;

            db.TimeLines.InsertOnSubmit(dsut);
            db.TimeLines.Context.SubmitChanges();
            return true;
        }
        public bool XoaBangTin(ref string err, string TenSk)
        {
            QuanLiTuyenSinhDataContext qlBH = new QuanLiTuyenSinhDataContext();
            var tpQuery = from hd in qlBH.TimeLines
                          where hd.TenSuKien == TenSk
                          select hd;
            qlBH.TimeLines.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }
        public bool SuaBangTin(ref string err, string TenSK, string NgayDang, string KetThuc, string HDT, string NoiDung)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            var dsut = (from UT in db.TimeLines
                        where UT.TenSuKien == TenSK
                        select UT).SingleOrDefault();
            if (dsut != null)
            {
                MessageBox.Show(KetThuc);
                dsut.ThoiGianBatDau = Convert.ToDateTime(NgayDang).Date;
                dsut.ThoiGianKetThuc = Convert.ToDateTime(KetThuc).Date;
                dsut.HeDaoTao = HDT;
                dsut.NoiDung = NoiDung;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}

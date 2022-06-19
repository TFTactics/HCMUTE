using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Windows.Forms;

namespace UI.BS_Layer
{
    internal class BLBangTinTuyenSinh
    {
        /*public Table<TinTuyenSinh> LayBangTin()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.TinTuyenSinhs;
        }

        public bool ThemBangTin(string TieuDe, string NoiDung, string HeDaoTao, string TrangThai, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            TinTuyenSinh ts = new TinTuyenSinh();
            ts.TieuDe = TieuDe;
            ts.NoiDung = NoiDung;
            ts.HeDaoTao = HeDaoTao;
            ts.TrangThai = TrangThai;

            qlTS.TinTuyenSinhs.InsertOnSubmit(ts);
            qlTS.TinTuyenSinhs.Context.SubmitChanges();
            return true;
        }

        public bool XoaBangTin(ref string err, string TieuDe)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from tp in qlTS.TinTuyenSinhs
                          where tp.TieuDe == TieuDe
                          select tp;

            qlTS.TinTuyenSinhs.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }

        public bool SuaTin(ref string err, string TieuDe, string NoiDung, string HeDaoTao, string TrangThai)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.TinTuyenSinhs
                           where ts.TieuDe == TieuDe
                           select ts).SingleOrDefault();
            if(tsQuery != null)
            {
                tsQuery.NoiDung = NoiDung;
                tsQuery.HeDaoTao = HeDaoTao;
                tsQuery.TrangThai = TrangThai;
                qlTS.SubmitChanges();
            }
            return true;
        }*/
        
        public Table<TinTuyenSinh> LayBangTin()
        {
            QuanLiTuyenSinhDataContext slts = new QuanLiTuyenSinhDataContext();

            return slts.TinTuyenSinhs;
        }
        public bool ThemBangTin(string TieuDe, string NoiDung, string HeDaoTao, string TrangThai, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            TinTuyenSinh x = new TinTuyenSinh();
            x.TieuDe = TieuDe;
            x.NoiDung = NoiDung;
            x.HeDaoTao = HeDaoTao;
            x.TrangThai = TrangThai;

            db.TinTuyenSinhs.InsertOnSubmit(x);
            db.TinTuyenSinhs.Context.SubmitChanges();
            return true;
        }
        public bool XoaBangTin(ref string err, string TieuDe)
        {
            QuanLiTuyenSinhDataContext qlBH = new QuanLiTuyenSinhDataContext();
            var tpQuery = from hd in qlBH.TinTuyenSinhs
                          where hd.TieuDe == TieuDe
                          select hd;
            qlBH.TinTuyenSinhs.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }
        public bool SuaTin(ref string err, string TieuDe, string NoiDung, string HeDaoTao, string TrangThai)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            var dsut = (from UT in db.TinTuyenSinhs
                        where UT.TieuDe == TieuDe
                        select UT).SingleOrDefault();
            if (dsut != null)
            {
                dsut.NoiDung = NoiDung;
                dsut.HeDaoTao = HeDaoTao;
                dsut.TrangThai = TrangThai;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public int DemSoTinTS()
        {
            return LayBangTin().Count();
        }
    }
}

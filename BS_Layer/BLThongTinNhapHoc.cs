using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLThongTinNhapHoc
    {
       /* public Table<ThongTinNhapHoc> LayThongTinNhapHoc()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.ThongTinNhapHocs;
        }

        public bool ThemThongTinNhapHoc(string NDNhapHoc, string BuocSo, string NoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            ThongTinNhapHoc tt = new ThongTinNhapHoc();
            tt.NoiDungNhapHoc = NDNhapHoc;
            tt.BuocSo = BuocSo;
            tt.NoiDung = NoiDung;

            qlTS.ThongTinNhapHocs.InsertOnSubmit(tt);
            qlTS.ThongTinNhapHocs.Context.SubmitChanges();
            return true;
        }

        public bool XoaThongTin(ref string err, string NoiDungNhapHoc)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from tp in qlTS.ThongTinNhapHocs
                          where tp.NoiDungNhapHoc == NoiDungNhapHoc
                          select tp;

            qlTS.TinTuyenSinhs.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }

        public bool SuaThongTin(string NDNhapHoc, string BuocSo, string NoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.ThongTinNhapHocs
                           where ts.NoiDungNhapHoc == NDNhapHoc
                           select ts).SingleOrDefault();
            if (tsQuery != null)
            {
                tsQuery.NoiDungNhapHoc = NDNhapHoc;
                tsQuery.BuocSo = BuocSo;
                tsQuery.NoiDung = NoiDung;
                qlTS.SubmitChanges();
            }
            return true;
        }*/

        public Table<ThongTinNhapHoc> LayThongTinNhapHoc()
        {
            QuanLiTuyenSinhDataContext slts = new QuanLiTuyenSinhDataContext();

            return slts.ThongTinNhapHocs;
        }
        public bool ThemThongTinNhapHoc(string NDNhapHoc, string BuocSo,string NoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            ThongTinNhapHoc dsut = new ThongTinNhapHoc();
            dsut.NoiDungNhapHoc = NDNhapHoc;
            dsut.BuocSo = BuocSo;
            dsut.NoiDung = NoiDung;

            db.ThongTinNhapHocs.InsertOnSubmit(dsut);
            db.ThongTinNhapHocs.Context.SubmitChanges();
            return true;
        }
        public bool XoaThongTin(ref string err, string NoiDungNhapHoc)
        {
            QuanLiTuyenSinhDataContext qlBH = new QuanLiTuyenSinhDataContext();
            var tpQuery = from hd in qlBH.ThongTinNhapHocs
                          where hd.NoiDungNhapHoc == NoiDungNhapHoc
                          select hd;
            qlBH.ThongTinNhapHocs.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }
        public bool SuaThongTin(string NDNhapHoc, string BuocSo, string NoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            var dsut = (from UT in db.ThongTinNhapHocs
                        where UT.NoiDungNhapHoc == NDNhapHoc
                        select UT).SingleOrDefault();
            if (dsut != null)
            {
                dsut.BuocSo = BuocSo;
                dsut.NoiDung = NoiDung;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}

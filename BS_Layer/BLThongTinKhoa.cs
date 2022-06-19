using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLThongTinKhoa
    {
        /*public Table<ThongTinKhoa> LayThongTinKhoa()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.ThongTinKhoas;
        }

        public bool ThemThongTinKhoa(string TenKhoa, string GioiThieu, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            ThongTinKhoa tt = new ThongTinKhoa();
            tt.TenKhoa = TenKhoa;
            tt.GioiThieu = GioiThieu;

            qlTS.ThongTinKhoas.InsertOnSubmit(tt);
            qlTS.ThongTinKhoas.Context.SubmitChanges();
            return true;
        }
        public bool XoaThongTinKhoa(ref string err, string TenKhoa)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from tp in qlTS.ThongTinKhoas
                          where tp.TenKhoa == TenKhoa
                          select tp;

            qlTS.TinTuyenSinhs.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }
        public bool SuaThongTinKhoa(ref string err, string TenKhoa, string GT)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.ThongTinKhoas
                           where ts.TenKhoa == TenKhoa
                           select ts).SingleOrDefault();
            if (tsQuery != null)
            {
                tsQuery.GioiThieu = GT;
                qlTS.SubmitChanges();
            }
            return true;
        }*/

        public Table<ThongTinKhoa> LayThongTinKhoa()
        {
            QuanLiTuyenSinhDataContext slts = new QuanLiTuyenSinhDataContext();

            return slts.ThongTinKhoas;
        }
        public bool ThemThongTinKhoa(string TenKhoa, string GioiThieu, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            ThongTinKhoa dsut = new ThongTinKhoa();
            dsut.TenKhoa = TenKhoa;
            dsut.GioiThieu = GioiThieu;

            db.ThongTinKhoas.InsertOnSubmit(dsut);
            db.ThongTinKhoas.Context.SubmitChanges();
            return true;
        }
        public bool XoaThongTinKhoa(ref string err, string TenKhoa)
        {
            QuanLiTuyenSinhDataContext qlBH = new QuanLiTuyenSinhDataContext();
            var tpQuery = from hd in qlBH.ThongTinKhoas
                          where hd.TenKhoa == TenKhoa
                          select hd;
            qlBH.ThongTinKhoas.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }
        public bool SuaThongTinKhoa(ref string err, string TenKhoa, string GT)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            var dsut = (from UT in db.ThongTinKhoas
                        where UT.TenKhoa == TenKhoa
                        select UT).SingleOrDefault();
            if (dsut != null)
            {
                dsut.GioiThieu =GT ;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}

using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLThongTinNguoiDung
    {
        /*public Table<ThongTinNguoiDung> LayThongTinNguoiDung()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.ThongTinNguoiDungs;
        }

        public bool ThemNguoiDung(string HoTen, string DienThoai, string Email, string LoaiNGuoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            ThongTinNguoiDung tt = new ThongTinNguoiDung();
            tt.HoTen = HoTen;
            tt.DienThoai = DienThoai;
            tt.Email = Email;
            tt.LoaiNguoiDung = LoaiNGuoiDung;

            qlTS.ThongTinNguoiDungs.InsertOnSubmit(tt);
            qlTS.ThongTinNguoiDungs.Context.SubmitChanges();
        }

        public bool XoaNguoiDung(ref string err, string HoTen)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from ts in qlTS.ThongTinNguoiDungs
                          where ts.HoTen == HoTen
                          select ts;
            qlTS.ThongTinNguoiDungs.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }

        public bool SuaThongTin(ref string err, string HoTen, string DienThoai, string Email, string LoaiNGuoiDung)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.ThongTinNguoiDungs
                           where ts.Email == Email
                           select ts).SingleOrDefault();

            if(tsQuery != null)
            {
                tsQuery.HoTen = HoTen;
                tsQuery.DienThoai = DienThoai;
                tsQuery.Email = Email;
                tsQuery.LoaiNguoiDung = LoaiNGuoiDung;
            }
            return true;
        }*/

        public Table<ThongTinNguoiDung> LayThongTinNguoiDung()
        {
            QuanLiTuyenSinhDataContext slts = new QuanLiTuyenSinhDataContext();

            return slts.ThongTinNguoiDungs;
        }
        public bool ThemNguoiDung(string HoTen, string DienThoai,string Email, string LoaiNGuoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            ThongTinNguoiDung dsut = new ThongTinNguoiDung();
            dsut.HoTen = HoTen;
            dsut.DienThoai = DienThoai;
            dsut.Email = Email;
            dsut.LoaiNguoiDung = LoaiNGuoiDung;

            db.ThongTinNguoiDungs.InsertOnSubmit(dsut);
            db.ThongTinNguoiDungs.Context.SubmitChanges();
            return true;
        }
        public bool XoaNguoiDung(ref string err, string HoTen)
        {
            QuanLiTuyenSinhDataContext qlBH = new QuanLiTuyenSinhDataContext();
            var tpQuery = from hd in qlBH.ThongTinNguoiDungs
                          where hd.HoTen == HoTen
                          select hd;
            qlBH.ThongTinNguoiDungs.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }
        public bool SuaThongTin(ref string err, string HoTen, string DienThoai, string Email, string LoaiNGuoiDung)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            var dsut = (from UT in db.ThongTinNguoiDungs
                        where UT.Email == Email
                        select UT).SingleOrDefault();
            if (dsut != null)
            {
                dsut.HoTen = HoTen;
                dsut.DienThoai = DienThoai;
                dsut.LoaiNguoiDung = LoaiNGuoiDung;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}

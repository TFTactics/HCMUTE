using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLDanhSachUngTuyen
    {
        /*public Table<DanhSachUngTuyen> LayDanhSachUngTuyen()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.DanhSachUngTuyens;
        }

        public bool ThemDanhSachUngTuyen(string HoTen, string Email, string SDT, int MaHoSo, int MaNguyenVong, string NganhUngTuyen, string TrangThai, string PhuongThuc, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            DanhSachUngTuyen ds = new DanhSachUngTuyen();
            ds.HoTen = HoTen;
            ds.Email = Email;
            ds.SDT = SDT;
            ds.MaHoSo = MaHoSo;
            ds.MaNguyenVong = MaNguyenVong;
            ds.NganhUngTuyen = NganhUngTuyen;
            ds.TrangThai = TrangThai;
            ds.PhuongThuc = PhuongThuc;

            qlTS.DanhSachUngTuyens.InsertOnSubmit(ds);
            qlTS.DanhSachUngTuyens.Context.SubmitChanges();
            return false;
        }

        public bool XoaDanhSachUngTuyen(ref string err, string email)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from ts in qlTS.DanhSachUngTuyens
                          where ts.Email == email
                          select tp;
            qlTS.DanhSachUngTuyens.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }

        public bool SuaDanhSachUngTuyen(ref string err, string Hoten, string email, string sdt, int MaHS, int MaNV, string TrangThai, string PT)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.DanhSachUngTuyens
                           where ts.Email == email
                           select ts).SingleOrDefault();

            if(tsQuery != null)
            {
                tsQuery.HoTen = Hoten;
                tsQuery.Email = email;
                tsQuery.SDT = sdt;
                tsQuery.MaHoSo = MaHS;
                tsQuery.MaNguyenVong = MaNV;
                tsQuery.TrangThai = TrangThai;
                tsQuery.PhuongThuc = PT;
                qlTS.SubmitChanges();
            }
            return true;
        }*/
        
        public Table<DanhSachUngTuyen> LayDanhSachUngTuyen()
        {
            QuanLiTuyenSinhDataContext slts = new QuanLiTuyenSinhDataContext();
            
            return slts.DanhSachUngTuyens;
        }
        public bool ThemDanhSachUngTuyen(string HoTen, string Email,string SDT, int MaHoSo, int MaNguyenVong, string NganhUngTuyen, string TrangThai, string PhuongThuc, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            DanhSachUngTuyen dsut = new DanhSachUngTuyen();
            dsut.HoTen = HoTen;
            dsut.Email = Email;
            dsut.SDT = SDT;
            dsut.MaHoSo = MaHoSo;
            dsut.MaNguyenVong = MaNguyenVong;
            dsut.TrangThai = TrangThai;
            dsut.PhuongThuc = PhuongThuc;

            db.DanhSachUngTuyens.InsertOnSubmit(dsut);
            db.DanhSachUngTuyens.Context.SubmitChanges();
            return true;
        }
        public bool XoaDanhSachUngTuyen(ref string err, string email)
        {
            QuanLiTuyenSinhDataContext qlBH = new QuanLiTuyenSinhDataContext();
            var tpQuery = from hd in qlBH.DanhSachUngTuyens
                          where hd.Email == email
                          select hd;
            qlBH.DanhSachUngTuyens.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }
        public bool SuaDanhSachUngTuyen(ref string err, string Hoten, string email, string sdt,int MaHS,int MaNV, string TrangThai, string PT)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            var dsut=(from UT in db.DanhSachUngTuyens
                  where UT.Email==email
                  select UT).SingleOrDefault();
            if(dsut!=null)
            {
                dsut.HoTen = Hoten;
                dsut.SDT = sdt;
                dsut.MaHoSo = MaHS;
                dsut.MaNguyenVong = MaNV;
                dsut.TrangThai = TrangThai;
                dsut.PhuongThuc = PT;
                return true;
            }
            return false;
        }

        public int DemSoTSTrungTuyen()
        {
            int count = 0;
            foreach (var x in LayDanhSachUngTuyen())
                if (x.TrangThai == "Trúng Tuyển")
                    count++;
            return count;
        }
        public int DemSoDonUT()
        {
            return LayDanhSachUngTuyen().Count();
        }
    }
}

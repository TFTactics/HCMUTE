using System.Data;
using System.Text.RegularExpressions;
using System.Linq;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLNganhDaoTao
    {
<<<<<<< HEAD
        
        public Table<ThongTinChuyenNganh> LayThongTin()
=======
        public Table<ThongTinChuyenNganh> LayThongTin()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.ThongTinChuyenNganhs;
        }

        public bool ThemNganhDaoTao(string MaNganh, string TenN, string LoaiCT, string Khoa, int ChiTieu, int HocPhi, string MoTa, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            ThongTinChuyenNganh tt = new ThongTinChuyenNganh();
            tt.MaNganh = MaNganh;
            tt.TenNganh = TenN;
            tt.LoaiChuongTrinh = LoaiCT;
            tt.Khoa = Khoa;
            tt.ChiTieu = ChiTieu;
            tt.HocPhi = HocPhi;
            tt.MoTaNganh = MoTa;

            qlTS.ThongTinChuyenNganhs.InsertOnSubmit(tt);
            qlTS.ThongTinChuyenNganhs.Context.SubmitChanges();
            return true;
        }
        public bool XoaNganh(ref string err, string MaNgang)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from tp in qlTS.ThongTinChuyenNganhs
                          where tp.MaNganh == MaNgang
                          select tp;

            qlTS.ThongTinChuyenNganhs.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }
        public bool SuaNganh(ref string err, string MaNganh, string TenN, string LoaiCT, string Khoa, int ChiTieu, int HocPhi, string MoTa)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.ThongTinChuyenNganhs
                           where ts.MaNganh == MaNganh
                           select ts).SingleOrDefault();
            if (tsQuery != null)
            {
                tsQuery.TenNganh = TenN;
                tsQuery.LoaiChuongTrinh = LoaiCT;
                tsQuery.Khoa = Khoa;
                tsQuery.ChiTieu = ChiTieu;
                tsQuery.HocPhi = HocPhi;
                tsQuery.MoTaNganh = MoTa;
                qlTS.SubmitChanges();
            }
            return true;
        }

        DBMain db = null;
        public BLNganhDaoTao()
>>>>>>> 2df9283e60f58f6c9ba8a8a08bb6c6c938413f2d
        {
            QuanLiTuyenSinhDataContext slts = new QuanLiTuyenSinhDataContext();

            return slts.ThongTinChuyenNganhs;
        }
        public bool ThemNganhDaoTao(string MaNganh, string TenN, string LoaiCT, string Khoa, int ChiTieu, int HocPhi, string MoTa, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            ThongTinChuyenNganh dsut = new ThongTinChuyenNganh();
            dsut.MaNganh = MaNganh;
            dsut.TenNganh = TenN;
            dsut.LoaiChuongTrinh = LoaiCT;
            dsut.Khoa = Khoa;
            dsut.ChiTieu = ChiTieu;
            dsut.HocPhi = HocPhi;
            dsut.MoTaNganh = MoTa;

            db.ThongTinChuyenNganhs.InsertOnSubmit(dsut);
            db.ThongTinChuyenNganhs.Context.SubmitChanges();
            return true;
        }
        public bool XoaNganh(ref string err, string MaNganh)
        {
            QuanLiTuyenSinhDataContext qlBH = new QuanLiTuyenSinhDataContext();
            var tpQuery = from hd in qlBH.ThongTinChuyenNganhs
                          where hd.MaNganh == MaNganh
                          select hd;
            qlBH.ThongTinChuyenNganhs.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }
        public bool SuaNganh(ref string err,string MaNganh, string TenN, string LoaiCT, string Khoa, int ChiTieu,int HocPhi, string MoTa)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            var dsut = (from UT in db.ThongTinChuyenNganhs
                        where UT.MaNganh == MaNganh
                        select UT).SingleOrDefault();
            if (dsut != null)
            {
                dsut.TenNganh = TenN;
                dsut.LoaiChuongTrinh = LoaiCT;
                dsut.Khoa = Khoa;
                dsut.ChiTieu = ChiTieu;
                dsut.HocPhi = HocPhi;
                dsut.MoTaNganh = MoTa;
                return true;
            }
            return false;
        }
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        public DataTable SearchNganh(string value)
        {
            DataTable dt = new DataTable();
            if (!IsNumber(value))
            {
                QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
                foreach (var UT in LayThongTin())
                    if (UT.MaNganh == value || UT.LoaiChuongTrinh == value || UT.MoTaNganh == value || UT.TenNganh == value || UT.Khoa == value)
                        dt.Rows.Add(UT);
                return dt;
            }
            else
            {
                int n = System.Convert.ToInt32(value);
                QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
                foreach (var UT in LayThongTin())
                    if (UT.MaNganh == value || UT.LoaiChuongTrinh == value || UT.MoTaNganh == value || UT.TenNganh == value || UT.Khoa == value || UT.HocPhi == n || UT.ChiTieu == n)
                        dt.Rows.Add(UT);
                return dt;

            }
        }
        public DataTable LocLoaiCT(string value)
        {
            DataTable dt = new DataTable();
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            foreach (var UT in LayThongTin())
                if (UT.MaNganh == value || UT.LoaiChuongTrinh == value || UT.MoTaNganh == value || UT.TenNganh == value || UT.Khoa == value)
                    dt.Rows.Add(UT);
            return dt;
        }
        public int DemSoNganh()
        {
            return LayThongTin().Count();
        }    
    }
}

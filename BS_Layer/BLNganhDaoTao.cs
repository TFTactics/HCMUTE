using System.Data;
using System.Text.RegularExpressions;
using System.Linq;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace UI.BS_Layer
{
    internal class BLNganhDaoTao
    {
        
        public Table<ThongTinChuyenNganh> LayThongTin()
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

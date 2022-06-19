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
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        public DataTable SearchNganh(string value)
        {
            value = value.ToLower();
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNganh");
            dt.Columns.Add("TenNganh");
            dt.Columns.Add("LoaiChuongTrinh");
            dt.Columns.Add("Khoa");
            dt.Columns.Add("ChiTieu");
            dt.Columns.Add("HocPhi");
            dt.Columns.Add("MoTaNganh");


            if (!IsNumber(value))
            {
                foreach (var UT in LayThongTin())
                    if (UT.MaNganh.ToLower().Contains(value) || UT.LoaiChuongTrinh.ToLower().Contains(value) || UT.MoTaNganh.ToLower().Contains(value) || UT.TenNganh.ToLower().Contains(value) || UT.Khoa.ToLower().Contains(value))
                        dt.Rows.Add(UT.MaNganh, UT.TenNganh, UT.LoaiChuongTrinh, UT.Khoa, UT.ChiTieu, UT.HocPhi, UT.MoTaNganh);
                return dt;
            }
            else
            {
                foreach (var UT in LayThongTin())
                    if (UT.MaNganh.ToLower().Contains(value) || UT.LoaiChuongTrinh.ToLower().Contains(value) || UT.MoTaNganh.ToLower().Contains(value) || UT.TenNganh.ToLower().Contains(value) || UT.Khoa.ToLower().Contains(value) || UT.HocPhi.ToString().Contains(value) || UT.ChiTieu.ToString().Contains(value))
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

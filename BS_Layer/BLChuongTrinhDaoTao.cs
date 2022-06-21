using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Windows.Forms;

namespace UI.BS_Layer
{
    internal class BLChuongTrinhDaoTao
    {
        /*public Table<ChuongTrinhDaoTao> LayChuongTrinhDaoTao()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.ChuongTrinhDaoTaos;
        }

        public bool ThemChuongTrinhDaoTao(string TenCTDT, string NganhDaoTao, string HeDaoTao, string PDFDaoTao, string NoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            ChuongTrinhDaoTao ct = new ChuongTrinhDaoTao();
            ct.TenChuongTrinh = TenCTDT;
            ct.NganhDaoTao = NganhDaoTao;
            ct.HeDaoTao = HeDaoTao;
            ct.PDFDaoTao = PDFDaoTao;
            ct.NoiDung = NoiDung;

            qlTS.ChuongTrinhDaoTaos.InsertOnSubmit(ct);
            qlTS.ChuongTrinhDaoTaos.Context.SubmitChanges();
            return true;
        }

        public bool XoaChuongTrinhDaoTao(ref string err, string TieuDe)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = from ct in qlTS.ChuongTrinhDaoTaos
                          where ct.TenChuongTrinh == TieuDe
                          select ct;

            qlTS.ChuongTrinhDaoTaos.DeleteAllOnSubmit(tsQuery);
            qlTS.SubmitChanges();
            return true;
        }

        public bool SuaChuongTrinh(ref string err, string TCT, string NDT, string HDT, string PDF, string ND)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ct in qlTS.ChuongTrinhDaoTaos
                           where ct.TenChuongTrinh == TCT
                           select ct).SingleOrDefault();
            if(tsQuery != null)
            {
                tsQuery.NganhDaoTao = NDT;
                tsQuery.HeDaoTao = HDT;
                tsQuery.PDFDaoTao = PDF;
                tsQuery.NoiDung = ND;
            }
        }*/

        public Table<ChuongTrinhDaoTao> LayChuongTrinhDaoTao()
        {
            QuanLiTuyenSinhDataContext slts = new QuanLiTuyenSinhDataContext();

            return slts.ChuongTrinhDaoTaos;
        }
        public bool ThemChuongTrinhDaoTao(string TenCTDT, string NganhDaoTao, string HeDaoTao, string PDFDaoTao, string NoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            ChuongTrinhDaoTao dsut = new ChuongTrinhDaoTao();
            dsut.TenChuongTrinh = TenCTDT;
            dsut.NganhDaoTao = NganhDaoTao;
            dsut.HeDaoTao = HeDaoTao;
            dsut.PDFDaoTao = PDFDaoTao;
            dsut.NoiDung = NoiDung;

            db.ChuongTrinhDaoTaos.InsertOnSubmit(dsut);
            db.ChuongTrinhDaoTaos.Context.SubmitChanges();
            return true;
        }
        public bool XoaChuongTrinhDaoTao(ref string err, string TenCT)
        {
            QuanLiTuyenSinhDataContext qlBH = new QuanLiTuyenSinhDataContext();
            var tpQuery = from hd in qlBH.ChuongTrinhDaoTaos
                          where hd.TenChuongTrinh == TenCT
                          select hd;
            qlBH.ChuongTrinhDaoTaos.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }
        public bool SuaChuongTrinh(ref string err, string TCT, string NDT, string HDT, string PDF, string ND)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            var dsut = (from UT in db.ChuongTrinhDaoTaos
                        where UT.TenChuongTrinh == TCT
                        select UT).SingleOrDefault();
            if (dsut != null)
            {
                dsut.HeDaoTao = HDT;
                dsut.NganhDaoTao = NDT;
                dsut.PDFDaoTao = PDF;
                dsut.NoiDung = ND;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public DataTable LayTenChuongTrinh()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TenChuongTrinh");
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();

            foreach (var UT in LayChuongTrinhDaoTao())
            {
                dt.Rows.Add(UT.TenChuongTrinh);
            }
            return dt;
        }
        public int DemNganh(string x)
        {
            int count = 0;
            foreach (var a in LayChuongTrinhDaoTao())
                if (a.TenChuongTrinh == x)
                    count++;
            MessageBox.Show(count.ToString());
            return count;
        }
    }
}

using System.Data;
using UI.BD_Layer;
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    class BLThongTinTruong
    {
        /*public Table<ThongTinChung> LayBangTin()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.ThongTinChungs;
        }

        public bool SuaBangTin(string GioiThieuTruong, int SoGiaoSu,
            int PhoGS, int TSTS, int NganhThac, int NganhTien, int CuNhan, string vid, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tsQuery = (from ts in qlTS.ThongTinChungs
                           select ts).SingleOrDefault();
            if (tsQuery != null)
            {
                tsQuery.GioiThieuTruong = GioiThieuTruong;
                tsQuery.SoGiaoSu = SoGiaoSu;
                tsQuery.SoPhoGiaoSu = PhoGS;
                tsQuery.SoNganhDaoTaoThacSi = NganhThac;
                tsQuery.SoNganhDaoTaoTienSi = NganhTien;
                tsQuery.SoNganhDaoTaoCuNhan = CuNhan;
                tsQuery.VideoGioiThieu = vid;

                qlTS.SubmitChanges();
            }
            return true;
        }*/

        public Table<ThongTinChung> LayBangTin()
        {
            QuanLiTuyenSinhDataContext slts = new QuanLiTuyenSinhDataContext();

            return slts.ThongTinChungs;
        }
        public bool ThemBangTin(string GioiThieuTruong, int SoGiaoSu,
            int PhoGS, int TSTS, int NganhThac, int NganhTien, int CuNhan, string vid, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            ThongTinChung dsut = new ThongTinChung();
            dsut.GioiThieuTruong = GioiThieuTruong;
            dsut.SoGiaoSu = SoGiaoSu;
            dsut.SoPhoGiaoSu = PhoGS;
            dsut.SoThacSiTienSi = TSTS;
            dsut.SoNganhDaoTaoThacSi = NganhThac;
            dsut.SoNganhDaoTaoTienSi = NganhTien;
            dsut.SoNganhDaoTaoCuNhan = CuNhan;
            dsut.VideoGioiThieu = vid;

            db.ThongTinChungs.InsertOnSubmit(dsut);
            db.ThongTinChungs.Context.SubmitChanges();
            return true;
        }
        public bool SuaBangTin(string GioiThieuTruong, int SoGiaoSu, 
            int PhoGS, int TSTS, int NganhThac, int NganhTien, int CuNhan, string vid, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            var dsut = (from UT in db.ThongTinChungs
                        where UT.GioiThieuTruong == GioiThieuTruong
                        select UT).SingleOrDefault();
            if (dsut != null)
            {
                dsut.SoGiaoSu = SoGiaoSu;
                dsut.SoPhoGiaoSu = PhoGS;
                dsut.SoThacSiTienSi = TSTS;
                dsut.SoNganhDaoTaoThacSi = NganhThac;
                dsut.SoNganhDaoTaoTienSi = NganhTien;
                dsut.SoNganhDaoTaoCuNhan = CuNhan;
                dsut.VideoGioiThieu = vid;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public void LayDuLieu(ref string GTC, ref int SGS, ref int PGS, ref int TSTS, ref int NTS, ref int NS, ref int CN, ref string vid)
        {
            string err = "";
            foreach(var x in LayBangTin())
            {     
                GTC = x.GioiThieuTruong.ToString();
                SGS = Convert.ToInt32(x.SoGiaoSu);
                PGS = Convert.ToInt32(x.SoPhoGiaoSu);
                TSTS = Convert.ToInt32(x.SoThacSiTienSi);
                NTS = Convert.ToInt32(x.SoNganhDaoTaoThacSi);
                NS = Convert.ToInt32(x.SoNganhDaoTaoTienSi);
                CN = Convert.ToInt32(x.SoNganhDaoTaoCuNhan);
                vid = x.VideoGioiThieu;
            }
        }
    }
}

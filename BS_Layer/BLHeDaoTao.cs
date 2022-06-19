using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace UI.BS_Layer
{
    internal class BLHeDaoTao
    {
        /*public Table<HeDaoTao> LayHeDaoTao()
        {
            DataSet ds = new DataSet();
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            return qlTS.HeDaoTaos;
        }

        public bool ThemHeDaoTao(string MaHDT, string TenHDT, string GioiThieu, ref string err)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            HeDaoTao hdt = new HeDaoTao();
            hdt.MaHeDaoTao = MaHDT;
            hdt.TenHeDaoTao = TenHDT;
            hdt.GioiThieu = GioiThieu

            qlTS.HeDaoTaos.InsertOnSubmit(tp);
            qlTS.HeDaoTaos.Context.SubmitChanges();
            return true;
        }

        public bool XoaHeDaoTao(ref string err, string MaHDT)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tpQuery = from ts in qlTS.HeDaoTaos
                          where ts.MaHeDaoTao == MaHDT
                          select tp;
            qlTS.ThanhPhos.DeleteAllOnSubmit(tpQuery);
            qlTS.SubmitChanges();
            return true;
        }

        public bool SuaHeDaoTao(ref string err, string MaHDT, string TenHDT, string GT)
        {
            QuanLiTuyenSinhDataContext qlTS = new QuanLiTuyenSinhDataContext();
            var tpQuery = (from tp in qlTS.HeDaoTaos
                           where tp.MaHeDaoTao == MaHDT
                           select tp).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.TenHeDaoTao = TenHDT;
                qlBH.SubmitChanges();
            }
            return true;
        }*/

        public Table<HeDaoTao> LayHeDaoTao()
        {
            QuanLiTuyenSinhDataContext slts = new QuanLiTuyenSinhDataContext();

            return slts.HeDaoTaos;
        }
        public bool ThemHeDaoTao(string MaHDT, string TenHDT,string GioiThieu, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            HeDaoTao dsut = new HeDaoTao();
            dsut.MaHeDaoTao = MaHDT;
            dsut.TenHeDaoTao = TenHDT;
            dsut.GioiThieu = GioiThieu;

            db.HeDaoTaos.InsertOnSubmit(dsut);
            db.HeDaoTaos.Context.SubmitChanges();
            return true;
        }
        public bool XoaHeDaoTao(ref string err, string MaHDT)
        {
            QuanLiTuyenSinhDataContext qlBH = new QuanLiTuyenSinhDataContext();
            var tpQuery = from hd in qlBH.HeDaoTaos
                          where hd.MaHeDaoTao == MaHDT
                          select hd;
            qlBH.HeDaoTaos.DeleteAllOnSubmit(tpQuery);
            qlBH.SubmitChanges();
            return true;
        }
        public bool SuaHeDaoTao(ref string err, string MaHDT, string TenHDT, string GT)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            var dsut = (from UT in db.HeDaoTaos
                        where UT.MaHeDaoTao == MaHDT
                        select UT).SingleOrDefault();
            if (dsut != null)
            {
                dsut.TenHeDaoTao = TenHDT;
                dsut.GioiThieu = GT;
                return true;
            }
            return false;
        }
    }
}

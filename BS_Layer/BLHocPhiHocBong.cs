using System;
using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Linq;
using System.Data.Linq.Mapping;

namespace UI.BS_Layer
{
    internal class BLHocPhiHocBong
    {
        public Table<HocPhiHocBong> LayThongTin()
        {
            QuanLiTuyenSinhDataContext slts = new QuanLiTuyenSinhDataContext();

            return slts.HocPhiHocBongs;
        }
        public bool ThemThongTin(string NoiDung, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            HocPhiHocBong dsut = new HocPhiHocBong();
            dsut.NoiDung = NoiDung;

            db.HocPhiHocBongs.InsertOnSubmit(dsut);
            db.HocPhiHocBongs.Context.SubmitChanges();
            return true;
        }
        public bool SuaThongTin(string noidung, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            if (LayThongTin() == null)
                ThemThongTin("", ref err);
            foreach (var x in db.HocPhiHocBongs)
                x.NoiDung = noidung;
            return true;
        }
        public void LayDuLieu(ref string GTC)
        {
            string err = "";
            if (LayThongTin() == null)
                ThemThongTin("", ref err);
            foreach (var x in LayThongTin())
            {
                GTC = x.NoiDung;
            }
            
        }
    }
}

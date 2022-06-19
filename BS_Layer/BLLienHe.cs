using System.Data;
using UI.BD_Layer;
using System.Data.Linq;
using System.Linq;
using System.Data.Linq.Mapping;

namespace UI.BS_Layer
{
    internal class BLLienHe
    {
        public Table<LienHe> LayLienHe()
        {
            QuanLiTuyenSinhDataContext slts = new QuanLiTuyenSinhDataContext();

            return slts.LienHes;
        }
        public bool ThemLienHe(string DiaDiem, string SoDT, string Email, string Fanpage, string PhongBanLH, string VanPhong, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            LienHe dsut = new LienHe();
            dsut.DiaDiem = DiaDiem;
            dsut.SoDienThoai = SoDT;
            dsut.Email = Email;
            dsut.Fanpage = Fanpage;
            dsut.PhongBanLienHe = PhongBanLH;
            dsut.VanPhong = VanPhong;

            db.LienHes.InsertOnSubmit(dsut);
            db.LienHes.Context.SubmitChanges();
            return true;
        }
        public bool SuaLienHe(string DiaDiem, string SoDT,string Email, string Fanpage,string PhongBanLH, string VanPhong, ref string err)
        {
            QuanLiTuyenSinhDataContext db = new QuanLiTuyenSinhDataContext();
            var dsut = (from UT in db.LienHes
                        where UT.Email == Email
                        select UT).SingleOrDefault();
            if (dsut != null)
            {
                dsut.DiaDiem = DiaDiem;
                dsut.SoDienThoai = SoDT;
                dsut.Fanpage = Fanpage;
                dsut.PhongBanLienHe = PhongBanLH;
                dsut.VanPhong = VanPhong; ;
                return true;
            }
            return false;
        }
        public void LayDuLieu(ref string DD, ref string SDT, ref string Email, ref string Fanpage, ref string TenPB, ref string VanPhong)
        {
            string err = "";
            foreach (var x in LayLienHe())
            {
                DD = x.DiaDiem.ToString();
                SDT = x.SoDienThoai.ToString();
                Email = x.Email.ToString();
                Fanpage = x.Fanpage.ToString();
                TenPB = x.PhongBanLienHe.ToString();
                VanPhong = x.VanPhong.ToString();
            }
        }
    }
}

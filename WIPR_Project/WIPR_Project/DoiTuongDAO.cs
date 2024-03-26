using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR_Project
{
    public class DoiTuongDAO
    {
        DBConnection dBConnection = new DBConnection();
        protected string field;
        public void ThemBaiDang(BaiViet bviet)
        {
            string sqlSTR = string.Format("INSERT INTO QlyBaiViet (IdBaiViet,IdTho,DichVu,KinhNghiem,MucGia,HoTen,NgaySinh,Email,SDT,GioiTinh,DiaChi) " +
                    "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                    bviet.Id,bviet.IdTho,bviet.IdTho,bviet.DichVu,bviet.KinhNghiem,bviet.MucGia,bviet.HoTen,bviet.NgaySinh,bviet.Email,bviet.SDT,bviet.GioiTinh,bviet.DiaChi);
            dBConnection.ThucThi(sqlSTR);
        }
        public int IdTiepTheo(string table)
        {
            string getMaxIdQuery = string.Format("SELECT MAX(CAST(Id AS INT)) FROM {0}",table);
            return dBConnection.GetNextId(getMaxIdQuery);
        }
        public SqlDataReader TruyXuat(string table, string idtruytuat)
        {
            string sqlSTR = string.Format("SELECT * FROM {0} WHERE Id = {1}",table, idtruytuat);
            return dBConnection.DuLieuTruyXuat(sqlSTR);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR_Project
{
    public class NguoiDungDAO : DoiTuongDAO
    {
        public NguoiDungDAO()
        {
            
        }
        DBConnection dBConnection = new DBConnection();
        public void ThemYeuThich(int id, int idNguoiDung, int idBaiViet)
        {
            string sqlSTR = string.Format(
                "INSERT INTO Favourite (id,idBaiViet,idNguoiDung) " +
                        "VALUES ('{0}', '{1}','{2}');",
                       id, idBaiViet, idNguoiDung);
            dBConnection.ThucThi(sqlSTR);
        }
        
        public int CheckYeuThich(int idBaiViet, int idNguoiDung)
        {
            string sqlSTR = string.Format("SELECT * FROM Favourite " +
                "WHERE idBaiViet = '{0}' AND idNguoiDung = '{1}'", idBaiViet, idNguoiDung);
            return dBConnection.TruyXuatYeuThich(sqlSTR);
        }
        public void ThemDanhGia(int id, int idTho, int idNguoiDung, decimal sosao, string danhgia)
        {
            string sqlSTR = string.Format(
                "INSERT INTO Evaluation (id,idTho,idNguoiDung,numOfStar,userEvaluation) " +
                        "VALUES ('{0}', '{1}','{2}','{3}',N'{4}');",
                       id, idTho, idNguoiDung, sosao, danhgia);
            dBConnection.ThucThi(sqlSTR);
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WIPR_Project
{
    public class DoiTuongDAO
    {
        DBConnection dBConnection = new DBConnection();

        public Account truyxuatAccount(string userAccount, string password)
        {
            string sqlSTR = string.Format($"SELECT * FROM Account WHERE userAccount = '{userAccount}' AND password = '{password}'");
            return dBConnection.TruyxuatAccount(sqlSTR);
        }
        protected string field;
        public void ThemBaiDang(BaiViet bviet, int idTablePost, string postfrom)
        {
            string id = postfrom == "InforPostTho" ? "idTho" : "idNguoiDung";
            string sqlSTR = string.Format(
                "INSERT INTO Posts (id,createDate) " +
                        "VALUES ('{0}', '{1}');" +
                        "INSERT INTO {2} (id,{3},job,experience,price,idPosts)" +
                        "VALUES ('{4}','{5}','{6}','{7}','{8}','{9}');",
                       idTablePost, bviet.NgayDang, postfrom, id, bviet.Id, bviet.IdDoiTuong, bviet.DichVu,
                       bviet.KinhNghiem, bviet.MucGia, idTablePost);
            dBConnection.ThucThi(sqlSTR);
        }
        public DanhGia TruyXuatDanhGia(int id)
        {
            string sqlSTR = string.Format("SELECT * FROM Evaluation " +
                "WHERE id = '{0}'", id);
            return dBConnection.TruyXuatDanhGia(sqlSTR);
        }
        public void ThemNgayBan(int id, int idUser, string userRole, DateTime busyDate)
        {
            string sqlSTR = string.Format(
                "INSERT INTO busyDate (id,idUser,userRole,userBusyDate) " +
                        "VALUES ('{0}', '{1}','{2}','{3}');",
                       id,idUser,userRole,busyDate);
            dBConnection.ThucThi(sqlSTR);
        }
        public void ThemDanhGia(int id, int idTho, int idNguoiDung, decimal sosao, string danhgia)
        {
            string sqlSTR = string.Format(
                "INSERT INTO Evaluation (id,idTho,idNguoiDung,numOfStar,userEvaluation) " +
                        "VALUES ('{0}', '{1}','{2}','{3}','{4}');",
                       id, idTho, idNguoiDung, sosao, danhgia);
            dBConnection.ThucThi(sqlSTR);
        }
        public void GuiLoiMoi(LoiMoi loiMoi)
        {
            string sqlSTR = string.Format("INSERT INTO RequestUser (id,idTho,idNguoiDung,idPost,sendfrom,dateWork) " +
                    "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                    loiMoi.Id, loiMoi.IdTho, loiMoi.IdNguoiDung, loiMoi.IdBaiViet, loiMoi.Sendfrom, loiMoi.DateWork);
            dBConnection.ThucThi(sqlSTR);
        }
        public List<DateTime> TruyXuatNgayBan(int idUser)
        {
            string sqlSTR = string.Format("SELECT userBusyDate FROM busyDate WHERE idUser = '{0}'",idUser);
            return dBConnection.TruyXuatNgayBan(sqlSTR);
        }
        public DataTable TruyXuatLoiMoi(int idInforUser, string userRole)
        {
            string tablePost = userRole == "Tho" ? "InforPostTho" : "InforPostNguoiDung";
            string sendFrom = userRole == "Tho" ? "idNguoiDung" : "idTho";
            string role = userRole == "Tho" ? "idTho" : "idNguoiDung";
            string from = userRole == "Tho" ? "NguoiDung" : "Tho";
            string sqlSTR = string.Format("SELECT * FROM RequestUser RU " +
                "JOIN Posts P ON RU.idPost = P.id " +
                "JOIN {0} IP ON IP.idPosts = P.id " +
                "JOIN InforUser IU ON RU.{1} = IU.id " +
                "WHERE RU.{3} = '{2}' AND RU.sendFrom = '{4}'",tablePost,sendFrom,idInforUser,role,from);
            return dBConnection.TruyXuatTable(sqlSTR);
        }
        public DataTable TruyXuatNgayLamViec(int idInforUser, string tiendo, string doituong)
        {
            string doiTuongHT = doituong == "Tho" ? "idTho" : "idNguoiDung";
            string doiTuongTruyXuat = doituong == "Tho" ? "idNguoiDung" : "idTho";
            string sqlSTR = string.Format("SELECT * FROM dateWork DW " +
                "JOIN InforUser IU ON DW.{0} = IU.id " +
                "JOIN busyDate BD ON DW.dateWork = BD.id " +
                "WHERE DW.{1} = '{2}' AND progress = '{3}'", doiTuongTruyXuat, doiTuongHT, idInforUser, tiendo);
            return dBConnection.TruyXuatTable(sqlSTR);
        }
        public void XacNhan(int idNgayLamViec, int idTho, int idNguoiDung, string dichvu, DateTime ngayLamViec, int idNgayBan)
        {
            string sqlSTR = string.Format("INSERT INTO busyDate (id,idUser,userRole,userBusyDate) " +
                        " VALUES ('{0}', '{1}', '{2}','{3}') " +
                        " INSERT INTO busyDate (id,idUser,userRole,userBusyDate) " +
                        " VALUES ('{4}', '{5}', '{6}','{3}') " +
                        " INSERT INTO dateWork (id,idTho,idNguoiDung,idEvaluation,progress,job,dateWork) " +
                        " VALUES ('{7}', '{1}', '{5}','{8}','{9}','{10}','{0}') ",
                       idNgayBan, idTho, "Tho", ngayLamViec,
                       idNgayBan + 1, idNguoiDung, "NguoiDung",
                       idNgayLamViec, 0,"ChuaBatDau",dichvu);
            dBConnection.ThucThi(sqlSTR);
        }
        public int IdTiepTheo(string table)
        {
            string getMaxIdQuery = string.Format("SELECT MAX(CAST(Id AS INT)) FROM {0}",table);
            object maxIdResult = dBConnection.GetNextId(getMaxIdQuery);
            int nextId = 0;
            if (maxIdResult != DBNull.Value)
            {
                int maxId = Convert.ToInt32(maxIdResult);
                nextId = maxId + 1;
            }
            return nextId;
        }
        public void Xoa(string table, string idxoa)
        {
            string sqlSTR = string.Format("DELETE FROM {0} WHERE id = '{1}'", table, idxoa);
            dBConnection.ThucThi(sqlSTR);
        }
        public void Sua(string table, int idSua, string noidungSua)
        {
            string sqlSTR = string.Format("UPDATE {0} SET {1} WHERE id = '{2}'", table, noidungSua, idSua);
            dBConnection.ThucThi(sqlSTR);
        }
        public DoiTuong TruyXuatDT(int id)
        {
            string sqlSTR = string.Format("SELECT * FROM InforUser IU " +
                "JOIN Account A ON IU.id = A.idInforUser " +
                "WHERE IU.id = '{0}'", id);
            return dBConnection.TruyXuatDoiTuong(sqlSTR);
        }
        public BaiViet TruyXuatBV(int idBaiViet, string table)
        {
            string idDoiTuong = table == "InforPostTho" ? "idTho" : "idNguoiDung";
            string sqlSTR = string.Format("SELECT * FROM {0} IP " +
                "JOIN Posts P ON IP.idPosts = P.id " +
                "JOIN InforUser IU ON IP.{1} = IU.id " +
                "WHERE IP.idPosts = '{2}'", table, idDoiTuong, idBaiViet);
            return dBConnection.TruyXuatBaiViet(sqlSTR, idDoiTuong);
        }
        public List<BaiViet> TruyXuatDSBaiViet(string khuvuc, string kinhnghiem, string mucgia, string dichvu, string table)
        {
            string stringSql = "";
            if (khuvuc != "" || kinhnghiem != "" || mucgia != "" || dichvu != "")
            {
                stringSql = " WHERE ";
                string[] arrFilter = { khuvuc, kinhnghiem, mucgia, dichvu };
                arrFilter = arrFilter.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                if(arrFilter.Length == 1)
                {
                    stringSql += arrFilter[0];
                }
                else
                {
                    string result = string.Join(" AND ", arrFilter);
                    stringSql += result;
                }
            }
            string id = table == "InforPostTho" ? "idTho" : "idNguoiDung";
            string sqlSTR = string.Format("SELECT * FROM {0} IP " +
                "JOIN Posts P ON IP.idPosts = P.id " +
                "JOIN InforUser IU ON IP.{2} = IU.id " +
                "{1}", table, stringSql, id);
            return dBConnection.TruyXuatDSBaiViet(sqlSTR,id);
        }

    }
}
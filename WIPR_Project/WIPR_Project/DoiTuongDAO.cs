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
                        "INSERT INTO {2} (id,{3},job,experience,price,idPosts,note)" +
                        "VALUES ('{4}','{5}',N'{6}',N'{7}',N'{8}','{9}',N'{10}');",
                       idTablePost, bviet.NgayDang, postfrom, id, bviet.Id, bviet.IdDoiTuong, bviet.DichVu,
                       bviet.KinhNghiem, bviet.MucGia, idTablePost, bviet.ChiTiet);
            dBConnection.ThucThi(sqlSTR);
        }
        public void ThemNgayBan(int id, int idUser, string userRole, DateTime busyDate)
        {
            string sqlSTR = string.Format(
                "INSERT INTO busyDate (id,idUser,userRole,userBusyDate) " +
                        "VALUES ('{0}', '{1}','{2}','{3}');",
                       id,idUser,userRole,busyDate);
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
            string idDoiTuongGui = userRole == "Tho" ? "idNguoiDung" : "idTho";
            string idDoiTuongNhan = userRole == "Tho" ? "idTho" : "idNguoiDung";
            string from = userRole == "Tho" ? "NguoiDung" : "Tho";

            string sqlSTR = string.Format("SELECT * FROM RequestUser RU " +
                "JOIN Posts P ON RU.idPost = P.id " +
                "JOIN {0} IP ON IP.idPosts = P.id " +
                "JOIN InforUser IU ON RU.{1} = IU.id " +
                "WHERE RU.{3} = '{2}' AND RU.sendFrom = '{4}'",tablePost,idDoiTuongGui,idInforUser,idDoiTuongNhan,from);
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
        public void XacNhan(int idNgayLamViec, int idTho, int idNguoiDung, string dichvu, DateTime ngayLamViec, int idNgayBan, string mucgia)
        {
            string sqlSTR = string.Format("INSERT INTO busyDate (id,idUser,userRole,userBusyDate) " +
                        " VALUES ('{0}', '{1}', '{2}','{3}') " +
                        " INSERT INTO busyDate (id,idUser,userRole,userBusyDate) " +
                        " VALUES ('{4}', '{5}', '{6}','{3}') " +
                        " INSERT INTO dateWork (id,idTho,idNguoiDung,idEvaluation,progress,job,dateWork,price) " +
                        " VALUES ('{7}', '{1}', '{5}','{8}','{9}',N'{10}','{0}',N'{11}') ",
                       idNgayBan, idTho, "Tho", ngayLamViec,
                       idNgayBan + 1, idNguoiDung, "NguoiDung",
                       idNgayLamViec, 0,"ChuaBatDau",dichvu, mucgia);
            dBConnection.ThucThi(sqlSTR);
        }
        public int IdTiepTheo(string table)
        {
            string getMaxIdQuery = string.Format("SELECT MAX(CAST(Id AS INT)) FROM {0}",table);
            object maxIdResult = dBConnection.Get(getMaxIdQuery);
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
        public void SuaBaiViet(string table, BaiViet bv)
        {
            string sqlSTR = string.Format("UPDATE {0} SET job = N'{1}',experience=N'{2}',price=N'{3}',note=N'{4}' " +
                "WHERE id = '{5}'", table, bv.DichVu, bv.KinhNghiem, bv.MucGia, bv.ChiTiet, bv.Id);
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
        public List<BaiViet> TruyXuatBaiVietCaNhan(int iduser, string table)
        {
            string id = table == "InforPostTho" ? "idTho" : "idNguoiDung";
            string sqlSTR = string.Format("SELECT * FROM {0} IP " +
                "JOIN Posts P ON IP.idPosts = P.id " +
                "WHERE {1} = '{2}'", table, id, iduser);
            return dBConnection.TruyXuatDSBaiViet(sqlSTR, id);
        }
        public DanhGia TruyXuatDanhGia(int id)
        {
            string sqlSTR = string.Format("SELECT * FROM Evaluation E " +
                "JOIN dateWork dW ON E.id = dW.idEvaluation " +
                "WHERE E.id = '{0}'", id);
            return dBConnection.TruyXuatDanhGia(sqlSTR);
        }
        public List<DanhGia> TruyXuatDSDanhGia(int idTho, string job)
        {
            string sqlSTR = string.Format("SELECT * FROM Evaluation E " +
                "JOIN dateWork dW ON E.id = dW.idEvaluation " +
                "WHERE E.idTho = '{0}' AND dW.job = '{1}'", idTho, job);
            return dBConnection.TruyXuatDSDanhGia(sqlSTR);
        }
        public decimal TongSoSaoTheoCongViec(int idTho, string job)
        {
            string sqlSTR = string.Format(
                "SELECT AVG(numOfStar) AS avgStars FROM Evaluation E " +
                "JOIN dateWork dW ON E.id = dW.idEvaluation " +
                "WHERE E.idTho = '{0}' AND dW.job = '{1}'", idTho, job);

            object soSaoTrungBinh = dBConnection.Get(sqlSTR);
            if (soSaoTrungBinh != DBNull.Value)
            {
                return Convert.ToDecimal(soSaoTrungBinh);
            }
            return 6;
        }
        public int LuotThue(int idTho, string job)
        {
            string sqlSTR = string.Format(
                "SELECT COUNT(*) AS numRecords FROM dateWork " +
                "WHERE idTho = '{0}' AND job = '{1}' AND progress = '{2}'", idTho, job,"DaHoanThanh");
            return Convert.ToInt32(dBConnection.Get(sqlSTR));
        }
        public void ThemTaiKhoan(int idIU, string name, DateTime? birthDate, string email, string phone, string gender, string address, int idAcc, string taiKhoang, string matKhau, string loai)
        {
            string sqlSTR = string.Format(
                "INSERT INTO InforUser (id,name,birthDate,email,phone,gender,address) " +
                        "VALUES ('{0}', N'{1}', '{2}', '{3}', '{4}', N'{5}', N'{6}');" +
                        "INSERT INTO Account (id,userAccount,password,userRole,idInforUser)" +
                        "VALUES ('{7}','{8}','{9}','{10}','{11}');",
                       idIU, name, birthDate, email, phone, gender, address,
                       idAcc, taiKhoang, matKhau, loai, idIU);
            dBConnection.ThucThi(sqlSTR);
        }
        public int TongDoanhThu(int idTho, int month, int year)
        {
            string sqlSTR = string.Format(
                "SELECT SUM(TRY_CAST(price AS int)) AS totalRevenue FROM dateWork dW " +
                "JOIN busyDate bD ON dW.dateWork = bD.id " +
                "WHERE idTho = '{0}' AND MONTH(userBusyDate) = '{1}' AND YEAR(userBusyDate) = '{2}' AND progress = 'DaHoanThanh' ", 
                idTho, month, year);

            object tongDoanhThu = dBConnection.Get(sqlSTR);
            if (tongDoanhThu != DBNull.Value)
            {
                return Convert.ToInt32(tongDoanhThu);
            }
            return 0;
        }
        public int TongSoCongViecTheoTienDo(int idTho, int month, int year, string progress)
        {
            string sqlSTR = string.Format(
                "SELECT COUNT(*) AS numRecords FROM dateWork dW " +
                "JOIN busyDate bD ON dW.dateWork = bD.id " +
                "WHERE idTho = '{0}' AND MONTH(userBusyDate) = '{1}' AND YEAR(userBusyDate) = '{2}' AND progress = '{3}' ",
                idTho, month, year, progress);

            object tongDoanhThu = dBConnection.Get(sqlSTR);
            if (tongDoanhThu != DBNull.Value)
            {
                return Convert.ToInt32(tongDoanhThu);
            }
            return 0;
        }

    }
}
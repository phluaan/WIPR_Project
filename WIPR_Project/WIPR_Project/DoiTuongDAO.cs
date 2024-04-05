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
        public void GuiLoiMoi(int idtieptheo, int idTho, int idNguoiDung, int idPost, string sendFrom, DateTime dateWork)
        {
            string sqlSTR = string.Format("INSERT INTO RequestUser (id,idTho,idNguoiDung,idPost,sendfrom,dateWork) " +
                    "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                    idtieptheo, idTho, idNguoiDung, idPost, sendFrom, dateWork);
            dBConnection.ThucThi(sqlSTR);
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
        public void XacNhanThue(string idtieptheo, string idnguoithue, string idtho, string ngaylamviec, string dichvu)
        {
            string sqlSTR = string.Format("INSERT INTO QlyNgayLamViec (Id,NgayLamViec,IdTho,IdNguoiDung,TienDo,IdDanhGia,DichVu) " +
                        "VALUES ('{0}', '{1}', '{2}','{3}','{4}','{5}','{6}')",
                       idtieptheo,ngaylamviec, idtho, idnguoithue, "","",dichvu);
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
            string sqlSTR = string.Format("DELETE FROM {0} WHERE Id = '{1}'", table, idxoa);
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
            string id = table == "InforPostTho" ? "idTho" : "idNguoiDung";
            string sqlSTR = string.Format("SELECT * FROM {0} IP " +
                "JOIN Posts P ON IP.idPosts = P.id " +
                "JOIN InforUser IU ON IP.{2} = IU.id " +
                "WHERE {1} = '{2}'", table, id, idBaiViet);
            return dBConnection.TruyXuatBaiViet(sqlSTR, id);
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
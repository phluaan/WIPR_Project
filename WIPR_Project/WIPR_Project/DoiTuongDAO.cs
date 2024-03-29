using System;
using System.Collections.Generic;
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
        protected string field;
        public void ThemBaiDang(BaiViet bviet, string type)
        {
            string id = type == "QlyBaiViet" ? "IdTho" : "IdNguoiDung";
            string sqlSTR = string.Format("INSERT INTO {11} (Id,{12},DichVu,KinhNghiem,MucGia,HoTen,NgaySinh,Email,SDT,GioiTinh,DiaChi) " +
                    "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                    bviet.Id, bviet.IdDoiTuong, bviet.DichVu, bviet.KinhNghiem, bviet.MucGia, bviet.HoTen, bviet.NgaySinh, bviet.Email, bviet.SDT, bviet.GioiTinh, bviet.DiaChi, type, id);
            dBConnection.ThucThi(sqlSTR);
        }
        public void GuiLoiMoi(DoiTuong doiTuong, string IdLoiMoi, string IdNguoiDangBai, string IdBaiViet, string TrangThai)
        {
            string idTho = TrangThai == "NguoiDungThueTho" ? IdNguoiDangBai : doiTuong.Id;
            string idnguoidung = TrangThai == "NguoiDungThueTho" ? doiTuong.Id : IdNguoiDangBai;
            string sqlSTR = string.Format("INSERT INTO LoiMoi (Id,IdTho,IdNguoiDung,IdBaiViet,HoTen,NgaySinh,Email,SDT,GioiTinh,DiaChi) " +
                    "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                    IdLoiMoi, idTho, idnguoidung, IdBaiViet, doiTuong.HoTen, doiTuong.NgaySinh, doiTuong.Email, doiTuong.SDT, doiTuong.GioiTinh, doiTuong.DiaChi);
            dBConnection.ThucThi(sqlSTR);
        }
        public void XacNhanThue(string idtieptheo, string idnguoithue, string idtho)
        {
            string sqlSTR = string.Format("INSERT INTO QlyThue (Id, IdNguoiDung, IdTho) " +
                        "VALUES ('{0}', '{1}', '{2}')",
                       idtieptheo, idnguoithue, idtho);
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
        public DoiTuong TruyXuatDT(string table, string idtruyxuat)
        {
            string sqlSTR = string.Format("SELECT * FROM {0} WHERE Id = {1}",table, idtruyxuat);
            return dBConnection.TruyXuatDoiTuong(sqlSTR);
        }
        public BaiViet TruyXuatBV(string idtruyxuat, string table)
        {
            string id = table == "QlyBaiViet" ? "IdTho" : "IdNguoiDung";
            string sqlSTR = string.Format("SELECT * FROM {0} WHERE {1}",table, idtruyxuat);
            return dBConnection.TruyXuatBaiViet(sqlSTR, id);
        }
        public List<BaiViet> TruyXuatDSBaiViet(string khuvuc, string kinhnghiem, string mucgia, string dichvu, string table)
        {
            string stringSql = "";
            if (khuvuc != "" || kinhnghiem != "" || mucgia != "" || dichvu != "")
            {
                string[] arrFilter = { khuvuc, kinhnghiem, mucgia, dichvu };
                arrFilter = arrFilter.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                stringSql = "WHERE ";
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
            string id = table == "QlyBaiViet" ? "IdTho" : "IdNguoiDung";
            string sqlSTR = string.Format("SELECT * FROM {0} {1}", table, stringSql);
            return dBConnection.TruyXuatDSBaiViet(sqlSTR,id);
        }
    }
}
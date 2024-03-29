using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Windows.Controls;

namespace WIPR_Project
{
    internal class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);

        public void ThucThi(string sqlSTR)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlSTR, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("thanh cong");
            }
            catch (Exception exc)
            {
                MessageBox.Show("that bai (ThucThi)" + exc);
            }
            finally
            {
                conn.Close();
            }
        }
        public object GetNextId(string getMaxIdQuery)
        {
            try
            {
                conn.Open();
                SqlCommand getMaxId = new SqlCommand(getMaxIdQuery, conn);
                return getMaxId.ExecuteScalar();
            }
            catch (Exception exc)
            {
                MessageBox.Show("that bai (GetNextId) " + exc);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public DoiTuong TruyXuatDoiTuong(string sqlSTR)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlSTR, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DoiTuong doiTuong = new DoiTuong(reader["Id"].ToString(), reader["TaiKhoan"].ToString(), reader["MatKhau"].ToString(),
                        reader["HoTen"].ToString(), reader["NgaySinh"].ToString(), reader["Email"].ToString(), reader["SDT"].ToString(),
                        reader["GioiTinh"].ToString(), reader["DiaChi"].ToString());
                    reader.Close();
                    return doiTuong;
                }
                else
                {
                    MessageBox.Show("Lỗi truy xuất iddoituong");
                    return null;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("that bai (DuLieuTruyXuatDT)" + exc);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public BaiViet TruyXuatBaiViet(string sqlSTR, string id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlSTR, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    BaiViet baiViet = new BaiViet(reader["Id"].ToString(), reader[id].ToString(), reader["DichVu"].ToString(), reader["KinhNghiem"].ToString(),
                        reader["MucGia"].ToString(), reader["HoTen"].ToString(), reader["NgaySinh"].ToString(), reader["Email"].ToString(), reader["SDT"].ToString(),
                        reader["GioiTinh"].ToString(), reader["DiaChi"].ToString());
                    reader.Close();
                    return baiViet;
                }
                else
                {
                    //MessageBox.Show("Lỗi truy xuất idBaiViet");
                    return null;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("that bai (DuLieuTruyXuatBV)" + exc);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public List<BaiViet> TruyXuatDSBaiViet(string sqlSTR, string id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlSTR, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                List<BaiViet> baiVietList = new List<BaiViet>();
                while (reader.Read())
                {
                    BaiViet baiViet = new BaiViet(reader["Id"].ToString(), reader[id].ToString(), reader["DichVu"].ToString(), reader["KinhNghiem"].ToString(),
                        reader["MucGia"].ToString(), reader["HoTen"].ToString(), reader["NgaySinh"].ToString(), reader["Email"].ToString(), reader["SDT"].ToString(),
                        reader["GioiTinh"].ToString(), reader["DiaChi"].ToString());
                    baiVietList.Add(baiViet);
                }
                reader.Close();
                return baiVietList;
            }
            catch (Exception exc)
            {
                MessageBox.Show("that bai (DuLieuTruyXuat)" + exc);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

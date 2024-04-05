using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Collections;

namespace WIPR_Project
{
    internal class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
        public Account TruyxuatAccount(string sqlSTR)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlSTR, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Account userAccount = new Account(Convert.ToInt32(reader["id"]), reader["userAccount"].ToString(), reader["password"].ToString(), 
                        reader["userRole"].ToString(), Convert.ToInt32(reader["idInforUser"]));
                    reader.Close();
                    return userAccount;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("that bai (truyxuatAccount)" + exc);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

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
                    Account taiKhoan = new Account(Convert.ToInt32(reader["id"]), reader["userAccount"].ToString(), reader["password"].ToString(), reader["userRole"].ToString(), Convert.ToInt32(reader["idInforUser"]));
                    DoiTuong doiTuong = new DoiTuong(Convert.ToInt32(reader["id"]), taiKhoan, reader["name"].ToString(), 
                        Convert.ToDateTime(reader["birthDate"]), reader["email"].ToString(), reader["phone"].ToString(),
                        reader["gender"].ToString(), reader["address"].ToString());
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
        public DataTable TruyXuatTable(string sqlSTR)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlSTR, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception exc)
            {
                MessageBox.Show("that bai (ThucThi)" + exc);
                return null;
            }
            finally
            {
                conn.Close();
            }

        }
        public BaiViet TruyXuatBaiViet(string sqlSTR, string id)
        {
            DoiTuongDAO doiTuongDAO = new DoiTuongDAO();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlSTR, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DoiTuong doiTuong = doiTuongDAO.TruyXuatDT(Convert.ToInt32(reader[id]));
                    BaiViet baiViet = new BaiViet(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader[id]), doiTuong.HoTen, reader["job"].ToString(), reader["experience"].ToString(),
                        reader["price"].ToString(), Convert.ToDateTime(reader["createDate"]),
                        doiTuong.DiaChi);
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
            DoiTuongDAO doiTuongDAO = new DoiTuongDAO();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlSTR, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                List<BaiViet> baiVietList = new List<BaiViet>();
                while (reader.Read())
                {
                    DoiTuong doiTuong = doiTuongDAO.TruyXuatDT(Convert.ToInt32(reader[id]));
                    BaiViet baiViet = new BaiViet(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader[id]), doiTuong.HoTen,reader["job"].ToString(), reader["experience"].ToString(),
                        reader["price"].ToString(), Convert.ToDateTime(reader["createDate"]),
                        doiTuong.DiaChi);
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

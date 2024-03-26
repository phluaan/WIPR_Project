using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
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
                MessageBox.Show("that bai " + exc);
            }
            finally
            {
                conn.Close();
            }
        }
        public int GetNextId(string getMaxIdQuery)
        {
            SqlCommand getMaxId = new SqlCommand(getMaxIdQuery, conn);
            object maxIdResult = getMaxId.ExecuteScalar();
            int nextId = 0;
            if (maxIdResult != DBNull.Value)
            {
                int maxId = Convert.ToInt32(maxIdResult);
                nextId = maxId + 1;
            }
            return nextId;
        }
        public SqlDataReader DuLieuTruyXuat(string sqlSTR)
        {
            SqlCommand cmd = new SqlCommand(sqlSTR, conn);
            return cmd.ExecuteReader();
        }
    }
}

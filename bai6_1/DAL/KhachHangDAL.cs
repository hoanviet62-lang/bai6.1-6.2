using System.Data;
using System.Data.SqlClient;
using RetailSalesSystem.DTO;

namespace RetailSalesSystem.DAL
{
    public class KhachHangDAL : DBConnect
    {
        public DataTable LayDanhSachKhachHang()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KhachHang", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool ThemKhachHang(KhachHang kh)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO KhachHang (TenKH, DienThoai, DiemTichLuy) VALUES (@TenKH, @DienThoai, @DiemTichLuy)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
                cmd.Parameters.AddWithValue("@DienThoai", kh.DienThoai);
                cmd.Parameters.AddWithValue("@DiemTichLuy", kh.DiemTichLuy);
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
using System.Data;
using System.Data.SqlClient;
using RetailSalesSystem.DTO;

namespace RetailSalesSystem.DAL
{
    public class SanPhamDAL : DBConnect
    {
        public DataTable LayDanhSachSanPham()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM SanPham", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool ThemMoiSanPham(SanPham sp)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO SanPham (MaSP, TenSP, GiaBan, SoLuongTon) VALUES (@MaSP, @TenSP, @GiaBan, @SoLuongTon)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
                cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                cmd.Parameters.AddWithValue("@GiaBan", sp.GiaBan);
                cmd.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);
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
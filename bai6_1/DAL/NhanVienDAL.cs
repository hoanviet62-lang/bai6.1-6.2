using System.Data;
using System.Data.SqlClient;

namespace RetailSalesSystem.DAL
{
    public class NhanVienDAL : DBConnect
    {
        public DataTable LayDanhSachNhanVien()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
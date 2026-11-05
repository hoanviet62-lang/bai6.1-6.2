using System.Collections.Generic;
using System.Data.SqlClient;
using RetailSalesSystem.DTO;

namespace RetailSalesSystem.DAL
{
    public class HoaDonDAL : DBConnect
    {
        public bool TaoHoaDon(HoaDon hd, List<ChiTietHoaDon> dsChiTiet)
        {
            OpenConnection();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                string queryHD = "INSERT INTO HoaDon (NgayLap, MaNV, MaKH, TongTien) OUTPUT INSERTED.MaHD VALUES (GETDATE(), @MaNV, @MaKH, @TongTien)";
                SqlCommand cmdHD = new SqlCommand(queryHD, connection, transaction);
                cmdHD.Parameters.AddWithValue("@MaNV", hd.MaNV);
                cmdHD.Parameters.AddWithValue("@MaKH", hd.MaKH);
                cmdHD.Parameters.AddWithValue("@TongTien", hd.TongTien);

                int maHD = (int)cmdHD.ExecuteScalar();

                foreach (var item in dsChiTiet)
                {
                    string queryCT = "INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES (@MaHD, @MaSP, @SoLuong, @DonGia); " +
                                     "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSP = @MaSP;";
                    SqlCommand cmdCT = new SqlCommand(queryCT, connection, transaction);
                    cmdCT.Parameters.AddWithValue("@MaHD", maHD);
                    cmdCT.Parameters.AddWithValue("@MaSP", item.MaSP);
                    cmdCT.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                    cmdCT.Parameters.AddWithValue("@DonGia", item.DonGia);
                    cmdCT.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
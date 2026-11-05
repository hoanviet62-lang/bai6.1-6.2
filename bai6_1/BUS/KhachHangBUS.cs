using System.Data;
using RetailSalesSystem.DAL;
using RetailSalesSystem.DTO;

namespace RetailSalesSystem.BUS
{
    public class KhachHangBUS
    {
        private KhachHangDAL dal = new KhachHangDAL();

        public DataTable LayDanhSachKhachHang()
        {
            return dal.LayDanhSachKhachHang();
        }

        public bool ThemKhachHang(KhachHang kh)
        {
            return dal.ThemKhachHang(kh);
        }
    }
}
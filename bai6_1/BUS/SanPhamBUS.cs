using System.Data;
using RetailSalesSystem.DAL;
using RetailSalesSystem.DTO;

namespace RetailSalesSystem.BUS
{
    public class SanPhamBUS
    {
        private SanPhamDAL dal = new SanPhamDAL();

        public DataTable LayDanhSachSanPham()
        {
            return dal.LayDanhSachSanPham();
        }

        public bool ThemMoiSanPham(SanPham sp)
        {
            return dal.ThemMoiSanPham(sp);
        }
    }
}
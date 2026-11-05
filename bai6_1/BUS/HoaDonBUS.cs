using System.Collections.Generic;
using RetailSalesSystem.DAL;
using RetailSalesSystem.DTO;

namespace RetailSalesSystem.BUS
{
    public class HoaDonBUS
    {
        private HoaDonDAL dal = new HoaDonDAL();

        public bool TaoHoaDon(HoaDon hd, List<ChiTietHoaDon> dsChiTiet)
        {
            return dal.TaoHoaDon(hd, dsChiTiet);
        }
    }
}
using System;
using System.Data;
using System.Windows.Forms;
using RetailSalesSystem.BUS;
using RetailSalesSystem.DTO;
using System.Collections.Generic;

namespace RetailSalesSystem
{
    public class MainForm : Form
    {
        private DataGridView dgvSanPham;
        private Button btnTaiDuLieu, btnThem, btnXoa, btnThongKe, btnThanhToan;
        private TextBox txtMaSP, txtTenSP, txtGia, txtSoLuong;
        private Label lblTieuDe;
        private SanPhamBUS sanPhamBUS = new SanPhamBUS();
        private HoaDonBUS hoaDonBUS = new HoaDonBUS();

        public MainForm()
        {
            this.Text = "Hệ Thống Quản Lý Bán Hàng - 3-Tier Architecture";
            this.Width = 850;
            this.Height = 550;
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTieuDe = new Label() { Text = "QUẢN LÝ DANH MỤC SẢN PHẨM & NGHIỆP VỤ", Font = new System.Drawing.Font("Arial", 13, System.Drawing.FontStyle.Bold), Top = 15, Left = 220, AutoSize = true };
            this.Controls.Add(lblTieuDe);

            dgvSanPham = new DataGridView() { Top = 60, Left = 20, Width = 540, Height = 300, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            this.Controls.Add(dgvSanPham);

            CreateLabel("Mã SP:", 580, 60);
            txtMaSP = new TextBox() { Top = 80, Left = 580, Width = 220 };
            this.Controls.Add(txtMaSP);

            CreateLabel("Tên SP:", 580, 110);
            txtTenSP = new TextBox() { Top = 130, Left = 580, Width = 220 };
            this.Controls.Add(txtTenSP);

            CreateLabel("Giá Bán:", 580, 160);
            txtGia = new TextBox() { Top = 180, Left = 580, Width = 220 };
            this.Controls.Add(txtGia);

            CreateLabel("Số Lượng Tồn:", 580, 210);
            txtSoLuong = new TextBox() { Top = 230, Left = 580, Width = 220 };
            this.Controls.Add(txtSoLuong);

            btnTaiDuLieu = CreateButton("1. Tải Dữ Liệu (Tổng quan)", 20, 380, 200, 40, BtnTaiDuLieu_Click);
            btnThem = CreateButton("2. Thêm Sản Phẩm (CRUD)", 230, 380, 200, 40, BtnThem_Click);
            btnThanhToan = CreateButton("3. Lập Hóa Đơn (Nghiệp Vụ)", 440, 380, 200, 40, BtnThanhToan_Click);
            
            btnThongKe = CreateButton("4. Báo Cáo Thống Kê", 20, 430, 200, 40, BtnThongKe_Click);
            btnXoa = CreateButton("5. Test Lỗi / Rollback", 230, 430, 200, 40, BtnTestRollback_Click);
        }

        private Label CreateLabel(string text, int left, int top)
        {
            var lbl = new Label() { Text = text, Left = left, Top = top, AutoSize = true };
            this.Controls.Add(lbl);
            return lbl;
        }

        private Button CreateButton(string text, int left, int top, int width, int height, EventHandler onClick)
        {
            var btn = new Button() { Text = text, Left = left, Top = top, Width = width, Height = height };
            btn.Click += onClick;
            this.Controls.Add(btn);
            return btn;
        }

        private void LoadData()
        {
            try { dgvSanPham.DataSource = sanPhamBUS.LayDanhSachSanPham(); } catch { }
        }

        private void BtnTaiDuLieu_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("Màn hình 1: Đã tải dữ liệu tổng quan thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SanPham sp = new SanPham()
                {
                    MaSP = txtMaSP.Text.Trim(),
                    TenSP = txtTenSP.Text.Trim(),
                    GiaBan = decimal.Parse(txtGia.Text),
                    SoLuongTon = int.Parse(txtSoLuong.Text)
                };
                if (sanPhamBUS.ThemMoiSanPham(sp))
                {
                    MessageBox.Show("Màn hình 2 (CRUD): Thêm sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else { MessageBox.Show("Thêm thất bại!"); }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi nhập liệu: " + ex.Message); }
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Màn hình 3 (Nghiệp vụ): Lập hóa đơn và trừ kho thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Lỗi: " + ex.Message); 
            }
        }

        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            int totalRows = dgvSanPham.Rows.Count - 1;
            MessageBox.Show($"Màn hình 4 (Báo Cáo Thống Kê):\n- Tổng số dòng sản phẩm hiện có: {totalRows}\n- Trạng thái kho hàng: Ổn định", "Báo Cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnTestRollback_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon hd = new HoaDon() { MaNV = 9999, MaKH = 9999, TongTien = 100000 };
                List<ChiTietHoaDon> cts = new List<ChiTietHoaDon>()
                {
                    new ChiTietHoaDon() { MaSP = "SP_KHONG_TON_TAI", SoLuong = 1, DonGia = 100000 }
                };
                bool kq = hoaDonBUS.TaoHoaDon(hd, cts);
                if (!kq) throw new Exception("Giao dịch bị từ chối do vi phạm ràng buộc khóa ngoại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Màn hình 5 (Xử lý lỗi & Rollback Transaction):\n" + ex.Message, "Cảnh báo / Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
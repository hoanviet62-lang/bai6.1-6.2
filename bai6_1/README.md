# MỤC 1: THÔNG TIN SINH VIÊN
- Họ và tên sinh viên: Bùi Lê Hoàn
- Mã sinh viên: [Điền Mã Sinh Viên của bạn vào đây]
- Tên Đề tài / Bài tập: Hệ Thống Quản Lý Bán Hàng (3-Tier Architecture)

---

# MỤC 2: HƯỚNG DẪN CÀI ĐẶT & CHẠY DỰ ÁN

## Các bước cài đặt:
1. Mở SQL Server Management Studio (SSMS), chạy file `Database/ScriptDB.sql` để khởi tạo CSDL và dữ liệu mẫu.
2. Mở file `.sln` bằng Visual Studio 2022 (hoặc mở thư mục project bằng Visual Studio Code).
3. Mở file cấu hình (`App.config` hoặc `DBConnect.cs`), sửa lại chuỗi kết nối `ConnectionString` cho phù hợp với máy cá nhân.
4. Build & Run dự án (F5 hoặc lệnh `dotnet run`).

---

# MỤC 3: HÌNH ẢNH KẾT QUẢ CÁC MÀN HÌNH CHỨC NĂNG

1. **Màn hình Chính / Tổng quan:**
   ![Màn hình chính](screenshots/bai6.1/01_main_screen.png)

2. **Màn hình Quản lý Danh mục / Thêm Sửa Xóa (CRUD):**
   ![Màn hình CRUD](screenshots/bai6.1/02_crud_screen.png)

3. **Màn hình Thực thi Nghiệp vụ chính (Lập hóa đơn / Trừ kho):**
   ![Màn hình Nghiệp vụ](screenshots/bai6.1/03_transaction_screen.png)

4. **Màn hình Báo cáo Thống kê:**
   ![Màn hình Thống kê](screenshots/bai6.1/04_report_screen.png)

5. **Minh họa Xử lý lỗi hoặc Rollback Transaction:**
   ![Minh họa xử lý lỗi](screenshots/bai6.1/05_error_handling.png)
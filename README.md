# Dispatch Tool
Công cụ phân tuyến sử dụng C# và Windows Forms

## Thư viện sử dụng

- [A Fast CSV Reader [LumenWorks.Framework.IO]] (http://www.codeproject.com/Articles/9258/A-Fast-CSV-Reader)

## Danh sách cần làm

- [ ] Nháy đúp chuột trái để mở đơn hàng trong trình duyệt.
- [ ] Xuất riêng lẻ từng phiên bằng cách nhấp chuột phải.

## Những vấn đề đã biết

- Cỡ chữ ở ListViewGroup quá nhỏ.
- Khó khăn khi mở phiên đã xuất ở định dạng CSV bằng Excel. Nên chuyển sang dùng *.tsv hoặc *.xls.

## Nhật kí thay đổi

### 2015-12-19

- Cho phép nhập dữ liệu từ tệp CSV thay vì kết nối đến MySQL server.
- Sử dụng ListView để hiển thị danh sách đơn hàng đã scan.
- Xuất danh sách từng phiên với định dạng CSV.

### 2015-12-18

- Phiên bản demo đầu tiên. Sử dụng kết nối MySQL để lấy dữ liệu từ máy chủ.

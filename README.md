# Dispatch Tool
Công cụ phân tuyến sử dụng C# và Windows Forms

## Screen shot

![Screen shot](https://raw.githubusercontent.com/giautm/dispatch-tool/master/screen-shot.png)

## Thư viện sử dụng

- [A Fast CSV Reader [LumenWorks.Framework.IO]](http://www.codeproject.com/Articles/9258/A-Fast-CSV-Reader)

## Danh sách cần làm

- [x] Nháy đúp chuột trái để mở đơn hàng trong trình duyệt.

- [x] ~~Xuất riêng lẻ từng phiên bằng cách nhấp chuột phải.~~

## Những vấn đề đã biết

- ~~Cỡ chữ ở ListViewGroup quá nhỏ~~. Vẫn chưa thay đổi được cỡ chữ ở Group.
- ~~Khó khăn khi mở phiên đã xuất ở định dạng CSV bằng Excel. Nên chuyển sang dùng *.tsv hoặc *.xls.~~

## Nhật kí thay đổi

### 2012-12-29

- Xuất gộp tất cả các tuyến thành một tệp duy nhất với format `PNH_yyyy-MM-dd_HH-mm-ss`. Trong đó: `PNH` nghĩa là `Phiên nhập hàng`, chuỗi còn lại là ngày và thời gian (Ví dụ: `PNH_2015-12-20_12-11-59`)
- Tự tạo thư mục xuất tệp tin theo ngày, theo định dạng: `D:\NHAP_HANG\{yyyy-MM-dd}`.
- Tự chọn đường dẫn theo ngày, người dùng chỉ cần nhấp `OK` trên hộp thoại để xuất tệp.

### 2015-12-20

- Thêm `sep=,` ở đầu tệp CSV cho phép Excel nhận diện đúng kí tự phân cách field.
- Tăng cỡ chữ ở ListView.
- Nháy đúp để mở đơn hàng trong CPN.

### 2015-12-19

- Cho phép nhập dữ liệu từ tệp CSV thay vì kết nối đến MySQL server.
- Sử dụng ListView để hiển thị danh sách đơn hàng đã scan.
- Xuất danh sách từng phiên với định dạng CSV.

### 2015-12-18

- Phiên bản demo đầu tiên. Sử dụng kết nối MySQL để lấy dữ liệu từ máy chủ.
# BepTuDong
# Cách sử dụng
- Chạy file Sql CREATEDB trước
- Chạy file Solution của Visual Studio
# Tổng quan về phần mềm
Các giao diện chính của phần mềm
wdLogin: 
Đăng nhập vào hệ thống

wdHome:
Giao diện chính của hệ thống dùng để truy cập vào các chức năng.

wdIngredient:
Giao diện dùng để chỉnh sửa phần Nguyên liệu có trong hệ thống. Các chức năng chính là Add, Edit, Delete, danh sách nguyên liệu được hiển thị trong Listview. Tên nguyên liệu và đơn vị được lưu vào CSDL dưới dạng Uppercase. Tên đơn vị fix cứng, chỉ được lựa chọn trong combobox, muốn thêm hay xóa thì sẽ thực hiện trong Database ở bảng tên đơn vị.

wdRecipeOverview:
Xử lý phần công thức các món ăn. Các control chính trên giao diện gồm có Add, Edit, Delete, TestCook, Cook 1-4 (hiện tại chưa dùng đến), Cook và Listview hiển thị danh sách các công thức món ăn đã được tạo.
Thao tác: Ấn Add để thêm Công thức món ăn mới (hiển thị wd. Sau khi thêm, Công thức sẽ được hiển thị ở listview bên dưới. Nếu muốn sửa hay xóa công thức, chọn Công thức ở listview trước rồi ấn Edit hoặc Delete. Nếu ko chọn mà ấn luôn sẽ thông báo lỗi. Nút TestCook được sử dụng để gửi dữ liệu của công thức được lựa chọn để nấu xuống cho Bếp và Robot thực hiện các thao tác tương ứng

--1. Viết SP spTangLuong dùng để tăng lương lên 10% cho tất cả các nhân viên.

AS
BEGIN
    UPDATE NHANVIEN SET Luong = Luong * 1.1
END

CREATE PROCEDURE spTangLuong
AS
BEGIN
    UPDATE NHANVIEN SET Luong = Luong * 1.1
END

--2. Thêm vào cột NgayNghiHuu (ngày nghỉ hưu) trong bảng NHANVIEN. Viết SP

spNghiHuu dùng để cập nhật ngày nghỉ hưu là ngày hiện tại cộng thêm 100 (ngày) cho những
nhân viên nam có tuổi từ 60 trở lên và nữ từ 55 trở lên.

ALTER TABLE NHANVIEN ADD NgayNghiHuu DATE;
CREATE PROCEDURE spNghiHuu
AS
BEGIN
    UPDATE NHANVIEN 
    SET NgayNghiHuu = DATEADD(day, 100, GETDATE())
    WHERE GioiTinh = 'Nam' AND DATEDIFF(year, NgaySinh, GETDATE()) >= 60 OR GioiTinh = 'Nữ' AND DATEDIFF(year, NgaySinh, GETDATE()) >= 55
END

--3. Tạo SP spXemDeAn cho phép xem các đề án có địa điểm đề án được truyền vào khi
gọi thủ tục.

CREATE PROCEDURE spXemDeAn
    @DiaDiem VARCHAR(50)
AS
BEGIN
    SELECT * FROM DEAN WHERE DiaDiem = @DiaDiem
END

--4. Tạo SP spCapNhatDeAn cho phép cập nhật lại địa điểm đề án với 2 tham số truyền
vào là diadiem_cu, diadiem_moi.

CREATE PROCEDURE spCapNhatDeAn
    @DiaDiemCu VARCHAR(50),
    @DiaDiemMoi VARCHAR(50)
AS
BEGIN
    UPDATE DEAN SET DiaDiem = @DiaDiemMoi WHERE DiaDiem = @DiaDiemCu
END


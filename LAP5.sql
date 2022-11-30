create proc lab5_cau1_a @name nvarchar(20)
as
	begin
		print 'Xin chào: ' + @name
	end
exec lab5_cau1_a N'Hoàng Hoa'
go



create proc lab5_cau1_b @so1 int, @so2 int
as
	begin
		declare @tong int = 0;
		set @tong = @so1 + @so2 
		print 'tong: ' + cast(@tong as varchar(10))
	end

exec lab5_cau1_b 7,8
go



create proc lab5_cau1_c @l int
as
	begin
		declare @tong int = 0, @i int = 0;
		while @i < @l
			begin
				set @tong = @tong + @i
				set @i = @i + 2
			end
		print 'tổng: ' + cast(@tong as varchar(10))
	end
exec lab5_cau1_c 15
go



create proc lab5_cau1_d @a int, @b int
as
	begin
		while (@a != @b)
			begin
				if(@a > @b)
					set @a = @a -@b
				else
					set @b = @b - @a
			end
			return @a
	end
declare @l int
exec @l = lab5_cau1_d 5,7 
print @l
go



create proc lab5_cau2_a @MaNV varchar(20)
as
	begin
		select * from NHANVIEN where MANV = @MaNV
	end
exec lab5_cau2_a '003'
go



select count(MANV), MADA, TENPHG from NHANVIEN
inner join PHONGBAN on NHANVIEN.PHG = PHONGBAN.MAPHG
inner join DEAN on DEAN.PHONG = PHONGBAN.MAPHG
where MADA = 2
group by TENPHG,MADA

alter proc lab5_cau2_b @manv int
as
begin
		select count(MANV) as 'so luong', MADA, TENPHG from NHANVIEN
		inner join PHONGBAN on NHANVIEN.PHG = PHONGBAN.MAPHG
		inner join DEAN on DEAN.PHONG = PHONGBAN.MAPHG
		where MADA = @manv
		group by TENPHG,MADA
end
exec lab5_cau2_b 10 
go



Bài 3:

create proc sp_ThemPhongBan @TenPHG nvarchar(15), @MaPHG int,
@TRPHG nvarchar(9), @NG_NHANCHUC date
as
if exists (select * from PHONGBAN where MAPHG = @MaPHG)
update PHONGBAN set TENPHG = @TenPHG, TRPHG = @Trphg, NG_NHANCHUC = @NG_NHANCHUC
where MAPHG = @MaPHG
else
insert into PHONGBAN
values (@TenPHG, @MaPHG, @TRPHG, @NG_NHANCHUC)
drop proc sp_ThemPhongBan
go
exec sp_ThemPhongBan 'CNTT', 6, '008', '1985-01-01'

-----------------
create proc sp_capnhatphongban
	@TENPHGCU nvarchar(15),
	@TENPHG nvarchar(15),
	@MAPHG int,
	@TRPHG nvarchar(9),
	@NG_NHANCHUC date
as
begin
	update PHONGBAN
	set TENPHG = @TENPHG,
		MAPHG = @MAPHG,
		TRPHG = @TRPHG,
		NG_NHANCHUC = @NG_NHANCHUC
	where TENPHG = @TENPHGCU;
end;

exec sp_capnhatphongban 'CNTT', 'IT', 10, '005', '1-1-2020';

--------------------

create proc sp_themNV
	@HONV nvarchar(15),
	@TENLOT nvarchar(15),
	@TENNV nvarchar(15),
	@MANV nvarchar(9),
	@NGSINH datetime,
	@DCHI nvarchar(30),
	@PHAI nvarchar(3),
	@LUONG float,
	@PHG int
as
begin
	if not exists(select*from PHONGBAN where TENPHG = 'IT')
	begin
		print N'Nhân viên phải trực thuộc phòng IT';
		return;
	end;
	declare @MA_NQL nvarchar(9);
	if @LUONG > 25000
		set @MA_NQL = '005';
	else
		set @MA_NQL = '009';
	declare @age int;
	select @age = DATEDIFF(year,@NGSINH,getdate()) + 1;
	if @PHAI = 'Nam' and (@age < 18 or @age >60)
	begin
		print N'Nam phải có độ tuổi từ 18-65';
		return;
	end;
	else if @PHAI = 'Nữ' and (@age < 18 or @age >60)
	begin
		print N'Nữ phải có độ tuổi từ 18-60';
		return;
	end;
	INSERT INTO NHANVIEN(HONV,TENLOT,TENNV,MANV,NGSINH,DCHI,PHAI,LUONG,MA_NQL,PHG)
		VALUES(@HONV,@TENLOT,@TENNV,@MANV,@NGSINH,@DCHI,@PHAI,@LUONG,@MA_NQL,@PHG)
end;

exec sp_themNV ,N'Hoang ',N'Hoa ','022','27-9-2002',N'TayNinh','Nữ',30000,6;







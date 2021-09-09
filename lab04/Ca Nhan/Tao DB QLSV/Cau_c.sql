

/*----------------------------------------------------------
MASV: 1712601
HO TEN: Trinh Van Minh
LAB: 04
NGAY: 12/06/2021
----------------------------------------------------------*/
-- CAU LENH TAO STORED PROCEDURE


use QLSV
go

create procedure SP_INS_ENCRYPT_SINHVIEN
@masv NVARCHAR(20), @hoten NVARCHAR(100), @ngaysinh DATETIME, @diachi NVARCHAR(200), @malop VARCHAR(20), @tendn NVARCHAR(100), @matkhau VARBINARY(MAX)
as
	insert SINHVIEN(MASV, HOTEN, NGAYSINH, DIACHI, MALOP, TENDN, MATKHAU)
	values(@masv, @hoten,@ngaysinh,@diachi,@malop,@tendn, @matkhau)
go

--DROP PROCEDURE SP_INS_ENCRYPT_SINHVIEN
EXEC SP_INS_ENCRYPT_SINHVIEN N'SV01', N'NGUYEN VAN A', '1/1/1990', N'280 AN DUONG VUONG', 'CNTT-K35', N'NVA', 0xe10adc3949ba59abbe56e057f20f883e
select * from sinhvien

--delete sinhvien

--------------------------------------------------------------------------

create procedure SP_INS_ENCRYPT_NHANVIEN
@MANV VARCHAR(20),@HOTEN NVARCHAR(100),@EMAIL VARCHAR(20),@LUONG VARBINARY(MAX),@TENDN NVARCHAR(100),@MATKHAU VARBINARY(MAX)
as
	insert nhanvien(MANV, HOTEN, EMAIL, LUONG, TENDN, MATKHAU)
	values(@MANV, @HOTEN, @EMAIL, @LUONG, @TENDN, @MATKHAU)
go

EXEC SP_INS_ENCRYPT_NHANVIEN 'NV04', 'NGUYEN VAN A', 'NVA@', 0xDCD342BF2AE566B8FA591819ED04A60F, 'NVA', 0x7c4a8d09ca3762af61e59520943dc26494f8941b
select * from nhanvien
--delete nhanvien
-------------------------------------------------------------------------

create procedure SP_SEL_ENCRYPT_NHANVIEN
as
	SELECT MANV, HOTEN, EMAIL, LUONG
	FROM NHANVIEN 
GO

EXEC SP_SEL_ENCRYPT_NHANVIEN
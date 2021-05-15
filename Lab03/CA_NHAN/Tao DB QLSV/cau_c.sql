/*----------------------------------------------------------
MASV: 1712601
HO TEN: Trinh Van Minh
LAB: 03
NGAY: 09/05/2021
----------------------------------------------------------*/
-- CAU LENH TAO STORED PROCEDURE


use QLSV
go

create procedure SP_INS_SINHVIEN 
@masv NVARCHAR(20), @hoten NVARCHAR(100), @ngaysinh DATETIME, @diachi NVARCHAR(200), @malop VARCHAR(20), @tendn NVARCHAR(100), @matkhau VARCHAR(20)
as
	insert SINHVIEN(MASV, HOTEN, NGAYSINH, DIACHI, MALOP, TENDN, MATKHAU)
	values(@masv, @hoten,@ngaysinh,@diachi,@malop,@tendn,HashBytes('MD5', @matkhau))
go


EXEC SP_INS_SINHVIEN 'SV01', 'NGUYEN VAN A', '1/1/1990', '280 AN DUONG VUONG', 'CNTT-K35', 'NVA', '123456'
select * from sinhvien


--step1 create master key


--if there is no master key create one
IF NOT EXISTS
(
	SELECT *
	FROM sys.symmetric_keys
	WHERE symmetric_key_id = 101
)

CREATE MASTER KEY ENCRYPTION BY PASSWORD = '1712601'

GO 

--step2 create cert

IF NOT EXISTS
(
	SELECT *
	FROM sys.certificates
	WHERE name = 'MyCert'
)
CREATE CERTIFICATE MyCert 
WITH SUBJECT = 'MyCert';
GO
 
 
--step3 create private key

IF NOT EXISTS
(
	SELECT *
	FROM sys.symmetric_keys
	WHERE name = 'PriKey'
)

CREATE SYMMETRIC KEY PriKey
	--WITH ALGORITHM = TRIPLE_DES
	WITH ALGORITHM = AES_256
	ENCRYPTION BY CERTIFICATE MyCert;
GO

--step4 encrypt data

OPEN SYMMETRIC KEY PriKey
DECRYPTION BY CERTIFICATE MyCert;

create procedure SP_INS_NHANVIEN
@MANV VARCHAR(20),@HOTEN NVARCHAR(100),@EMAIL VARCHAR(20),@LUONG int,@TENDN NVARCHAR(100),@MATKHAU VARCHAR(20)
as
insert nhanvien(MANV, HOTEN, EMAIL, LUONG, TENDN, MATKHAU)
values(@MANV,@HOTEN,@EMAIL, ENCRYPTBYKEY(KEY_GUID('PriKey'),convert(varbinary,@LUONG)),@TENDN,HashBytes('SHA1',@MATKHAU))
go


EXEC SP_INS_NHANVIEN 'NV04', 'NGUYEN VAN A', 'NVA@', 3000000, 'NVA', 'abcd12'
select * from nhanvien


--declare @luong varbinary(MAX), @mk varbinary(MAX)
--set @luong = 0x00E21A2D28E36E40B461D594E7934AAB020000001EF3F5D38F7DFFB04F1EEAFDAF0A7173CA99BA9C813BD4565CFB4BE78AA040DA
--select convert(int,DECRYPTBYKEY(@luong))


create procedure SP_SEL_NHANVIEN
as
SELECT MANV, HOTEN, EMAIL, convert(int,DECRYPTBYKEY(LUONG)) AS LUONGCB
FROM NHANVIEN 
GO

EXEC SP_SEL_NHANVIEN
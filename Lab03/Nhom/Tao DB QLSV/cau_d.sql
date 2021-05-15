/*---------------------------------------------------------- 
MASV: 1712601 - 1712633
HO TEN CAC THANH VIEN NHOM: Trịnh Văn Minh, Nguyễn Long Nhật
LAB: 03 - NHOM 
NGAY: 10/05/2021
----------------------------------------------------------*/ 
use QLSVNhom
go


--clear ASYMMETRIC KEY
IF EXISTS(
    SELECT *
    FROM sys.symmetric_keys
    WHERE name = 'NV01')
BEGIN
    DROP ASYMMETRIC KEY NV01  
END;
go

IF EXISTS(
    SELECT *
    FROM sys.symmetric_keys
    WHERE name = 'NV02')
BEGIN
    DROP ASYMMETRIC KEY NV02  
END;
go
-------

insert into nhanvien(MANV, HOTEN, EMAIL, LUONG, TENDN, MATKHAU, PUBKEY)
values	('NV01','NGUYEN VAN A','nva@yahoo.com',convert(varbinary,3000000),'NVA',convert(varbinary,'123456'),'NV01'),
		('NV02','NGUYEN VAN B','nvb@yahoo.com',convert(varbinary,2000000),'NVB',convert(varbinary,'1234567'),'NV02')
go

select * from nhanvien

insert into LOP(MALOP, TENLOP, MANV)
values	('CTT1',N'Công nghệ thông tin','NV01'),
('CTT2',N'Công nghệ thông tin','NV01'),
('CTT3',N'Công nghệ thông tin','NV01'),
('CTT4',N'Công nghệ thông tin','NV01'),
('CTT5',N'Công nghệ thông tin','NV01'),

('CNSH1',N'Công nghệ sinh học','NV02'),
('CNSH2',N'Công nghệ sinh học','NV02'),
('CNSH3',N'Công nghệ sinh học','NV02'),
('CNSH4',N'Công nghệ sinh học','NV02'),
('CNSH5',N'Công nghệ sinh học','NV02')
go

select * from lop

insert into SINHVIEN(MASV,HOTEN,NGAYSINH,DIACHI, MALOP, TENDN, MATKHAU)
VALUES	('1712601',N'Trịnh Văn Minh','1/1/1999',N'HCM','CTT5','1712601',convert(varbinary,'mk')),
		('1712633',N'Nguyễn Long Nhật','1/1/1999',N'Bình Dương','CNSH1','1312633',convert(varbinary,'mk'))

select * from sinhvien

insert into HOCPHAN(MAHP, TENHP, SOTC)
VALUES	('TLDC', N'Tâm Lý Đại Cương',3),
		('CTDL',N'Cấu trúc dữ liệu và giải thuật',4),
		('SH',N'Sinh học',4),
		('VLDC1',N'Vật lý đại cương 1',3),
		('VLDC2',N'Vật lý đại cương 2',3)
go

select * from hocphan

insert into BANGDIEM(MASV,MAHP,DIEMTHI)
VALUES	('1712601','CTDL',convert(varbinary,10)),
		('1712633','TLDC',convert(varbinary,5))

select * from BANGDIEM
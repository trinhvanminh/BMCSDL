﻿/*---------------------------------------------------------- 
MASV: 1712601 - 1712633
HO TEN CAC THANH VIEN NHOM: Trịnh Văn Minh, Nguyễn Long Nhật
LAB: 03 - NHOM 
NGAY: 10/05/2021
----------------------------------------------------------*/ 
--CAC CAU LENH TAO TABLE 

USE QLSVNhom
GO

--drop table sinhvien
create table SINHVIEN
(
	MASV		VARCHAR(20),
	HOTEN		NVARCHAR(100)		NOT NULL,
	NGAYSINH	DATETIME,
	DIACHI		NVARCHAR(200),
	MALOP		VARCHAR(20),
	TENDN		NVARCHAR(100)		NOT NULL,
	MATKHAU		VARBINARY(MAX)		NOT NULL,
	
	PRIMARY KEY(MASV)
)
--drop table nhanvien
create table NHANVIEN
(
	MANV	VARCHAR(20),
	HOTEN	NVARCHAR(100)	NOT NULL,
	EMAIL	VARCHAR(20),
	LUONG	VARBINARY(MAX),
	TENDN	NVARCHAR(100)	NOT NULL,
	MATKHAU	VARBINARY(MAX)		NOT NULL,
	PUBKEY	VARCHAR(20),

	PRIMARY KEY(MANV)
)
--drop table lop
create table LOP
(
	MALOP	VARCHAR(20),
	TENLOP	NVARCHAR(100)	NOT NULL,
	MANV	VARCHAR(20),

	PRIMARY KEY(MALOP)
)

--drop table hocphan
create table HOCPHAN
(
	MAHP	VARCHAR(20),
	TENHP	NVARCHAR(100)	NOT NULL,
	SOTC	INT,

	PRIMARY KEY(MAHP)
)

--drop table bangdiem
create table BANGDIEM
(
	MASV	VARCHAR(20),
	MAHP	VARCHAR(20),
	DIEMTHI	VARBINARY(MAX),

	PRIMARY KEY(MASV, MAHP)
)

ALTER TABLE BANGDIEM ADD FOREIGN KEY(MASV) REFERENCES SINHVIEN(MASV);
ALTER TABLE BANGDIEM ADD FOREIGN KEY(MAHP) REFERENCES HOCPHAN(MAHP);
ALTER TABLE SINHVIEN ADD FOREIGN KEY(MALOP) REFERENCES LOP(MALOP);
ALTER TABLE LOP ADD FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV);



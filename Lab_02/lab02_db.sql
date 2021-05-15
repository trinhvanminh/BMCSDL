use master
go
---DROP DATABASE QLBongDa

create database QLBongDa
go
use QLBongDa
go

CREATE TABLE CAUTHU
(
	MACT		NUMERIC			IDENTITY(1,1),
	HOTEN		NVARCHAR(100)	NOT NULL,
	VITRI		NVARCHAR(20)	NOT NULL,
	NGAYSINH	DATETIME,
	DIACHI		NVARCHAR(200),
	MACLB		VARCHAR(5)		NOT NULL,
	MAQG		VARCHAR(5)		NOT NULL,
	SO			INT				NOT NULL,
	
	PRIMARY KEY(MACT)
)


CREATE TABLE QUOCGIA
(
	MAQG	VARCHAR(5),
	TENQG	NVARCHAR(60)	NOT NULL,

	PRIMARY KEY(MAQG)
)

CREATE TABLE CAULACBO
(
	MACLB	VARCHAR(5),
	TENCLB	NVARCHAR(100)	NOT NULL,
	MASAN	VARCHAR(5)		NOT NULL,
	MATINH	VARCHAR(5)		NOT NULL,

	PRIMARY KEY(MACLB)
)

CREATE TABLE TINH
(
	MATINH	VARCHAR(5),
	TENTINH	NVARCHAR(100)	NOT NULL,

	PRIMARY KEY(MATINH)
)

CREATE TABLE SANVD
(
	MASAN	VARCHAR(5),
	TENSAN	NVARCHAR(100)	NOT NULL,
	DIACHI	NVARCHAR(200),

	PRIMARY KEY(MASAN)
)

CREATE TABLE HUANLUYENVIEN
(
	MAHLV		VARCHAR(5),
	TENHLV		NVARCHAR(100)	NOT NULL,
	NGAYSINH	DATETIME,
	DIACHI		NVARCHAR(200),
	DIENTHOAI	NVARCHAR(20),
	MAQG		VARCHAR(5)		NOT NULL,

	PRIMARY KEY(MAHLV)
)

CREATE TABLE HLV_CLB
(
	MAHLV	VARCHAR(5),
	MACLB	VARCHAR(5),
	VAITRO	NVARCHAR(100)	NOT NULL,

	PRIMARY KEY(MAHLV, MACLB)
)

CREATE TABLE TRANDAU
(
	MATRAN	NUMERIC		IDENTITY(1,1),
	NAM		INT			NOT NULL,
	VONG	INT			NOT NULL,
	NGAYTD	DATETIME	NOT NULL,
	MACLB1	VARCHAR(5)	NOT NULL,
	MACLB2	VARCHAR(5)	NOT NULL,
	MASAN	VARCHAR(5)	NOT NULL,
	KETQUA	VARCHAR(5)	NOT NULL,
	
	PRIMARY KEY(MATRAN)
)

CREATE TABLE BANGXH
(
	MACLB	VARCHAR(5),
	NAM		INT,
	VONG	INT,
	SOTRAN	INT				NOT NULL,
	THANG	INT				NOT NULL,
	HOA		INT				NOT NULL,
	THUA	INT				NOT NULL,
	HIEUSO	VARCHAR(5)		NOT NULL,
	DIEM	INT				NOT NULL,
	HANG	INT				NOT NULL,

	PRIMARY KEY(MACLB,NAM,VONG)
)
GO

ALTER TABLE TRANDAU ADD CONSTRAINT FK_TRANDAU_MASAN FOREIGN KEY(MASAN) REFERENCES SANVD(MASAN)
ALTER TABLE TRANDAU ADD CONSTRAINT FK_TRANDAU_MACLB FOREIGN KEY(MACLB1) REFERENCES CAULACBO(MACLB)
ALTER TABLE TRANDAU ADD CONSTRAINT FK_TRANDAU_MACLB2 FOREIGN KEY(MACLB2) REFERENCES CAULACBO(MACLB)
ALTER TABLE CAULACBO ADD CONSTRAINT FK_CLB_SANVD FOREIGN KEY(MASAN) REFERENCES SANVD(MASAN)
ALTER TABLE CAULACBO ADD CONSTRAINT FK_CLB_TINH FOREIGN KEY(MATINH) REFERENCES TINH(MATINH)
ALTER TABLE BANGXH ADD CONSTRAINT FK_BANGXH_CLB FOREIGN KEY(MACLB) REFERENCES CAULACBO(MACLB)
ALTER TABLE CAUTHU ADD CONSTRAINT FK_CT_CLB FOREIGN KEY(MACLB) REFERENCES CAULACBO(MACLB)
ALTER TABLE CAUTHU ADD CONSTRAINT FK_CT_QG FOREIGN KEY(MAQG) REFERENCES QUOCGIA(MAQG)
ALTER TABLE HLV_CLB ADD CONSTRAINT FK_HLVCLB_CLB FOREIGN KEY(MACLB) REFERENCES CAULACBO(MACLB)
ALTER TABLE HLV_CLB ADD CONSTRAINT FK_HLVCLB_HLV FOREIGN KEY(MAHLV) REFERENCES HUANLUYENVIEN(MAHLV)
ALTER TABLE HUANLUYENVIEN ADD CONSTRAINT FK_HLV_QG FOREIGN KEY(MAQG) REFERENCES QUOCGIA(MAQG)
GO

INSERT INTO QUOCGIA(MAQG, TENQG) 
VALUES('VN', N'Việt Nam'),
	  ('ANH', N'Anh Quốc'),
	  ('TBN', N'Tây Ban Nha'),
	  ('BDN', N'Bồ Đào Nha'),
	  ('BRA', N'Brazil'),
	  ('ITA', N'Ý'),
	  ('THA', N'Thái Lan');
GO

INSERT INTO HUANLUYENVIEN(MAHLV, TENHLV, NGAYSINH, DIENTHOAI,MAQG)
VALUES('HLV01', N'Vital', '1995/10/15', N'0918011075', 'BDN'),
      ('HLV02', N'Lê Huỳnh Đức', '1972/05/20', N'01223456789', 'VN'),
      ('HLV03', N'Kiatisuk', '1970/12/11', N'01990123456', 'THA'),
	  ('HLV04', N'Hoàng Anh Tuấn', '1970/06/10', N'0989112233', 'VN'),
      ('HLV05', N'Trần Công Minh', '1973/07/07', N'0909099990', 'VN'),
      ('HLV06', N'Trần Văn Phúc', '1965/03/02', N'01650101234', 'VN');
GO

INSERT INTO SANVD(MASAN, TENSAN, DIACHI)
VALUES('GD', N'Gò Đậu', N'123 QL1, TX Thủ Dầu Một, Bình Dương'),
	  ('PL', N'Pleiku', N'22 Hồ Tùng Mậu, Thống Nhất, Thị xã Pleiku, Gia Lai'),
	  ('CL', N'Chi Lăng', N'127 Võ Văn Tần, Đà Nẵng'),
	  ('NT', N'Nha Trang', N'128 Phan Chu Trinh, Nha Trang, Khánh Hòa'),
	  ('TH', N'Tuy Hòa', N'57 Trường Chinh, Tuy Hòa, Phú Yên'),
	  ('LA', N'Long An', N' 102 Hùng Vương, Tp Tân An, Long An');
GO

INSERT INTO TINH(MATINH, TENTINH)
VALUES('BD', N'Bình Dương'),
      ('GL', N'Gia Lai'),
	  ('DN', N'Đà Nẵng'),
	  ('KH', N'Khánh Hòa'),
	  ('PY', N'Phú Yên'),
	  ('LA', N'Long An');
GO

INSERT INTO CAULACBO(MACLB, TENCLB, MASAN, MATINH)
VALUES('BBD', N'BECAMEX BÌNH DƯƠNG', 'GD', 'BD'),
	  ('HAGL', N' HOÀNG ANH GIA LAI', 'PL', 'GL'),
	  ('SDN', N'SHB ĐÀ NẴNG', 'CL', 'DN'),
	  ('KKH', N'KHATOCO KHÁNH HÒA', 'NT', 'KH'),
	  ('TPY', N'THÉP PHÚ YÊN', 'TH', 'PY'),
	  ('GDT', N'GẠCH ĐỒNG TÂM LONG AN', 'LA', 'LA');
GO   

INSERT INTO CAUTHU(HOTEN, VITRI, NGAYSINH, DIACHI, MACLB, MAQG, SO)
VALUES(N'Nguyễn Vũ Phong', N'Tiền vệ', convert(datetime,'20/02/1990',103), NULL, 'BBD', 'VN', 17),
	  (N'Nguyễn Công Vinh', N'Tiền đạo', convert(datetime,'10/03/1992',103), NULL, 'HAGL', 'VN', 9),
	  (N'Trần Tấn Tài', N'Tiền vệ', convert(datetime,'12/11/1989',103), NULL, 'BBD', 'VN', 8),
	  (N'Trần Tấn Tài', N'Tiền vệ', convert(datetime,'12/11/1989',103), NULL, 'BBD', 'VN', 8),
	  (N'Phan Hồng Sơn', N'Thủ môn', convert(datetime,'10/06/1991',103), NULL, 'HAGL', 'VN', 1),
      (N'Ronaldo', N'Tiền vệ', convert(datetime,'12/12/1989',103), NULL, 'SDN', 'BRA', 7),
      (N'Robinho', N'Tiền vệ', convert(datetime,'12/10/1989',103), NULL, 'SDN', 'BRA', 8),
      (N'Vidic', N'Hậu vệ', convert(datetime,'15/10/1987',103), NULL, 'HAGL', 'ANH', 3),
      (N'Trần Văn Santos', N'Thủ môn', convert(datetime,'21/10/1990',103), NULL, 'BBD', 'BRA', 1);
GO

INSERT INTO BANGXH(MACLB, NAM, VONG, SOTRAN, THANG, HOA, THUA, HIEUSO, DIEM, HANG)
VALUES('BBD', 2009, 1, 1, 1, 0, 0, '3-0', 3, 1),
	  ('KKH', 2009, 1, 1, 0, 1, 0, '1-1', 1, 2),
	  ('GDT', 2009, 1, 1, 0, 1, 0, '1-1', 1, 3),
	  ('TPY', 2009, 1, 0, 0, 0, 0, '0-0', 0, 4),
	  ('SDN', 2009, 1, 1, 0, 0, 1, '0-3', 0, 5),
	  ('TPY', 2009, 2, 1, 1, 0, 0, '5-0', 3, 1),
	  ('BBD', 2009, 2, 2, 1, 0, 1, '3-5', 3, 2),
	  ('KKH', 2009, 2, 2, 0, 2, 0, '3-3', 2, 3),
	  ('GDT', 2009, 2, 1, 0, 1, 0, '1-1', 1, 4),
	  ('SDN', 2009, 2, 2, 1, 1, 0, '2-5', 1, 5),
	  ('BBD', 2009, 3, 3, 2, 0, 1, '4-5', 6, 1),
	  ('GDT', 2009, 3, 2, 1, 1, 0, '3-1', 4, 2),
	  ('TPY', 2009, 3, 2, 1, 0, 1, '5-2', 3, 3),
	  ('KKH', 2009, 3, 3, 0, 2, 1, '3-4', 2, 4),
	  ('SDN', 2009, 3, 2, 1, 1, 0, '2-5', 1, 5),
	  ('BBD', 2009, 4, 4, 2, 1, 1, '6-7', 7, 1),
	  ('GDT', 2009, 4, 3, 1, 2, 0, '5-1', 5, 2),
	  ('KKH', 2009, 4, 4, 1, 2, 1, '4-4', 5, 3),
	  ('TPY', 2009, 4, 3, 1, 0, 2, '5-3', 3, 4),
	  ('SDN', 2009, 4, 2, 1, 1, 0, '2-5', 1, 5);
GO
	  	  
INSERT INTO TRANDAU(NAM, VONG, NGAYTD, MACLB1, MACLB2, MASAN, KETQUA)
VALUES(2009, 1, '2009/02/7', 'BBD', 'SDN', 'GD', '3-0'),  
	  (2009, 1, '2009/02/7', 'KKH', 'GDT', 'NT', '1-1'),
	  (2009, 2, '2009/02/16', 'SDN', 'KKH', 'CL', '2-2'),
	  (2009, 2, '2009/02/16', 'TPY', 'BBD', 'TH', '5-0'),
	  (2009, 3, '2009/03/01', 'TPY', 'GDT', 'TH', '0-2'),
	  (2009, 3, '2009/03/01', 'KKH', 'BBD', 'NT', '0-1'),
	  (2009, 4, '2009/03/07', 'KKH', 'TPY', 'NT', '1-0'),
	  (2009, 4, '2009/03/07', 'BBD', 'GDT', 'GD', '2-2');
GO

INSERT INTO HLV_CLB(MAHLV, MACLB, VAITRO)
VALUES('HLV01', 'BBD', N'HLV Chính'),
		('HLV02', 'SDN', N'HLV Chính'),
		('HLV03', 'HAGL', N'HLV Chính'),
		('HLV04', 'KKH', N'HLV Chính'),
		('HLV05', 'GDT', N'HLV Chính'),
		('HLV06', 'BBD', N'HLV thủ môn');
GO
  

/* e) 

Tạo stored procedure với yêu cầu cho biết mã số, họ tên, ngày sinh, địa chỉ và vị trí
của các cầu thủ thuộc đội bóng “SHB Đà Nẵng” và tên quốc tịch = “Brazil”, trong
đó tên đội bóng/câu lạc bộ và tên quốc tịch/quốc gia là 2 tham số của stored
procedure.
i) Tên stored procedure: SP_SEL_NO_ENCRYPT
ii) Danh sách tham số: @TenCLB, @TenQG

*/

CREATE PROCEDURE SP_SEL_NO_ENCRYPT @TenCLB NVARCHAR(100), @TenQG NVARCHAR(60)
AS 
select mact, hoten, ngaysinh, diachi, vitri 
from CAUTHU
where MACLB = (	select MACLB 
				from CAULACBO
				where TENCLB = @TenCLB)
				and MAQG = (select MAQG 
							from QUOCGIA
							where TENQG = @TenQG)
GO



/* f) 

Tạo stored procedure với yêu cầu như câu e, với nội dung stored được mã hóa.
i) Tên stored procedure: SP_SEL_ENCRYPT
ii) Danh sách tham số: @TenCLB, @TenQG

*/

--drop procedure SP_SEL_ENCRYPT
CREATE PROCEDURE SP_SEL_ENCRYPT @TenCLB NVARCHAR(100), @TenQG NVARCHAR(60)
WITH ENCRYPTION
AS

select mact, hoten, ngaysinh, diachi, vitri 
from CAUTHU
where MACLB = (	select MACLB 
				from CAULACBO
				where TENCLB = @TenCLB)
				and MAQG = (select MAQG 
							from QUOCGIA
							where TENQG = @TenQG)

GO





/* g) 

Thực thi 2 stored procedure trên với tham số truyền vào @TenCLB = “SHB Đà Nẵng” và
@TenQG = “Brazil”, xem kết quả và nhận xét

*/


EXEC SP_SEL_NO_ENCRYPT @TenCLB = N'SHB Đà Nẵng', @TenQG = N'Brazil';

EXEC SP_SEL_ENCRYPT @TenCLB = N'SHB Đà Nẵng', @TenQG = N'Brazil';


-- hai stored procedure trên đều trả về kết quả như nhau
-- Sự khác nhau là SP_SEL_ENCRYPT không thể xem được nội dung của stored đó với kết quả trả về:
--		"The text for object 'SP_SEL_ENCRYPT' is encrypted."


EXEC sp_helptext 'SP_SEL_NO_ENCRYPT'
go

EXEC sp_helptext 'SP_SEL_ENCRYPT'
go

/* h) 

Giả sử trong CSDL có 100 stored procedure, có cách nào để Encrypt toàn bộ 100 stored
procedure trước khi cài đặt cho khách hàng không? Nếu có, hãy mô tả các bước thực hiện

*/



--------------------------------------------------
--VIEW--
--------------------------------------------------

CREATE VIEW vCAU1 AS
SELECT MACT,HOTEN, DIACHI, VITRI, NGAYSINH 
FROM CAUTHU join CAULACBO on CAUTHU.MACLB=CAULACBO.MACLB
					join QUOCGIA on QUOCGIA.MAQG = CAUTHU.MAQG
WHERE QUOCGIA.TENQG='Brazil' and CAULACBO.TENCLB=N'SHB Đà Nẵng';



select * from vCAU1
drop view vCAU1

-----
CREATE VIEW vCAU2 as
SELECT MATRAN, NGAYTD, clb1.TENCLB as TENCLB1,clb2.TENCLB as TENCLB2, SANVD.TENSAN,TRANDAU.KETQUA
from TRANDAU join CAULACBO as clb1 on TRANDAU.MACLB1=clb1.MACLB
				join CAULACBO as clb2 on TRANDAU.MACLB2=clb2.MACLB
				join SANVD on TRANDAU.MASAN=SANVD.MASAN
where TRANDAU.NAM='2009' and TRANDAU.VONG='3' and clb1.TENCLB!=clb2.TENCLB
select * from vCAU2
drop view vCAU2



CREATE VIEW vCAU3 as
select HUANLUYENVIEN.MAHLV, HUANLUYENVIEN.TENHLV, NGAYSINH, HUANLUYENVIEN.DIACHI, CAULACBO.TENCLB
from HUANLUYENVIEN join HLV_CLB on HUANLUYENVIEN.MAHLV=HLV_CLB.MAHLV
							join CAULACBO on HLV_CLB.MACLB=CAULACBO.MACLB
								join QUOCGIA on HUANLUYENVIEN.MAQG=QUOCGIA.MAQG
where QUOCGIA.TENQG=N'Việt Nam'
select * from vCAU3

-----
CREATE VIEW vCAU4 as
select CAULACBO.MACLB, CAULACBO.TENCLB, SANVD.TENSAN, SANVD.DIACHI, COUNT(CAULACBO.MACLB) as SOCAUTHUNUOCNGOAI
from CAUTHU join CAULACBO on CAUTHU.MACLB=CAULACBO.MACLB
					join SANVD on CAULACBO.MASAN=SANVD.MASAN
							join QUOCGIA on CAUTHU.MAQG=QUOCGIA.MAQG
where QUOCGIA.TENQG!=N'Việt Nam'
group by CAULACBO.MACLB,CAULACBO.TENCLB, SANVD.TENSAN, SANVD.DIACHI
having COUNT(CAULACBO.MACLB)>2;
select * from vCAU4
drop view vCAU4

----
create view vCAU5 as 
select TINH.TENTINH, count(ct.VITRI) as SOLUONGCAUTHUTIENDAO
from TINH join CAULACBO clb on clb.MATINH=TINH.MATINH
					join CAUTHU ct on ct.MACLB=clb.MACLB
where ct.VITRI=N'Tiền Đạo'
group by TINH.TENTINH
select * from vCAU5
drop view vCAU5

----
create view vCAU6 as
select CAULACBO.TENCLB, TINH.TENTINH
from BANGXH join CAULACBO on BANGXH.MACLB=CAULACBO.MACLB
				join TINH on CAULACBO.MATINH= TINH.MATINH
where BANGXH.VONG='3' and BANGXH.HANG='1'
select * from vCAU6
drop view vCAU6
----
create view vCAU7 as
select hlv.TENHLV
from HUANLUYENVIEN hlv join HLV_CLB on hlv.MAHLV=HLV_CLB.MAHLV
where hlv.MAHLV in (select MAHLV from HLV_CLB) and hlv.DIENTHOAI=NULL
select * from vCAU7
drop view vCAU7
----
create view vCAU8 as
select hlv.TENHLV
from HUANLUYENVIEN hlv join HLV_CLB on hlv.MAHLV=HLV_CLB.MAHLV
							join QUOCGIA on hlv.MAQG=QUOCGIA.MAQG
where hlv.MAHLV not in (select MAHLV from HLV_CLB) and QUOCGIA.TENQG=N'Việt Nam';
select * from vCAU8
drop view vCAU8
----
create view vCAU9 as
select NGAYTD, TENSAN,clb1.TENCLB as TENCLB1,clb2.TENCLB as TENCLB2,KETQUA, BANGXH.VONG
from TRANDAU join CAULACBO as clb1 on TRANDAU.MACLB1=clb1.MACLB
				join CAULACBO as clb2 on TRANDAU.MACLB2=clb2.MACLB
					join BANGXH on clb1.MACLB=BANGXH.MACLB or clb2.MACLB=BANGXH.MACLB
						join SANVD on SANVD.MASAN=TRANDAU.MASAN
where TRANDAU.VONG<=3 and (clb1.MACLB=(select MACLB from BANGXH where HANG='1' and VONG='3') or clb2.MACLB=(select MACLB from BANGXH where HANG='1' and VONG='3'))
group by NGAYTD, TENSAN,clb1.TENCLB,clb2.TENCLB ,KETQUA, BANGXH.VONG
select * from vCAU9
drop view vCAU9
----
create view vCAU10 as
select NGAYTD, TENSAN,clb1.TENCLB as TENCLB1,clb2.TENCLB as TENCLB2,KETQUA, BANGXH.VONG
from TRANDAU join CAULACBO as clb1 on TRANDAU.MACLB1=clb1.MACLB
				join CAULACBO as clb2 on TRANDAU.MACLB2=clb2.MACLB
					join BANGXH on clb1.MACLB=BANGXH.MACLB or clb2.MACLB=BANGXH.MACLB
						join SANVD on SANVD.MASAN=TRANDAU.MASAN
where TRANDAU.VONG<3 and (clb1.MACLB=(select MACLB from BANGXH where VONG='3' and HANG='5') or clb2.MACLB=(select MACLB from BANGXH where VONG='3' and HANG='5'))
group by NGAYTD, TENSAN,clb1.TENCLB,clb2.TENCLB ,KETQUA, BANGXH.VONG

select * from vCAU10

drop view vCAU10




--------------------------------------------------
--PROCEDURE--
--------------------------------------------------

--drop procedure SPCau1
CREATE PROCEDURE SPCau1 @TenCLB NVARCHAR(100), @TenQG NVARCHAR(60)
AS 
select mact, hoten, ngaysinh, diachi, vitri 
from CAUTHU
where MACLB = (	select MACLB 
				from CAULACBO
				where TENCLB = @TenCLB)
				and MAQG = (select MAQG 
							from QUOCGIA
							where TENQG = @TenQG)
GO

EXEC SPCau1 @TenCLB = N'SHB Đà Nẵng', @TenQG = N'Brazil';
go


--drop procedure SPCau2
create procedure SPCau2 @Vong int, @nam int
as
SELECT MATRAN, NGAYTD, clb1.TENCLB as TENCLB1,clb2.TENCLB as TENCLB2, SANVD.TENSAN,TRANDAU.KETQUA
from TRANDAU join CAULACBO as clb1 on TRANDAU.MACLB1=clb1.MACLB
				join CAULACBO as clb2 on TRANDAU.MACLB2=clb2.MACLB
				join SANVD on TRANDAU.MASAN=SANVD.MASAN
where TRANDAU.NAM=@nam and TRANDAU.VONG=@vong and clb1.TENCLB!=clb2.TENCLB
go

Exec SPCAU2 @vong = '3', @nam = '2009'
go

--SPCau3
create procedure SPCau3 @TenQG NVARCHAR(60)
as
select HUANLUYENVIEN.MAHLV, HUANLUYENVIEN.TENHLV, NGAYSINH, HUANLUYENVIEN.DIACHI, CAULACBO.TENCLB
from HUANLUYENVIEN join HLV_CLB on HUANLUYENVIEN.MAHLV=HLV_CLB.MAHLV
							join CAULACBO on HLV_CLB.MACLB=CAULACBO.MACLB
								join QUOCGIA on HUANLUYENVIEN.MAQG=QUOCGIA.MAQG
where QUOCGIA.TENQG=@TenQG
go

exec spcau3 @tenqg = N'Việt Nam'
go


--SPCau4
CREATE procedure spCAU4  @TenQG NVARCHAR(60)
as
select CAULACBO.MACLB, CAULACBO.TENCLB, SANVD.TENSAN, SANVD.DIACHI, COUNT(CAULACBO.MACLB) as SOCAUTHUNUOCNGOAI
from CAUTHU join CAULACBO on CAUTHU.MACLB=CAULACBO.MACLB
					join SANVD on CAULACBO.MASAN=SANVD.MASAN
							join QUOCGIA on CAUTHU.MAQG=QUOCGIA.MAQG
where QUOCGIA.TENQG!=@TenQG
group by CAULACBO.MACLB,CAULACBO.TENCLB, SANVD.TENSAN, SANVD.DIACHI
having COUNT(CAULACBO.MACLB)>2;
go

exec spcau4 @tenqg  = N'Việt Nam'
go

--SPCau5
create procedure SPCAU5 @Vitri NVARCHAR(20) 
as 
select TINH.TENTINH, count(ct.VITRI) as SOLUONGCAUTHUTIENDAO
from TINH join CAULACBO clb on clb.MATINH=TINH.MATINH
					join CAUTHU ct on ct.MACLB=clb.MACLB
where ct.VITRI=@Vitri
group by TINH.TENTINH
go

exec spcau5 @vitri = N'Tiền Đạo'

--SPCau6
create procedure SPCAU6 @Vong int, @Hang int
as
select CAULACBO.TENCLB, TINH.TENTINH
from BANGXH join CAULACBO on BANGXH.MACLB=CAULACBO.MACLB
				join TINH on CAULACBO.MATINH= TINH.MATINH
where BANGXH.VONG=@Vong and BANGXH.HANG=@Hang
go

exec SPcau6 @vong = 3, @hang = 1

--SPCau7
create procedure SPCAU7 
as
select hlv.TENHLV
from HUANLUYENVIEN hlv join HLV_CLB on hlv.MAHLV=HLV_CLB.MAHLV
where hlv.MAHLV in (select MAHLV from HLV_CLB) and hlv.DIENTHOAI=NULL
go

exec spcau7

--SPCau8
create procedure SPCAU8 @TenQG nvarchar(60) 
as
select hlv.TENHLV
from HUANLUYENVIEN hlv join HLV_CLB on hlv.MAHLV=HLV_CLB.MAHLV
							join QUOCGIA on hlv.MAQG=QUOCGIA.MAQG
where hlv.MAHLV not in (select MAHLV from HLV_CLB) and QUOCGIA.TENQG=@TenQG;
go

exec spcau8  @tenqg = N'Việt Nam'
go

--SPCau9

create procedure SPCAU9 @vong int, @hang int
as
select NGAYTD, TENSAN,clb1.TENCLB as TENCLB1,clb2.TENCLB as TENCLB2,KETQUA, BANGXH.VONG
from TRANDAU join CAULACBO as clb1 on TRANDAU.MACLB1=clb1.MACLB
				join CAULACBO as clb2 on TRANDAU.MACLB2=clb2.MACLB
					join BANGXH on clb1.MACLB=BANGXH.MACLB or clb2.MACLB=BANGXH.MACLB
						join SANVD on SANVD.MASAN=TRANDAU.MASAN
where TRANDAU.VONG<=3 and (clb1.MACLB=(select MACLB from BANGXH where HANG=@hang and VONG=@vong) or clb2.MACLB=(select MACLB from BANGXH where HANG=@hang and VONG=@vong))
group by NGAYTD, TENSAN,clb1.TENCLB,clb2.TENCLB ,KETQUA, BANGXH.VONG
go

exec spcau9 @vong = '3' , @hang = '1'


--SPcau10 
create procedure SPCAU10 @vong int, @hang int
as
select NGAYTD, TENSAN,clb1.TENCLB as TENCLB1,clb2.TENCLB as TENCLB2,KETQUA, BANGXH.VONG
from TRANDAU join CAULACBO as clb1 on TRANDAU.MACLB1=clb1.MACLB
				join CAULACBO as clb2 on TRANDAU.MACLB2=clb2.MACLB
					join BANGXH on clb1.MACLB=BANGXH.MACLB or clb2.MACLB=BANGXH.MACLB
						join SANVD on SANVD.MASAN=TRANDAU.MASAN
where TRANDAU.VONG<3 and (clb1.MACLB=(select MACLB from BANGXH where VONG=@vong and HANG=@hang) or clb2.MACLB=(select MACLB from BANGXH where VONG=@vong and HANG=@hang))
group by NGAYTD, TENSAN,clb1.TENCLB,clb2.TENCLB ,KETQUA, BANGXH.VONG
go

exec spcau10 @vong = '3', @hang = '5'
go

--step1 create master key


--if there is no master key create one
IF NOT EXISTS
(
	SELECT *
	FROM sys.symmetric_keys
	WHERE symmetric_key_id = 101
)

CREATE MASTER KEY ENCRYPTION BY PASSWORD = '123456'

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

SELECT ENCRYPTBYKEY(KEY_GUID('PriKey'),3000000)
select convert(varchar,DECRYPTBYKEY(0x00E21A2D28E36E40B461D594E7934AAB0200000017AAF62E48E664E0D963F6EF23CED8A2A7CF052E0D859E3527851437D9546F0B))


SELECT CONVERT(VARCHAR, DECRYPTBYKEY(ENCRYPTBYKEY(KEY_GUID('PriKey'),'11111111111111')))

SELECT CONVERT(VARCHAR, DECRYPTBYKEY(ENCRYPTBYKEY(KEY_GUID('PriKey'),'545454')))

SELECT CONVERT(VARCHAR, 0x353435343534)

--SOME TEST DATABASE

/*
INSERT INTO DIEM (MASV, DIEMTHI, GHICHU)
SELECT 'SV01', 1, 'SINH VIEN 01'
UNION ALL
SELECT 'SV02', 2, 'SINH VIEN 02'
UNION ALL
SELECT 'SV03', 3, 'SINH VIEN 03'
*/

DECLARE @LUONG INT;



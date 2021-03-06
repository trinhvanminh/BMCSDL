
ALTER DATABASE QLSVNhom
SET COMPATIBILITY_LEVEL = 120



--MA HOA LUONG VOI ASYMMETRIC KEY--

DROP ASYMMETRIC KEY ASYMKEY


CREATE ASYMMETRIC KEY ASYMKEY   
    WITH ALGORITHM = RSA_512   
    ENCRYPTION BY PASSWORD = '123456';  
GO  


DECLARE @AsymID INT;
SET @AsymID = ASYMKEY_ID('ASYMKEY')


SELECT EncryptByAsymKey(@AsymID, convert(varbinary,123))

SELECT CONVERT(VARCHAR(20), DECRYPTBYASYMKEY(@AsymID,0x2B1BE736712C3BF4279C505D5898E7DEF44841D7D8E97096FB5509A2CCC23C81A00FCCA82B17E91044BBB15511EDE4F3F0BAB0371AD203449F022E29F7BCE881, N'123456'))

UPDATE NHANVIEN
SET lUONG_MH = EncryptByAsymKey(@AsymID, LUONGCB )


----

SELECT *, GIAIMA =  CONVERT(VARCHAR(20), DECRYPTBYASYMKEY(@AsymID, lUONG_MH, N'123456')
FROM NHANVIEN


--- TAO VA LUU PUBKEY CHO MOI NV---

CREATE ASYMMETRIC KEY @MANV   
    WITH ALGORITHM = RSA_512   
    ENCRYPTION BY PASSWORD = @MK;  
GO 

UPDATE NHANVIEN
SET PUBKEY = @MANV
WHERE MANV = @MANV

-- MA HOA DU LIEU --

UPDATE NHANVIEN
SET LUONGPUB = ENCRYPTBYASYMKEY(ASYMKEY_ID(PUBKEY), LUONGCB)


SELECT 
GIAIMA = CONVERT(VARCHAR(20), DECRYPTBYASYMKEY( ASYMKEY_ID(PUBKEY), LUONGPUB, N''+ PUBKEY)),
*
FROM NHANVIEN
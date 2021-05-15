
drop asymmetric key abc



create asymmetric key abc
with algorithm = RSA_512
encryption by password = '123'


update bangdiem set diemthi=convert(varbinary,'10') where masv = '1712601'

select 
*,
d=CONVERT(varchar,diemthi),
diem=ENCRYPTBYASYMKEY(ASYMKEY_ID('abc'),diemthi),
diem2=DECRYPTBYASYMKEY(ASYMKEY_ID('abc'), 
ENCRYPTBYASYMKEY(ASYMKEY_ID('abc'),diemthi), 
N'123') 
from bangdiem



select *
from BANGDIEM
where BANGDIEM.masv = '1712601'


select * from bangdiem
select * from hocphan
select * from lop
select * from nhanvien

select * from sinhvien

insert into bangdiem(MASV,MAHP,DIEMTHI)
values ('1712633','CTDL',convert(varbinary,'5.5'))



CREATE DATABASE DB_QLSV5
GO

USE DB_QLSV5
GO

CREATE TABLE TAIKHOAN
(
	MaTk CHAR(10) PRIMARY KEY,
	TaiKhoan VARCHAR(50) NOT NULL,
	MatKhau VARCHAR(50) NOT NULL,
	PhanLoai NVARCHAR(20) NOT NULL,
	NgayTruyCap DATETIME
)


INSERT INTO TAIKHOAN VALUES('TK11111112','33354741122871651676713774147412831195','3244185981728979115075721453575112','admin',NULL)
CREATE TABLE CHUONGTRINH
(
		MaChuongTrinh CHAR(5) PRIMARY KEY,
		TenChuongTrinh NVARCHAR(50) NOT NULL,
)
CREATE TABLE KHOAHOC
(
		MaKhoaHoc CHAR(5) PRIMARY KEY,
		TenKhoaHoc NVARCHAR(50) NOT NULL,
		NamBatDau Date NOT NULL,
		NamKetThuc Date NOT NULL,
		MaChuongTrinh CHAR(5),
		GhiChu NVARCHAR(100)
		FOREIGN KEY(MaChuongTrinh) REFERENCES CHUONGTRINH(MaChuongTrinh)
)
CREATE TABLE KHOA
(
	MaKhoa CHAR(5) PRIMARY KEY,
	TenKhoa NVARCHAR(50) NOT NULL UNIQUE,
	NamBatDau DATE,
	GhiChu NVARCHAR(100)
)
 GO

 CREATE TABLE NGANH
 (
 MaNganh CHAR(5) PRIMARY KEY,
 TenNganh NVARCHAR(50) NOT NULL UNIQUE,
 MaKhoa  CHAR(5) ,
 NamBatDau DATE,
 FOREIGN KEY(MaKhoa) REFERENCES KHOA(MaKhoa)
 )



CREATE TABLE LOP 
(
		MaLop CHAR(5) ,
		TenLop NVARCHAR(50) NOT NULL UNIQUE,
		MaKhoa CHAR(5),
		SoSV TINYINT,
		MaKhoaHoc CHAR(5)  UNIQUE,
		GhiChu NVARCHAR(50),
		PRIMARY KEY(MaLop,MaKhoaHoc),
		FOREIGN KEY(MaKhoa) REFERENCES KHOA(MaKhoa),
		FOREIGN KEY(MaKhoaHoc) REFERENCES KHOAHOC(MaKhoaHoc)
)
GO
CREATE TABLE MON
(
		MaMon CHAR(5) PRIMARY KEY,
		TenMon NVARCHAR(50) NOT NULL UNIQUE,		
		SoTiet TINYINT NOT NULL,
		SoTinChi TINYINT NOT NULL,
		MaKhoa CHAR(5),
		FOREIGN KEY(MaKhoa) REFERENCES KHOA(MaKhoa)
)


CREATE TABLE GIAOVIEN
(
	MaGV CHAR(5) PRIMARY KEY,
	AnhDaiDien IMAGE,
	CMND CHAR(12) UNIQUE,
	TenGV NVARCHAR(50) NOT NULL,
	NgaySinh DATE,
	GioiTinh BIT NOT NULL,
	SDT VARCHAR(10) UNIQUE,
	DiaChi NVARCHAR(50),
	QueQuan NVARCHAR(50) NOT NULL,
	DanToc NVARCHAR(10),
	TonGiao NVARCHAR(10),
	NgayVaoTruong DATE,
	Loai NVARCHAR(20),
	SoNamCongTac DATE,
	MaKhoa CHAR(5),
	MaTk CHAR(10),
	GhiChu NVARCHAR(50),
	FOREIGN KEY(MaTk) REFERENCES TAIKHOAN(MaTk),
	FOREIGN KEY(MaKhoa) REFERENCES KHOA(MaKhoa)

)

CREATE TABLE SINHVIEN
(
	MaSV CHAR(10) PRIMARY KEY,
	AnhDaiDien IMAGE,
	CMND CHAR(12) UNIQUE,
	TenSV NVARCHAR(50) NOT NULL,
	NgaySinh DATE NOT NULL,
	GioiTinh BIT NOT NULL,
	DanToc NVARCHAR(10),
	TonGiao NVARCHAR(10),
	DiaChi NVARCHAR(50),
	QueQuan NVARCHAR(50),
	SDT VARCHAR(10) UNIQUE,
	NgayNhapHoc DATE,
	MaKhoaHoc CHAR(5),
	MaLop CHAR(5),
	MaTk CHAR(10),
	GhiChu NVARCHAR(50),
	FOREIGN KEY(MaLop,MaKhoaHoc) REFERENCES LOP(MaLop,MaKhoaHoc),
	FOREIGN KEY(MaTk) REFERENCES TAIKHOAN(MaTk)
)

CREATE TABLE LICHDAY
(
	MaGV CHAR(5) ,
	MaLop CHAR(5) ,
	MaMon CHAR(5) ,
	MaKhoaHoc CHAR(5),
	NgayDay DATE,
	SoTietDay TINYINT,
	CaDay BIT,
	Phong NVARCHAR(20) NOT NULL,
	GhiChu NVARCHAR(50),
	PRIMARY KEY(MaGV,MaLop,MaMon,NgayDay),
	FOREIGN KEY(MaMon) REFERENCES MON(MaMon),
	FOREIGN KEY(MaLop,MaKhoaHoc) REFERENCES LOP(MaLop,MaKhoaHoc),
	FOREIGN KEY(MaGV) REFERENCES GIAOVIEN(MaGV)
)




CREATE TABLE DIEM
(
	MaSV CHAR(10),
	MaMon CHAR(5),
	DiemTX1 FLOAT  DEFAULT 0,
	DiemTX2 FLOAT  DEFAULT 0,
	DiemKT1 FLOAT DEFAULT 0,
	DiemKT2 FLOAT DEFAULT 0,
	DiemThi FLOAT DEFAULT 0,
	LanThi TINYINT, 
	DiemTB FLOAT  DEFAULT 0,
	TrangThai NVARCHAR(20) ,
	GhiChu NVARCHAR(50),
	PRIMARY KEY(MaSV,MaMon),
	FOREIGN KEY(MaSV) REFERENCES SINHVIEN(MaSV),
	FOREIGN KEY(MaMon) REFERENCES MON(MaMon)

)
CREATE TABLE PHANCONG
(
	MaGV CHAR(5),
	MaLop CHAR(5) ,
	MaMon CHAR(5) ,
	MaKhoaHoc CHAR(5),
	ViTri NVARCHAR(20) NOT NULL,
	HocKi TINYINT NOT NULL,
	NamHoc DATE NOT NULL,
	GhiChu NVARCHAR(50),
	PRIMARY KEY(MaGV,MaLop,MaMon),
	FOREIGN KEY(MaMon) REFERENCES MON(MaMon),
	FOREIGN KEY(MaLop,MaKhoaHoc) REFERENCES LOP(MaLop,MaKhoaHoc),
	FOREIGN KEY(MaGV) REFERENCES GIAOVIEN(MaGV)
)

CREATE TABLE DIEMDANH
(
	MaSV CHAR(10) NOT NULL,
    NgayDiemDanh DATETIME NOT NULL,
    DiemDanh BIT NOT NULL,
	GhiChu NVARCHAR(50),
	PRIMARY KEY(MaSV,NgayDiemDanh),
	FOREIGN KEY(MaSV) REFERENCES SINHVIEN(MaSV),
)
--CREATE TABLE CHAMCONG
--(
--	MaGV CHAR(10) NOT NULL,
--    NgayDiemDanh DATETIME NOT NULL,
--    DiemDanh BIT NOT NULL,
--	GhiChu NVARCHAR(50),
--	PRIMARY KEY(MaGV,NgayDiemDanh),
--	FOREIGN KEY(MaGV) REFERENCES GIAOVIEN(MaGV),
--)
--CREATE TABLE HOCPHI
--(
--MaSV VARCHAR(20) NOT NULL,
--HocKi BIT,
--NamHoc DATE,
--TienHocCoBan money,
--TienGiamHocPhi money,
--TienChinhThuc money,
--TrangThai BIT NOT NULL,
--GhiChu NVARCHAR(50),
--PRIMARY KEY(MaSV,HocKi,NamHoc)
--)

--CREATE TABLE LUONGGIAOVIEN
--(
--MaGV CHAR(10) NOT NULL,
--LuongCoBan MONEY,
--HeSoLuong TINYINT,
--MucThuongPhuCap MONEY,
--MucThuongThamNien MONEY,
--MucBHXH TINYINT,
--LuongChinhThuc MONEY
--PRIMARY KEY (MaGV,LuongChinhThuc),
--FOREIGN KEY(MaGV) REFERENCES GIAOVIEN(MaGV)
--)
CREATE INDEX LOP_INDEX
ON LOP(MaKhoa,MaLop)
GO

CREATE INDEX SINHVIEN_INDEX
ON SINHVIEN(MaSV,MaLop)
GO

CREATE INDEX GIAOVIEN_INDEX
ON GIAOVIEN(QueQuan,MaGV)
GO
CREATE INDEX DIEM_INDEX
ON DIEM(MaMon,MaSV)
GO
CREATE PROCEDURE REMOVEKHOA(@MaKhoa CHAR(10))
AS
BEGIN
UPDATE NGANH SET MaKhoa= NULL WHERE MaKhoa= @MaKhoa
UPDATE MON SET MaKhoa= NULL WHERE MaKhoa= @MaKhoa
UPDATE GIAOVIEN SET MaKhoa= NULL WHERE MaKhoa= @MaKhoa
UPDATE LOP SET MaKhoa= NULL WHERE MaKhoa= @MaKhoa
DELETE FROM KHOA WHERE MaKhoa= @MaKhoa
END
GO

CREATE SEQUENCE SE_MAKHOA
START WITH 100
INCREMENT BY 1
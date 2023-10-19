CREATE DATABASE QLSV_NHOM6
GO

USE QLSV_NHOM6
GO
CREATE TABLE TAIKHOAN
(
	MaTk VARCHAR(20) PRIMARY KEY,
	TaiKhoan VARCHAR(20) NOT NULL UNIQUE,
	MatKhau VARCHAR(8) NOT NULL UNIQUE,
	PhanLoai NVARCHAR(20) NOT NULL
)
CREATE TABLE KHOA
(
	MaKhoa VARCHAR(20) PRIMARY KEY,
	TenKhoa NVARCHAR(50) NOT NULL UNIQUE
)
 GO
CREATE TABLE LOP 
(
		MaLop VARCHAR(20) PRIMARY KEY,
		TenLop NVARCHAR(50) NOT NULL UNIQUE,
		MaKhoa VARCHAR(20) NOT NULL,
		SoSV TINYINT,
		Khoa NVARCHAR(50) NOT NULL UNIQUE,
		FOREIGN KEY(MaKhoa) REFERENCES KHOA(MaKhoa)
)
GO

CREATE TABLE SINHVIEN
(
	MaSV VARCHAR(20) PRIMARY KEY,
	TenSV NVARCHAR(50) NOT NULL,
	NgaySinh DATE NOT NULL,
	GioiTinh BIT NOT NULL,
	DiaChi NVARCHAR(50),
	QueQuan NVARCHAR(50),
	SDT VARCHAR(10) UNIQUE,
	MaLop VARCHAR(20) NOT NULL,
	MaTk VARCHAR(20) NOT NULL,
	FOREIGN KEY(MaLop) REFERENCES LOP(MaLop),
	FOREIGN KEY(MaTk) REFERENCES TAIKHOAN(MaTk)
)

CREATE TABLE GIAOVIEN
(
	MaGV VARCHAR(20) PRIMARY KEY,
	TenGV NVARCHAR(50) NOT NULL,
	NgaySinh DATE,
	GioiTinh BIT NOT NULL,
	SDT VARCHAR(10) UNIQUE,
	DiaChi NVARCHAR(50),
	QueQuan NVARCHAR(50) NOT NULL,
	MaKhoa VARCHAR(20) NOT NULL,
	MaTk VARCHAR(20) NOT NULL,
	FOREIGN KEY(MaTk) REFERENCES TAIKHOAN(MaTk),
	FOREIGN KEY(MaKhoa) REFERENCES KHOA(MaKhoa)

)
CREATE TABLE MON
(
		MaMon VARCHAR(20) PRIMARY KEY,
		TenMon NVARCHAR(50) NOT NULL UNIQUE,		
		SoTiet TINYINT NOT NULL		
)
CREATE TABLE DIEM
(
	MaSV VARCHAR(20) NOT NULL,
	MaMon VARCHAR(20) NOT NULL,
	DiemTX FLOAT DEFAULT 0,
	DiemKT1 FLOAT DEFAULT 0,
	DiemKT2 FLOAT DEFAULT 0,
	DiemThi FLOAT DEFAULT 0,
	DiemTB FLOAT  DEFAULT 0,
	TrangThai NVARCHAR(20) NOT NULL,
	GhiChu NVARCHAR(50),
	PRIMARY KEY(MaSV,MaMon),
	FOREIGN KEY(MaSV) REFERENCES SINHVIEN(MaSV),
	FOREIGN KEY(MaMon) REFERENCES MON(MaMon)

)
CREATE TABLE PHANCONG
(
	MaGV VARCHAR(20),
	MaLop VARCHAR(20),
	MaMon VARCHAR(20),
	HocKi TINYINT NOT NULL,
	NamHoc DATE NOT NULL,
	PRIMARY KEY(MaGV,MaLop,MaMon),
	FOREIGN KEY(MaMon) REFERENCES MON(MaMon),
	FOREIGN KEY(MaLop) REFERENCES LOP(MaLop),
	FOREIGN KEY(MaGV) REFERENCES GIAOVIEN(MaGV)
)
CREATE INDEX KHOA_INDEX
ON KHOA(MaKhoa)
GO

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
using System;
using AlphaChiTech.Virtualization;
using Libary_ConnectDB;
namespace AdminModule.Models
{
    public class SinhVienSource : IPagedSourceProvider<SinhVien>
    {
        private IConnectDB connectDB;
        public SinhVienSource(IConnectDB connectDB)
        {
            this.connectDB = connectDB;
        }
        public int Count => connectDB.CountRecord("SELECT COUNT(*) FROM SINHVIEN");

        public  PagedSourceItemsPacket<SinhVien> GetItemsAt(int pageoffset, int count, bool usePlaceholder)
        {
            
            return new PagedSourceItemsPacket<SinhVien>() { LoadedAt = DateTime.Now, Items=connectDB.GetData<SinhVien>($"SELECT ROW_NUMBER() OVER( ORDER BY MaSV) AS STT,MaSV,AnhDaiDien,CMND,TenSV,NgaySinh,GioiTinh,DanToc,TonGiao,DiaChi,QueQuan,SDT,NgayNhapHoc,SINHVIEN.MaLop,LOP.TenLop,SINHVIEN.GhiChu FROM SINHVIEN LEFT JOIN LOP ON SINHVIEN.MaLop=LOP.MaLop ORDER BY MaSV OFFSET {pageoffset} ROWS FETCH NEXT 100 ROWS ONLY") };
        }

        public int IndexOf(SinhVien item)
        {
            return -1;
        }

        public void OnReset(int count)
        {
           
        }
    }
}

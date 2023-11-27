using System;
using System.Collections.Generic;
using Resource;
using Libary_ConnectDB;
using System.Threading.Tasks;

namespace AdminModule.Models
{
    public class SinhVienProvider : IItemsProvider<SinhVien>
    {
        private int _count;
        private IConnectDB connectDB;
        private string dk="";
        public int FetchCount()
        {
            return _count;
        }
        public SinhVienProvider(IConnectDB connectDB)
        {
            this.connectDB = connectDB;
            _count = connectDB.CountRecord("SELECT COUNT(*) FROM SINHVIEN");
        }
        public IList<SinhVien> FetchRange(int startIndex, int pageCount, out int overallCount)
        {
          overallCount = _count;
          return connectDB.GetData<SinhVien>($"SELECT MaSV,AnhDaiDien,CMND,TenSV,NgaySinh,GioiTinh,DanToc,TonGiao,DiaChi,QueQuan,SDT,NgayNhapHoc,SINHVIEN.MaLop,LOP.TenLop,SINHVIEN.GhiChu FROM SINHVIEN LEFT JOIN LOP ON SINHVIEN.MaLop=LOP.MaLop ORDER BY MaSV OFFSET {startIndex} ROWS FETCH NEXT 100 ROWS ONLY {dk}");
        }
        public void Insert() 
        { 
        }
        public void Remove() 
        { 
        
        }
        public void UpdateDk(string dk)
        {
            this.dk = dk;
        }
    }
}

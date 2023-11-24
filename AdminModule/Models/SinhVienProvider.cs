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
          return connectDB.GetData<SinhVien>($"SELECT * FROM SINHVIEN ORDER BY MaSV OFFSET {startIndex} ROWS FETCH NEXT 100 ROWS ONLY; ");
        }
        public void Insert() { }
        public void Remove() { }
    }
}

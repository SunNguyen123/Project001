using System;
using Resource;
namespace AdminModule.Models
{
   public class Lop:BaseModel
    {
        private string _stt;

        public string STT
        {
            get { return _stt; }
            set { _stt = value; }
        }

        private string _maLop;

        public string MaLop
        {
            get { return _maLop; }
            set { _maLop = value; }
        }
        private string _tenLop;

        public string TenLop
        {
            get { return _tenLop; }
            set { _tenLop = value; }
        }

        private string _maKhoaHoc;

        public string  MaKhoaHoc
        {
            get { return _maKhoaHoc; }
            set { _maKhoaHoc = value; }
        }

        private string _tenKhoaHoc;

        public string TenKhoaHoc
        {
            get { return _tenKhoaHoc; }
            set { _tenKhoaHoc = value; }
        }
        private string _maNganh;

        public string MaNganh
        {
            get { return _maNganh; }
            set { _maNganh = value; }
        }
        private string _tenNganh;

        public string TenNganh
        {
            get { return _tenNganh; }
            set { _tenNganh = value; }
        }
        private string _ghiChu;

        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }

    }
}

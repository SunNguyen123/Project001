using System;

namespace AdminModule.Models
{
  public  class KhoaHoc

    {
        private string _stt;

        public string STT
        {
            get { return _stt; }
            set { _stt = value; }
        }

        private string _maKhoaHoc;

        public string MaKhoaHoc
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
        private DateTime _namBatDau;    

        public DateTime NamBatDau
        {
            get { return _namBatDau; }
            set { _namBatDau = value; }
        }

        private DateTime _namKetThuc;

        public DateTime NamKetThuc
        {
            get { return _namKetThuc; }
            set { _namKetThuc = value; }
        }

        private string _maCT;

        public string MaCT
        {
            get { return _maCT; }
            set { _maCT = value; }
        }
        private string _tenCT;

        public string TenCT
        {
            get { return _tenCT; }
            set { _tenCT = value; }
        }
        private string _ghiChu;

        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }

    }
}

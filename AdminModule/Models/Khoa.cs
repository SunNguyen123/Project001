using System;

namespace AdminModule.Models
{
  public  class Khoa
    {

        private int _stt;

        public int STT
        {
            get { return _stt; }
            set { _stt = value; }
        }


        private string _maKhoa;

        public string MaKhoa
        {
            get 
            { 
                return _maKhoa; 
            }
            set 
            { 
                _maKhoa = value; 
            }
        }

        private string _tenKhoa;

        public string TenKhoa
        {
            get { return _tenKhoa; }
            set { _tenKhoa = value; }
        }
        private DateTime _nambatdau;

        public DateTime NamBatDau
        {
            get { return _nambatdau; }
            set { _nambatdau = value; }
        }
        private string _ghichu;

        public string GhiChu
        {
            get { return _ghichu; }
            set { _ghichu = value; }
        }

    }
}

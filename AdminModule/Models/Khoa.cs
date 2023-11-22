using System;
using Prism.Mvvm;
namespace AdminModule.Models
{
  public  class Khoa:BindableBase
    {

        private int _stt;

        public int STT
        {
            get { return _stt; }
            set { SetProperty<int>(ref _stt,value); }
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
                SetProperty(ref _maKhoa, value);
            }
        }

        private string _tenKhoa;

        public string TenKhoa
        {
            get { return _tenKhoa; }
            set
            {
                SetProperty(ref _tenKhoa, value);
            }
        }
        private DateTime _nambatdau;

        public DateTime NamBatDau
        {
            get { return _nambatdau; }
            set { SetProperty<DateTime>(ref _nambatdau, value); }
        }
        private string _ghichu;

        public string GhiChu
        {
            get { return _ghichu; }
            set { SetProperty(ref _ghichu, value); }
        }

    }
}

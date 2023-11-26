using System;
using Resource;
namespace AdminModule.Models
{
   public class Nganh:BaseModel
    {
        private int _stt;

        public int STT
        {
            get { return _stt; }
            set { SetProperty<int>(ref _stt, value); }
        }


        private string _maNganh;

        public string MaNganh
        {
            get
            {
                return _maNganh;
            }
            set
            {
                SetProperty(ref _maNganh, value);
            }
        }


        private string _tenNganh;

        public string TenNganh
        {
            get
            {
                return _tenNganh;
            }
            set
            {
                SetProperty(ref _tenNganh, value);
            }
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
            get
            {
                return _tenKhoa;
            }
            set
            {
                SetProperty(ref _tenKhoa, value);
            }
        }

        private DateTime _nambatdau;

        public DateTime NamBatDau
        {
            get
            {
                return _nambatdau;
            }
            set
            {

                SetProperty<DateTime>(ref _nambatdau, value);
            }
        }
    }
}

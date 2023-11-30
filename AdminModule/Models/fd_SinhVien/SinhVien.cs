using System;
using Prism.Mvvm;
using Resource;
namespace AdminModule.Models
{
   public class SinhVien:BaseModel
    {
        private string _stt;

        public string STT
        {
            get { return _stt; }
            set { _stt = value; }
        }

        private string _maSV;

        public string MaSV
        {
            get 
            { 
                return _maSV;
            }
            set { _maSV = value; }
        }
        private byte[] _anhDaiDien;

        public byte[] AnhDaiDien
        {
            get { return _anhDaiDien; }
            set { _anhDaiDien = value; }
        }

        private string _cmnd;

        public string CMND
        {
            get { return _cmnd; }
            set { SetProperty(ref _cmnd, value); }
        }
        private string _tenSV;

        public string TenSV
        {
            get { return _tenSV; }
            set 
            
            {

                SetProperty(ref _tenSV,value);
                
            
            }
        }
        private DateTime _ngaySinh;

        public DateTime NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }

        private bool _gt;

        public bool GioiTinh
        {
            get { return _gt; }
            set { _gt = value; }
        }
        private string _danToc;

        public string DanToc
        {
            get { return _danToc; }
            set { _danToc = value; }
        }
        private string _tonGiao;

        public string TonGiao
        {
            get { return _tonGiao; }
            set { _tonGiao = value; }
        }
        private string _diaChi;

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        private string _queQuan;

        public string QueQuan
        {
            get { return _queQuan; }
            set { _queQuan = value; }
        }
        private string sdt;

        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }
        private DateTime _ngayNhapHoc;  

        public DateTime NgayNhapHoc
        {
            get { return _ngayNhapHoc; }
            set { _ngayNhapHoc = value; }
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
        private string _ghiChu;

        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }

    }
}

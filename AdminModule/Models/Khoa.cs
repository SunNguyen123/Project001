﻿using System;
using Prism.Mvvm;
using System.Threading.Tasks;

namespace AdminModule.Models
{
  public  class Khoa
    {
        private string _maKhoa;

        public string MaKhoa
        {
            get { return _maKhoa; }
            set { _maKhoa = value; }
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
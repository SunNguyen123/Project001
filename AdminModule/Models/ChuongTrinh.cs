using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModule.Models
{
   public class ChuongTrinh
    {
        private string _stt;

        public string STT
        {
            get { return _stt; }
            set { _stt = value; }
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
    }
}

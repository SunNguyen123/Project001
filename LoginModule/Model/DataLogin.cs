using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginModule.Model
{
    public struct DataLogin
    {
        private string matk;

        public string MaTk
        {
            get { return matk; }
            set { matk = value; }
        }
        private string phanquyen;
            
        public string PhanQuyen
        {
            get { return phanquyen; }
            set { phanquyen = value; }
        }


    }
}

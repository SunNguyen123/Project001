using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libary_ConnectDB
{
   public interface IConnectDB
    {
        string Key { set;}
        void Execute(string query);
        IList<T> GetData<T>(string query);
    }
}

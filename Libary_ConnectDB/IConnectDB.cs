using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libary_ConnectDB
{
   public interface IConnectDB
    {
        void ConfigDB(string svname,string dbname);
        Task Execute(string query);
        Task<ObservableCollection<T>> GetData<T>(string query);
        Task<int> CountRecord(string query);
    }
}

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
        Task ExecuteAsync(string query);
        Task<ObservableCollection<T>> GetDataAsync<T>(string query);
        Task<int> CountRecordAsync(string query);
        void Execute(string query);
        IList<T> GetData<T>(string query);
        int CountRecord(string query);
        Task ExecuteSV(bool l,params object[] p);
    }
}

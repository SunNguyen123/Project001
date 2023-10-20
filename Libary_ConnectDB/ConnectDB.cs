using System;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
namespace Libary_ConnectDB
{
    public class ConnectDB : IConnectDB
    {
        public ConnectDB()
        {
            connection = new SqlConnection(SettingFile.Default.KeyDB);
        }
        private SqlConnection connection;
        public string Key {
            set            
            {                 
                SettingFile.Default.KeyDB = value;
                SettingFile.Default.Save();
                UpdateKey();
            } }

        private void UpdateKey() 
        {
            connection = new SqlConnection(SettingFile.Default.KeyDB);
        }
        public void Execute(string query)
        {

            connection.Query(query);                  
        }

        public IList<T> GetData<T>(string query)
        {
            IList<T> list = null;


                list = new ObservableCollection<T>(connection.Query<T>(query).AsList());            
            return list;
        }
    }
}

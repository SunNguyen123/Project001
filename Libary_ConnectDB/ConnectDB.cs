using System;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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
        public async Task Execute(string query)
        {
          await connection.QueryAsync(query);                  
        }

        public async Task<ObservableCollection<T>> GetData<T>(string query)
        {
            ObservableCollection<T> list = null;
            try 
            {
                list = new ObservableCollection<T>( await connection.QueryAsync<T>(query));
            }
            catch 
            { 
            
            }
            
            return list;
        }
    }
}

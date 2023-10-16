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

        }
        private SqlConnection connection;
        public string Key {
            set            
            {                 
                SettingFile.Default.KeyDB = value;
                SettingFile.Default.Save();
            } }

        public void Execute(string query)
        { 
            using (connection=new SqlConnection(SettingFile.Default.KeyDB)) 
                {
                    connection.Query(query);
                }
      
        }

        public IList<T> GetData<T>(string query)
        {
            IList<T> list = null;

            using (connection = new SqlConnection(SettingFile.Default.KeyDB))
            {
                list = new ObservableCollection<T>(connection.Query<T>(query).AsList());
            }


            return list;
        }
    }
}

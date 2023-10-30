using System;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Services.Dialogs;
namespace Libary_ConnectDB
{
    public class ConnectDB : IConnectDB
    {
        private IDialogService dialogService;
        public ConnectDB(IDialogService dialogService)
        {
            connection = new SqlConnection(SettingFile.Default.KeyDB);
            this.dialogService = dialogService;
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
            try 
            { 
            await connection.QueryAsync(query);                  
            
            }
            catch 
            {
                var ts1 = new DialogParameters();
                ts1.Add("message1", "Lỗi kết nối tới cơ sở dữ liệu");
                ts1.Add("message2", "Vui lòng thử lại sau !");


                dialogService.ShowDialog("DialogMessageTextView", ts1, (r) =>
                {


                });
            }
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
                var ts1 = new DialogParameters();
                ts1.Add("message1", "Lỗi kết nối tới cơ sở dữ liệu");
                ts1.Add("message2", "Vui lòng thử lại sau !");


                dialogService.ShowDialog("DialogMessageTextView", ts1, (r) =>
                {
  

                });
            }
            
            return list;
        }
    }
}

using System;
using Dapper;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Services.Dialogs;
using System.Diagnostics;

namespace Libary_ConnectDB
{
    public class ConnectDB : IConnectDB
    {
        private IDialogService dialogService;
        public ConnectDB(IDialogService dialogService)
        {
            
            this.dialogService = dialogService;
            CreateConnection();
        }
        private SqlConnection connection;

       public void ConfigDB(string svname, string dbname) 
        {

            SettingFile.Default.NameServer = svname;
            SettingFile.Default.NameDatabase = dbname;
            SettingFile.Default.Save();
        }
        private void CreateConnection() 
        {

            var key = new SqlConnectionStringBuilder();
            key.DataSource = SettingFile.Default.NameServer;
            key.InitialCatalog = SettingFile.Default.NameDatabase;
            key.MultipleActiveResultSets = true;
            key.IntegratedSecurity = true;
            connection = new SqlConnection(key.ConnectionString);
        }
        public async Task Execute(string query)
        {
            try 
            {
                if (connection.State == System.Data.ConnectionState.Closed) await connection.OpenAsync();

                await connection.QueryAsync(query);
                connection.Close();
            }
            catch(Exception e) 
            {
               
                var ts1 = new DialogParameters();
                ts1.Add("message1", $"Lỗi kết nối tới cơ sở dữ liệu {e.Message}");
                ts1.Add("message2", $"Vui lòng thử lại sau !");
                dialogService.ShowDialog("DialogMessageTextView", ts1, (r) =>
                {
                    Process.Start(Process.GetCurrentProcess().MainModule.FileName);
                    System.Windows.Application.Current.Shutdown();

                });
                connection.Close();

            }

        }

        public async Task<ObservableCollection<T>> GetData<T>(string query)
        {
            ObservableCollection<T> list = null;
            try 
            {
                if (connection.State == System.Data.ConnectionState.Closed) await connection.OpenAsync();
                list = new ObservableCollection<T>( await connection.QueryAsync<T>(query));
                connection.Close();

            }
            catch (Exception e)
            {
              
                var ts1 = new DialogParameters();
                ts1.Add("message1", $"Lỗi kết nối tới cơ sở dữ liệu {e.Message}");
                ts1.Add("message2", $"Vui lòng thử lại sau !");

                dialogService.ShowDialog("DialogMessageTextView", ts1, (r) =>
                {
                    Process.Start(Process.GetCurrentProcess().MainModule.FileName);
                    System.Windows.Application.Current.Shutdown();

                });
                connection.Close();

            }


            return list;
        }


        public async Task<int> CountRecord(string query) 
        {

            int count = 0;
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed) await connection.OpenAsync();

                count = await connection.ExecuteScalarAsync<int>(query);
                connection.Close();

            }
            catch (Exception e)
            {
              
                var ts1 = new DialogParameters();
                ts1.Add("message1", $"Lỗi kết nối tới cơ sở dữ liệu {e.Message}");
                ts1.Add("message2", $"Vui lòng thử lại sau !");

                dialogService.ShowDialog("DialogMessageTextView", ts1, (r) =>
                {


                });
                connection.Close();

            }


            return count;
        }
    }
}

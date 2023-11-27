using System;
using Dapper;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Services.Dialogs;
using System.Diagnostics;
using System.Collections.Generic;

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

       public  void ConfigDB(string svname, string dbname) 
        {

            SettingFile.Default.NameServer = svname;
            SettingFile.Default.NameDatabase = dbname;
            SettingFile.Default.Save();
            CreateConnection();
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
        public async Task ExecuteAsync(string query)
        {
            try 
            {

                if (connection.State != System.Data.ConnectionState.Open) await connection.OpenAsync();
                await connection.QueryAsync(query);
                
            }
            catch(Exception e) 
            {
               
                var ts1 = new DialogParameters();
                ts1.Add("message1", $"Lỗi kết nối tới cơ sở dữ liệu : ({e.Message})");
                ts1.Add("message2", $"Vui lòng thử lại sau !");
                dialogService.ShowDialog("DialogWindowView", ts1, (r) =>
                {
 

                });
              

            }

        }
       public async Task ExecuteImg(params object[] p)
        {
            string s = "EXEC INSERTSV @img,@CMND,@TenSV,@NgaySinh,@GioiTinh,@DanToc,@TonGiao,@DiaChi,@QueQuan,@SDT,@NgayNhapHoc,@MaLop,@GhiChu";

            if (connection.State != System.Data.ConnectionState.Open) await connection.OpenAsync();
            SqlCommand command = new SqlCommand(s,connection);
            command.Parameters.AddWithValue("@img",(byte[])p[0]);
            command.Parameters.AddWithValue("@CMND",p[1].ToString());
            command.Parameters.AddWithValue("@TenSV",p[2].ToString());
            command.Parameters.AddWithValue("@NgaySinh", p[3].ToString());
            command.Parameters.AddWithValue("@GioiTinh", (bool)p[4]);
            command.Parameters.AddWithValue("@DanToc", p[5].ToString());
            command.Parameters.AddWithValue("@TonGiao", p[6].ToString());
            command.Parameters.AddWithValue("@DiaChi", p[7].ToString());
            command.Parameters.AddWithValue("@QueQuan", p[8].ToString());
            command.Parameters.AddWithValue("@SDT", p[9].ToString());
            command.Parameters.AddWithValue("@NgayNhapHoc", p[10].ToString());
            command.Parameters.AddWithValue("@MaLop", p[11].ToString());
            command.Parameters.AddWithValue("@GhiChu", p[12].ToString());
            command.ExecuteNonQuery();

        }
        public async Task<ObservableCollection<T>> GetDataAsync<T>(string query)
        {
            ObservableCollection<T> list = null;
            try 
            {
                if (connection.State != System.Data.ConnectionState.Open) await connection.OpenAsync();
                list = new ObservableCollection<T>( await connection.QueryAsync<T>(query));
              

            }
            catch (Exception e)
            {
              
                var ts1 = new DialogParameters();
                ts1.Add("message1", $"Lỗi kết nối tới cơ sở dữ liệu :({e.Message})");
                ts1.Add("message2", $"Vui lòng thử lại sau !");

                dialogService.ShowDialog("DialogWindowView", ts1, (r) =>
                {
            

                });
             

            }


            return list;
        }


        public async Task<int> CountRecordAsync(string query) 
        {

            int count = 0;
            try
            {

                if (connection.State != System.Data.ConnectionState.Open) await connection.OpenAsync();
                count = await connection.ExecuteScalarAsync<int>(query);
                

            }
            catch (Exception e)
            {
              
                var ts1 = new DialogParameters();
                ts1.Add("message1", $"Lỗi kết nối tới cơ sở dữ liệu :({e.Message})");
                ts1.Add("message2", $"Vui lòng thử lại sau !");

                dialogService.ShowDialog("DialogWindowView", ts1, (r) =>
                {


                });
                

            }


            return count;
        }

        public void Execute(string query)
        {
            try
            {

                if (connection.State != System.Data.ConnectionState.Open) connection.OpenAsync();
                connection.Query(query);

            }
            catch (Exception e)
            {

                var ts1 = new DialogParameters();
                ts1.Add("message1", $"Lỗi kết nối tới cơ sở dữ liệu : ({e.Message})");
                ts1.Add("message2", $"Vui lòng thử lại sau !");
                dialogService.ShowDialog("DialogWindowView", ts1, (r) =>
                {


                });


            }
        }

        public IList<T> GetData<T>(string query)
        {
            List<T> list = null;
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)  connection.Open();
                list = new List<T>(connection.Query<T>(query));


            }
            catch (Exception e)
            {

                var ts1 = new DialogParameters();
                ts1.Add("message1", $"Lỗi kết nối tới cơ sở dữ liệu :({e.Message})");
                ts1.Add("message2", $"Vui lòng thử lại sau !");

                dialogService.ShowDialog("DialogWindowView", ts1, (r) =>
                {


                });


            }


            return list;
        }

        public int CountRecord(string query)
        {
            int count = 0;
            try
            {

                if (connection.State != System.Data.ConnectionState.Open) connection.Open();
                count = connection.ExecuteScalar<int>(query);


            }
            catch (Exception e)
            {

                var ts1 = new DialogParameters();
                ts1.Add("message1", $"Lỗi kết nối tới cơ sở dữ liệu :({e.Message})");
                ts1.Add("message2", $"Vui lòng thử lại sau !");

                dialogService.ShowDialog("DialogWindowView", ts1, (r) =>
                {


                });


            }


            return count;
        }
    }
}

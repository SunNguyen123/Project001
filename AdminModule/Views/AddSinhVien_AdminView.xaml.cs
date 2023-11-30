using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using AdminModule.ViewModels;
using Resource;
namespace AdminModule.Views
{
    /// <summary>
    /// Interaction logic for AddSinhVien_AdminView.xaml
    /// </summary>
    public partial class AddSinhVien_AdminView : UserControl
    {
        public AddSinhVien_AdminView()
        {
            InitializeComponent();
        }

        private void dragimg(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                if (!CheckImg(file) || !CheckSize(file))
                {
                    e.Effects = DragDropEffects.None;
                }

            }
        }
        private bool CheckImg(string path) 
        {
            string[] extensions = { ".jpg",".png",".jpeg" };
            string ex = System.IO.Path.GetExtension(path).ToLower();
            return Array.IndexOf(extensions, ex) != -1;
        }
        private bool CheckSize(string path) 
        {
            long maxSize = 20 * 1024 * 1024;
            FileInfo file = new FileInfo(path);
            return file.Length < maxSize;
        }

        private void dropimg(object sender, DragEventArgs e)
        {
            string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (CheckImg(file) && CheckSize(file))
                {
                AddSinhVien_AdminViewModel addSinhVien_ = (AddSinhVien_AdminViewModel)this.DataContext;
                   
                    addSinhVien_.PathImg = ConvertImg.cvimg(file);
                 
                }
            }
        }
    }
}

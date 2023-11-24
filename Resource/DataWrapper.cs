using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource
{
    public class DataWrapper<T> : INotifyPropertyChanged where T : class
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int index;
        private T data;
        public DataWrapper(int index)
        {
            this.index = index;
        }
        public int Index
        {
            get => this.index;
        }
        public int ItemNumber
        {
            get => this.index + 1;
        }
        public bool IsLoading
        {
            get => this.data == null;
        }
        public T Data
        {
            get => this.data;
            internal set
            {
                this.data = value;
                OnPropertyChanged("Data");
                OnPropertyChanged("IsLoading");
            }
        }
        public bool IsUse
        {
            get => PropertyChanged != null;
        }
        private void OnPropertyChanged(string propertyName)
        {
            System.Diagnostics.Debug.Assert(this.GetType().GetProperty(propertyName) != null);
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

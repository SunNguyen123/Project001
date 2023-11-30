using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resource
{
    public class AsyncVirtualCollection<T> : VirtualizingCollection<T>, INotifyCollectionChanged, INotifyPropertyChanged where T : class
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly SynchronizationContext _synchronizationContext;
        public AsyncVirtualCollection(IItemsProvider<T> itemsProvider, int pageSize, int pageTimeout) : base(itemsProvider, pageSize, pageTimeout)
        {
            this._synchronizationContext = SynchronizationContext.Current;
        }
        protected SynchronizationContext SynchronizationContext
        {
            get => _synchronizationContext;
        }
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler h = CollectionChanged;
            if (h != null)
                h(this, e);
        }
        private void FireCollectionReset()
        {
            NotifyCollectionChangedEventArgs e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            OnCollectionChanged(e);
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler h = PropertyChanged;
            if (h != null)
                h(this, e);
        }
        private void FirePropertyChanged(string propertyName)
        {
            PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
            OnPropertyChanged(e);
        }
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (value != _isLoading)
                {
                    _isLoading = value;
                    FirePropertyChanged(nameof(IsLoading));
                }
            }
        }
        private bool _isInitializing;
        public bool IsInitializing
        {
            get => _isInitializing;
            set
            {
                if (value != _isInitializing)
                {
                    _isInitializing = value;
                    FirePropertyChanged(nameof(IsInitializing));
                }
            }
        }

        public override void LoadCount()
        {
            if (Count == 0)
            {
                IsInitializing = true;
            }
            ThreadPool.QueueUserWorkItem(LoadCountWork);
        }

        private void LoadCountWork(object state)
        {
            int count = FetchCount();
            SynchronizationContext.Send(LoadCountCompleted, count);
        }

        protected virtual void LoadCountCompleted(object state)
        {
            int newCount = (int)state;
            this.TakeNewCount(newCount);
            IsInitializing = false;
        }

        private void TakeNewCount(int newCount)
        {

            if (newCount != this.Count)
            {
                this.Count = newCount;
                this.EmtyCache();
                FireCollectionReset();
            }
        }
    
    
    protected override void LoadPage(int pageIndex, int pageLength)
        {
            IsLoading = true;
            ThreadPool.QueueUserWorkItem(LoadPageWork,new int[] { pageIndex,pageLength});
        }

        private void LoadPageWork(object state)
        {
            int[] args = (int[])state;
            int pageIndex = args[0];
            int pageLength = args[1];
            int overallCount = 0;
            IList<T> dataItems = FetchPage(pageIndex, pageLength, out overallCount);
            SynchronizationContext.Send(LoadPageCompleted, new object[] { pageIndex, dataItems, overallCount });
        }

        private void LoadPageCompleted(object state)
        {
            object[] args = (object[])state;
            int pageIndex = (int)args[0];
            IList<T> dataItems = (IList<T>)args[1];
            int newCount = (int)args[2];
            this.TakeNewCount(newCount);
            PopulatePage(pageIndex,dataItems);
            IsLoading = false;
        }
    }
}

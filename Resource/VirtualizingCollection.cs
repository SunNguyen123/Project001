using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource
{
    public class VirtualizingCollection<T> : IList<DataWrapper<T>>,IList where T:class
    {
        public VirtualizingCollection(IItemsProvider<T> itemsProvider,int pageSize,int pageTimeout)
        {
            this._itemsProvider = itemsProvider;

        }
        private Dictionary<int, DataPage<T>> _pages = new Dictionary<int, DataPage<T>>();
        private readonly IItemsProvider<T> _itemsProvider;
        public IItemsProvider<T> ItemsProvider
        {
            get => _itemsProvider;
        }
        private readonly int _pageSize = 100;
        public int PageSize
        {
            get => _pageSize;
        }
        private readonly long _pageTimeOut = 5000;
        public long PageTimeout
        {
            get { return _pageTimeOut; }
        }
        private int _count = -1;
        public DataWrapper<T> this[int index] { 
            get
            {
                int pageIndex = index / PageSize;
                int pageOffset = index % PageSize;
                RequestPage(pageIndex);
                if(pageOffset>PageSize/2 && pageIndex < Count / PageSize)
                {
                    RequestPage(pageIndex + 1);
                }
                if (pageOffset < PageSize / 2 && pageIndex > 0) RequestPage(pageIndex - 1);

                CleanUpPages();

                return _pages[pageIndex].Items[pageOffset];
            }
            set => throw new NotImplementedException(); }
        protected void EmtyCache()
        {
            _pages = new Dictionary<int, DataPage<T>>();
            
        }
        protected int FetchCount()
        {
            return _itemsProvider.FetchCount(); 
        }
        protected virtual void LoadCount()
        {
            this.Count = FetchCount();
        }
        private void CleanUpPages()
        {

                int[] keys = _pages.Keys.ToArray();
                foreach (var key in keys)
                {
                    if (key != 0 && (DateTime.Now - _pages[key].TouchTime).TotalMilliseconds > PageTimeout)
                    {
                        bool removePage = true;
                        DataPage<T> page;
                        if (_pages.TryGetValue(key, out page))
                        {
                            removePage = !page.IsInUse;
                        }
                        if (removePage)
                        {
                            _pages.Remove(key);
                        }
                    }
                }
           
        }

        private void RequestPage(int pageIndex)
        {
            if (!_pages.ContainsKey(pageIndex))
            {
                int pageLength = Math.Min(this.PageSize,this.Count-pageIndex*this.PageSize);
                DataPage<T> page = new DataPage<T>(pageIndex * PageSize, pageLength);
                _pages.Add(pageIndex, page);
                LoadPage(pageIndex, pageLength);
            }
            else
            {
                _pages[pageIndex].TouchTime = DateTime.Now;
            }
        }

        protected virtual void LoadPage(int pageIndex, int pageLength)
        {
            int count = 0;
            PopulatePage(pageIndex,FetchPage(pageIndex,pageLength,out count));
            this.Count = count;
        }

        public void PopulatePage(int pageIndex, IList<T> dataItems)
        {
            DataPage<T> page;
            if (_pages.TryGetValue(pageIndex, out page))
            {
                page.Populate(dataItems);
            }
        }

        protected IList<T> FetchPage(int pageIndex,int pageLength,out int count)
        {
            return ItemsProvider.FetchRange(pageIndex*PageSize,pageLength,out count);
        }
        object IList.this[int index] { get => this[index]; set => throw new NotImplementedException(); }

        public int Count
        {
            get
            {
                if (_count==-1) 
                {
                    _count = 0;
                    LoadCount();
                }
                return _count;
            }
            protected set
            {
                _count = value;
            }
        }

 

        public bool IsReadOnly => true;

        public bool IsFixedSize => false;

        public object SyncRoot => this;

        public bool IsSynchronized => false;

        public void Add(DataWrapper<T> item)
        {
            throw new NotImplementedException();
        }

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(DataWrapper<T> item)
        {

            foreach (DataPage<T> page in _pages.Values) 
            {
                if (page.Items.Contains(item)) return true;
            }
            return false;
        }

        public bool Contains(object value)
        {
            return Contains((DataWrapper<T>)value);
        }

        public void CopyTo(DataWrapper<T>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<DataWrapper<T>> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public int IndexOf(DataWrapper<T> item)
        {
          foreach(KeyValuePair<int,DataPage<T>> keyValuePair in _pages)
            {
                int indexWithPage = keyValuePair.Value.Items.IndexOf(item);
                if (indexWithPage != -1)
                {
                    return PageSize * keyValuePair.Key + indexWithPage;
                }
            }
            return -1;
        }

        public int IndexOf(object value)
        {
            return IndexOf((DataWrapper<T>)value);
        }

        public void Insert(int index, DataWrapper<T> item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            Insert(index, (DataWrapper<T>)value);
        }

        public bool Remove(DataWrapper<T> item)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

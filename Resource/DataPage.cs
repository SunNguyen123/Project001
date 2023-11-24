using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource
{
   public class DataPage<T> where T:class
    {
        public IList<DataWrapper<T>> Items { set; get; }
        public DateTime TouchTime { set; get; }
        public bool IsInUse
        {
            get => this.Items.Any(wrapper=>wrapper.IsUse);
        }
        public DataPage(int firstIndex,int pageLength)
        {
            this.Items = new List<DataWrapper<T>>(pageLength);
            for(var i = 0; i < pageLength; i++)
            {
                this.Items.Add(new DataWrapper<T>(firstIndex+i));
            }
            this.TouchTime = DateTime.Now;
        }
        public void Populate(IList<T> newItems)
        {
            int i;
            int index = 0;
            for (i=0;i<newItems.Count && i<this.Items.Count;i++) 
            {
                this.Items[i].Data = newItems[i];
                index = this.Items[i].Index;
            }
            while (i<newItems.Count) 
            {
                index++;
                this.Items.Add(new DataWrapper<T>(index) { Data=newItems[i]});
                i++;
            }
            while (i < this.Items.Count)
            {
                this.Items.RemoveAt(this.Items.Count-1);
            }
        }
    }
}

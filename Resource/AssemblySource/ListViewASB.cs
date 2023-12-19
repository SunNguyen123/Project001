using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Resource.AssemblySource
{
    public class ListViewASB
    {
        public ListViewASB()
        {



        }
        public static ComponentResourceKey View1item
        {
            get => new ComponentResourceKey(typeof(ListViewASB), "view1item");

        }
        public static ComponentResourceKey View
        {
            get => new ComponentResourceKey(typeof(ListViewASB), "view1");

        }
    }
}

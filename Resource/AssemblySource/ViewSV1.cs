using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Resource.AssemblySource
{
   public class ViewSV1: ViewBase
    {
        protected override object ItemContainerDefaultStyleKey
        {
            get => new ComponentResourceKey(typeof(ListViewASB), "view1item");
        }
        protected override object DefaultStyleKey
        {
            get => new ComponentResourceKey(typeof(ListViewASB), "view1");
        }
    }
}

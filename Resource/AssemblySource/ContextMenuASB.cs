using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Resource.AssemblySource
{
    public class ContextMenuASB
    {

        public static ComponentResourceKey MN1
        {
            get => new ComponentResourceKey(typeof(ContextMenuASB), "mn1");
        }
        public static ComponentResourceKey MNITEM1
        {
            get => new ComponentResourceKey(typeof(ContextMenuASB), "mnitem1");
        }

    }
}

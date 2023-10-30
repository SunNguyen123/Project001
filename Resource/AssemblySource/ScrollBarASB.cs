using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Resource.AssemblySource
{
    public class ScrollBarASB
    {

        public static ComponentResourceKey ScrollBarStyle1
        {
            get => new ComponentResourceKey(typeof(ScrollBarASB), "ScrollBarStyle1");
        }

        public static ComponentResourceKey ScrollBarThumbVertical
        {
            get => new ComponentResourceKey(typeof(ScrollBarASB), "ScrollBarThumbVertical");
        }

        public static ComponentResourceKey ScrollBarThumbHorizontal
        {
            get => new ComponentResourceKey(typeof(ScrollBarASB), "ScrollBarThumbHorizontal");
        }

        public static ComponentResourceKey ColumnHeaderGripperStyle
        {
            get => new ComponentResourceKey(typeof(ScrollBarASB), "ColumnHeaderGripperStyle");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Resource.AssemblySource
{
   public class FontASB
    {
        public static ComponentResourceKey Bold
        {
            get => new ComponentResourceKey(typeof(FontASB),"bold");
        }

        public static ComponentResourceKey Medium
        {
            get => new ComponentResourceKey(typeof(FontASB), "medium");
        }

        public static ComponentResourceKey Italic
        {
            get => new ComponentResourceKey(typeof(FontASB), "italic");
        }
        public static ComponentResourceKey Regular
        {
            get => new ComponentResourceKey(typeof(FontASB), "regular");
        }
    }
}

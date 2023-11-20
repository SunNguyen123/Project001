using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Resource.AssemblySource
{
   public class TextBoxASB
    {


        public static ComponentResourceKey TB1
        {
            get => new ComponentResourceKey(typeof(TextBoxASB),"tb1");
        }


        public static ComponentResourceKey PS1
        {
            get => new ComponentResourceKey(typeof(TextBoxASB), "ps1");
        }


        public static ComponentResourceKey TBTK
        {
            get => new ComponentResourceKey(typeof(TextBoxASB), "tbTK");
        }



        public static ComponentResourceKey nonetb1
        {
            get => new ComponentResourceKey(typeof(TextBoxASB), "nonetb1");
        }
    }
}

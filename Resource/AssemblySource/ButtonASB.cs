using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Resource.AssemblySource
{
   public class ButtonASB
    {
        
        public static ComponentResourceKey Bt_Round_Icon 
        {
            get => new ComponentResourceKey(typeof(ButtonASB),"bt_round_icon");
        }
        public static ComponentResourceKey Bt_Round
        {
            get => new ComponentResourceKey(typeof(ButtonASB), "bt_round");
        }
        public static ComponentResourceKey Bt_Round_Icon_Text
        {
            get => new ComponentResourceKey(typeof(ButtonASB), "bt_round_text_icon");
        }

        public static ComponentResourceKey RepeatButtonTransparent
        {
            get => new ComponentResourceKey(typeof(ButtonASB), "RepeatButtonTransparent");
        }
        public static ComponentResourceKey ScrollBarButton
        {
            get => new ComponentResourceKey(typeof(ButtonASB), "ScrollBarButton");
        }
    }
}

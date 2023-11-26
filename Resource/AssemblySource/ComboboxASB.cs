using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Resource.AssemblySource
{
    public class ComboboxASB
    {

        public ComboboxASB()
        {
            ComboBox comboBox = new ComboBox();
        }
        public static ComponentResourceKey TG
        {
            get => new ComponentResourceKey(typeof(ComboboxASB), "tg");
            
        }
        public static ComponentResourceKey TGNONE
        {
            get => new ComponentResourceKey(typeof(ComboboxASB), "tgnone");

        }

        public static ComponentResourceKey CMB1
        {
            get => new ComponentResourceKey(typeof(ComboboxASB), "cmb1");
        }

        public static ComponentResourceKey CMBTEXT
        {
            get => new ComponentResourceKey(typeof(ComboboxASB), "cmbtext");
        }

        public static ComponentResourceKey TGNEW
        {
            get => new ComponentResourceKey(typeof(ComboboxASB), "tgnew");
        }

        public static ComponentResourceKey ComboBoxTextBox
        {
            get => new ComponentResourceKey(typeof(ComboboxASB), "ComboBoxTextBox");
        }
        public static ComponentResourceKey CMBITEM1
        {
            get => new ComponentResourceKey(typeof(ComboboxASB), "cmbitem1");
        }


        public static ComponentResourceKey ComboBoxEditableTemplate
        {
            get => new ComponentResourceKey(typeof(ComboboxASB), "ComboBoxEditableTemplate");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Resource.AssemblySource
{
   public class DatagridASB
    {
        public DatagridASB()
        {
            
        }
        public static ComponentResourceKey DGV1
        {
            get => new ComponentResourceKey(typeof(DatagridASB), "dgv1");
        }
        public static ComponentResourceKey DGVHEADER
        {
            get => new ComponentResourceKey(typeof(DatagridASB), "dgvheader");
        }
        public static ComponentResourceKey CELLSTYLE
        {
            get => new ComponentResourceKey(typeof(DatagridASB), "cellstyle");
        }
        public static ComponentResourceKey DGVROW
        {
            get => new ComponentResourceKey(typeof(DatagridASB), "dgvrow");
        }

        public static ComponentResourceKey DGVCELL
        {
            get => new ComponentResourceKey(typeof(DatagridASB), "dgvcell");
        }


     
    }
}

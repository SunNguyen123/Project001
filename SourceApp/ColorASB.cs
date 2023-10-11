using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SourceApp
{
    public class ColorASB
    {
        public static ComponentResourceKey Red
        {
            get => new ComponentResourceKey(typeof(ColorASB), "red");
        }

        public static ComponentResourceKey Green
        {
            get => new ComponentResourceKey(typeof(ColorASB), "green");
        }

        public static ComponentResourceKey Orange
        {
            get => new ComponentResourceKey(typeof(ColorASB), "orange");
        }

        public static ComponentResourceKey BD200
        {
            get => new ComponentResourceKey(typeof(ColorASB), "bd200");
        }

        public static ComponentResourceKey BD300
        {
            get => new ComponentResourceKey(typeof(ColorASB), "bd300");
        }
        public static ComponentResourceKey BD400
        {
            get => new ComponentResourceKey(typeof(ColorASB), "bd400");
        }
        public static ComponentResourceKey BD500
        {
            get => new ComponentResourceKey(typeof(ColorASB), "bd500");
        }
        public static ComponentResourceKey BD600
        {
            get => new ComponentResourceKey(typeof(ColorASB), "bd600");
        }
        public static ComponentResourceKey BD700
        {
            get => new ComponentResourceKey(typeof(ColorASB), "bd700");
        }

    }
}

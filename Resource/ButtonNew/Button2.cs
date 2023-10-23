using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using MahApps.Metro.IconPacks;
namespace Resource.ButtonNew
{
   public class Button2:Button
    {
        public Button2()
        {

        }
        private static readonly DependencyProperty BackgroundNewProperty = DependencyProperty.Register("BackgroundNew",typeof(Brush),typeof(Button2));
        public Brush BackgroundNew 
        {
            set => SetValue(BackgroundNewProperty, value);
            get =>(Brush)GetValue(BackgroundNewProperty);
        }

        private static readonly DependencyProperty BoderRadiusProperty = DependencyProperty.Register("border_radius", typeof(CornerRadius), typeof(Button2));
        public CornerRadius border_radius
        {
            set => SetValue(BoderRadiusProperty, value);
            get => (CornerRadius)GetValue(BoderRadiusProperty);
        }


        private static readonly DependencyProperty ColorgroundNewProperty = DependencyProperty.Register("Color", typeof(Brush), typeof(Button2));
        public Brush Color
        {
            set => SetValue(ColorgroundNewProperty, value);
            get => (Brush)GetValue(ColorgroundNewProperty);
        }

        private static readonly DependencyProperty HoverProperty = DependencyProperty.Register("Hover", typeof(Brush), typeof(Button2));
        public Brush Hover
        {
            set => SetValue(HoverProperty, value);
            get => (Brush)GetValue(HoverProperty);
        }


        private static readonly DependencyProperty PressProperty = DependencyProperty.Register("Press", typeof(Brush), typeof(Button2));
        public Brush Press
        {
            set => SetValue(PressProperty, value);
            get => (Brush)GetValue(PressProperty);
        }


        private static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(PackIconMaterialDesignKind), typeof(Button2),new PropertyMetadata(PackIconMaterialDesignKind.None));
        public PackIconMaterialDesignKind Icon
        {
            set => SetValue(ColorgroundNewProperty, value);
            get => (PackIconMaterialDesignKind)GetValue(ColorgroundNewProperty);
        }
    }
}

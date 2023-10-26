using Resource.ButtonNew;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace Resource.NewControl
{
    public class ToggleButtonNew:ToggleButton
    {


         static ToggleButtonNew()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleButtonNew), new FrameworkPropertyMetadata(typeof(ToggleButtonNew)));
       
        
        }
        public ToggleButtonNew()
        {
            //Binding binding = new Binding("Menu.IsOpen");
            //binding.Source = this;
            //this.SetBinding(IsCheckedProperty, binding);
            //DataContextChanged += (sender, args) =>
            //{
            //    //if (Menu != null)
            //    //    Menu.DataContext = DataContext;
                
            //};
        }
        public static readonly DependencyProperty ImageSourceNewProperty = DependencyProperty.Register("IMG", typeof(Uri), typeof(ToggleButtonNew));
        public Uri IMG
        {
            set => SetValue(ImageSourceNewProperty, value);
            get => (Uri)GetValue(ImageSourceNewProperty);
        }
        public static readonly DependencyProperty MenuNewProperty = DependencyProperty.Register("Menu", typeof(ContextMenu), typeof(ToggleButtonNew), new UIPropertyMetadata(null, OnMenuChanged));

        private static void OnMenuChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //var dropDownButton = (ToggleButtonNew)d;
            //var contextMenu = (ContextMenu)e.NewValue;
            //contextMenu.DataContext = dropDownButton.DataContext;
        }

        //public ContextMenu Menu
        //{
        //    set => SetValue(MenuNewProperty, value);
        //    get => (ContextMenu)GetValue(MenuNewProperty);
        //}
        public static readonly DependencyProperty OpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(ToggleButtonNew),new PropertyMetadata(false));
        public bool IsOpen
        {
            set => SetValue(ImageSourceNewProperty, value);
            get => (bool)GetValue(ImageSourceNewProperty);
        }
        protected override void OnClick()
        {
            //if (Menu != null)
            //{
            //    Menu.PlacementTarget = this;
            //    Menu.Placement = PlacementMode.Bottom;
            //    Menu.IsOpen = true;
            //}
            this.ContextMenu.IsOpen = true;
        
        }

    }
}

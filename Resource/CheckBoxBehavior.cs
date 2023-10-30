using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace Resource
{
    public class CheckBoxBehavior: Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            // Lấy ra Windows đang chứa đối tượng bị tác người dùng động
            // Đối tượng bị tác người dùng động chính là AssociatedObject
             CheckBox ck =AssociatedObject as CheckBox;
            DataGrid dataGrid = new DataGrid();
        
            ck.Checked +=
                (sender, e) =>
                {
                
                };
        }
    }
}

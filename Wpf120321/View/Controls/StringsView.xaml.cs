using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf120321.View.Controls
{
    /// <summary>
    /// Interaction logic for StringsView.xaml
    /// </summary>
    public partial class StringsView : UserControl
    {
        public StringsView()
        {
            InitializeComponent();
        }

        public string LeftString
        {
            get =>
                (string)GetValue(LeftStringProperty);

            set =>
                SetValue(LeftStringProperty, value);
        }
        public static readonly DependencyProperty LeftStringProperty = DependencyProperty.Register(
            nameof(LeftString), typeof(string), typeof(StringsView), new PropertyMetadata("default"));
    }
}

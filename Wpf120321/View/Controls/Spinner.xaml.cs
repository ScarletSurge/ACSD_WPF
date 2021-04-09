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
using System.Windows.Threading;
using Wpf120321.ViewModel;

namespace Wpf120321.View.Controls
{

    public partial class Spinner : UserControl
    {
        public const double ItemSizeParameter = 40;

        private DispatcherTimer _rotationTimer;
        private readonly object _syncObject = new object();

        public Spinner()
        {
            InitializeComponent();
            _rotationTimer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 25), DispatcherPriority.Normal, (sender, eventArgs) =>
            {
                lock (_syncObject)
                {
                    for (var i = 0; i < Items.Length; i++)
                    {
                        Items[i].Angle = (Items[i].Angle + 5) % 360;
                    }
                }
            }, Dispatcher.CurrentDispatcher);
        }

        public int CirclesCount
        {
            get =>
                (int)GetValue(CirclesCountProperty);

            set =>
                SetValue(CirclesCountProperty, value);
        }
        public static readonly DependencyProperty CirclesCountProperty = DependencyProperty.Register(
            nameof(CirclesCount), typeof(int), typeof(Spinner), new PropertyMetadata(5, (sender, eventArgs) =>
            {
                var oldCountValue = (int)eventArgs.OldValue;
                var newCountValue = (int)eventArgs.NewValue;

                var targetSpinner = sender as Spinner;

                //if (oldCountValue == newCountValue)
                //{
                //    return;
                //}

                // TODO: initialize array items
                var newItems = new SpinnerItemViewModel[newCountValue];
                for (var i = 0; i < newCountValue; i++)
                {
                    newItems[i] = new SpinnerItemViewModel
                    {
                        X = targetSpinner.Width - ItemSizeParameter,
                        Y = (targetSpinner.Height - ItemSizeParameter) / 2,
                        Angle = 360d / newCountValue * i
                    };
                }

                targetSpinner.Items = newItems;
            }));

        public SpinnerItemViewModel[] Items
        {
            get =>
                (SpinnerItemViewModel[])GetValue(ItemsProperty);

            private set
            {
                lock (_syncObject)
                {
                    SetValue(ItemsProperty, value);
                }
            }
        }
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            nameof(Items), typeof(SpinnerItemViewModel[]), typeof(Spinner));
    }
}

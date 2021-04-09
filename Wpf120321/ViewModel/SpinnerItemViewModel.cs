using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThirdCourse.WPF.MVVM;

namespace Wpf120321.ViewModel
{
    public sealed class SpinnerItemViewModel : BaseViewModel
    {

        private double _x;
        private double _y;
        private double _angle;

        public double X
        {
            get =>
                _x;

            set
            {
                _x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        public double Y
        {
            get =>
                _y;

            set
            {
                _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        public double Angle
        {
            get =>
                _angle;

            set
            {
                _angle = value;
                OnPropertyChanged(nameof(Angle));
            }
        }

    }
}

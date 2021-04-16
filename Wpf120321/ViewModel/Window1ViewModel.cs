using System.Windows.Input;

using ThirdCourse.WPF.MVVM;

namespace Wpf120321.ViewModel
{

    internal sealed class Window1ViewModel : BaseViewModel
    {

        private int _circlesCount;
        private ICommand _decrementCirclesCountCommand;
        private ICommand _incrementCirclesCountCommand;

        public Window1ViewModel()
        {
            CirclesCount = 3;
        }

        public int CirclesCount
        {
            get =>
                _circlesCount;

            private set
            {
                _circlesCount = value;
                OnPropertyChanged(nameof(CirclesCount));
            }
        }

        public ICommand DecrementCirclesCountCommand =>
            _decrementCirclesCountCommand ?? (_decrementCirclesCountCommand = new RelayCommand(_ => DecrementCirclesCount(),
                _ => CanDecrementCirclesCount()));

        public ICommand IncrementCirclesCountCommand =>
            _incrementCirclesCountCommand ?? (_incrementCirclesCountCommand = new RelayCommand(_ => IncrementCirclesCount()));

        private void DecrementCirclesCount()
        {
            CirclesCount--;
        }

        private bool CanDecrementCirclesCount()
        {
            return CirclesCount != 3;
        }

        private void IncrementCirclesCount()
        {
            CirclesCount++;
        }

    }

}
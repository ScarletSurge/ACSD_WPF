using System.Collections.ObjectModel;
using System.Windows.Input;

using ThirdCourse.WPF.MVVM;

namespace Wpf120321.ViewModel
{

    internal sealed class MVVMDemoWindowViewModel : BaseViewModel
    {

        #region Fields

        private ObservableCollection<StringsViewModel> _strings;

        #region Command fields

        private ICommand _addStringsCommand;

        #endregion

        #endregion

        #region Constructors

        public MVVMDemoWindowViewModel()
        {
            Strings = new ObservableCollection<StringsViewModel>();
        }

        #endregion

        #region Properties

        public ObservableCollection<StringsViewModel> Strings
        {
            get =>
                _strings;

            private set
            {
                _strings = value;
                OnPropertyChanged(nameof(Strings));
            }
        }

        #region Command properties

        public ICommand AddStringsCommand =>
            _addStringsCommand ?? (_addStringsCommand = new RelayCommand(_ => AddStrings(),
                _ => CanAddStrings()));

        #endregion

        #endregion

        #region Methods

        private void AddStrings()
        {
            var stringsViewModel = new StringsViewModel();
            stringsViewModel.RemovingRequested += (itemToRemove) =>
            {
                Strings.Remove(itemToRemove);
                //OnPropertyChanged(nameof(Strings));

                // SHITCODE DETECTED!!1!11
                //var s = Strings;
                //Strings = null;
                //Strings = s;
            };
            Strings.Add(stringsViewModel);
        }

        private bool CanAddStrings()
        {
            return Strings.Count < 5;
        }

        #endregion

    }

}
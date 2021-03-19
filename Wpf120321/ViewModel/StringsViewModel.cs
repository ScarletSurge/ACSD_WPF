using System;
using System.Linq;
using System.Text;
using System.Windows.Input;

using Wpf120321.Model;

namespace Wpf120321.ViewModel
{

    public sealed class StringsViewModel : BaseViewModel
    {

        #region Fields

        private StringsModel _model;

        #region Command fields

        private ICommand _refreshStringsCommand;

        #endregion

        #endregion

        #region Constructors

        public StringsViewModel()
        {
            _model = new StringsModel();
        }

        #endregion

        #region Properties

        public string First
        {
            get =>
                _model.FirstString;

            private set
            {
                _model.FirstString = value;
                // TODO: nameof is better one
                OnPropertyChanged("First");
            }
        }

        public string Second
        {
            get =>
                _model.SecondString;

            private set
            {
                _model.SecondString = value;
                OnPropertyChanged(nameof(Second));
            }
        }

        #region Command properties

        public ICommand RefreshStringsCommand =>
            _refreshStringsCommand ?? (_refreshStringsCommand = new RelayCommand(_ => RefreshStrings()));

        #endregion

        #endregion

        #region Methods

        #region Command methods

        private void RefreshStrings()
        {
            var alphabet = string.Concat(Enumerable.Range(0, 26).Select(i => (char)(i + 65)).Concat(
                Enumerable.Range(0, 26).Select(i => (char)(i + 97))));
            var random = new Random();
            var firstNewLength = random.Next(10, 26);
            var secondNewLength = random.Next(10, 26);
            var sbFirst = new StringBuilder(firstNewLength);
            var sbSecond = new StringBuilder(secondNewLength);
            for (var i = 0; i < firstNewLength; i++)
            {
                sbFirst.Append(alphabet[random.Next(alphabet.Length)]);
            }
            for (var i = 0; i < secondNewLength; i++)
            {
                sbSecond.Append(alphabet[random.Next(alphabet.Length)]);
            }
            First = sbFirst.ToString();
            Second = sbSecond.ToString();
        }

        #endregion

        #endregion

    }

}
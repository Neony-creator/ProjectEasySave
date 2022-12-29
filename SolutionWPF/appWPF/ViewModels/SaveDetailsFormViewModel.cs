using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace appWPF.ViewModels
{
    public class SaveDetailsFormViewModel : ViewModelBase
    {
        private string _savename;

        public string SaveName
        {
            get { return _savename; }
            set
            {
                _savename = value;
                OnPropertyChanged(nameof(SaveName));
            }
        }

        private string _sourceDisplay;

        public string SourceDisplay
        {
            get { return _sourceDisplay; }
            set 
            {
                _sourceDisplay = value;
                OnPropertyChanged(nameof(SourceDisplay));
            }
        }

        private string _destinationDisplay;

        public string DestinationDisplay
        {
            get { return _destinationDisplay; }
            set 
            {
                _destinationDisplay = value;
                OnPropertyChanged(nameof(DestinationDisplay));
            }
        }

        private string _typeDisplay;



        public string TypeDisplay
        {
            get { return _typeDisplay; }
            set 
            {
                _typeDisplay = value;
                OnPropertyChanged(nameof(TypeDisplay));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public SaveDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }
}

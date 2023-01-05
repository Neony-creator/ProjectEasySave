using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace appWPF.ViewModels
{
    public class ExecuteSomeSaveFormViewModel :ViewModelBase
    {
        private string saveToExceute;

        public string SavesSelectedToExecute
        {
            get { return saveToExceute; }
            set
            {
                saveToExceute = value;
                OnPropertyChanged(nameof(SavesSelectedToExecute));
            }
        }


        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ExecuteSomeSaveFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {


            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }
}

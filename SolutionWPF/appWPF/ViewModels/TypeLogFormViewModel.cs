using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace appWPF.ViewModels
{
    public class TypeLogFormViewModel : ViewModelBase
    {

        private string _typelog;

        public string log
        {
            get { return _typelog; }
            set
            {
                _typelog = value;
                OnPropertyChanged(nameof(log));
            }
        }


        public ICommand TypeLogCommand { get; }
        public ICommand CancelCommand { get; }

        public TypeLogFormViewModel(ICommand typeLogCommand, ICommand cancelCommand)
        {


            TypeLogCommand = typeLogCommand;
            CancelCommand = cancelCommand;
        }
    }
}

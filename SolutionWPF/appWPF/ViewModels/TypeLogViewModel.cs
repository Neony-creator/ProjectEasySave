using appWPF.Commands;
using appWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace appWPF.ViewModels
{
    public class TypeLogViewModel : ViewModelBase
    {
        private SavesStore savesStore;
        private ModalNavigationStore modalNavigationStore;
        private SelectedSaveStore selectedSaveStore;


        public TypeLogFormViewModel TypeLogFormViewModel { get; }

        public TypeLogViewModel(SavesStore savesStore, ModalNavigationStore modalNavigationStore, SelectedSaveStore selectedSaveStore)
        {

            ICommand typeLogCommand = new TypeLogCommand(this, savesStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);

            TypeLogFormViewModel = new TypeLogFormViewModel(typeLogCommand, cancelCommand);
        }
    }
}

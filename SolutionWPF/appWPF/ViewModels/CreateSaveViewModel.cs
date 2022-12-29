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
    public class CreateSaveViewModel:ViewModelBase
    {
        public SaveDetailsFormViewModel SaveDetailsFormViewModel { get; }

        public CreateSaveViewModel(SavesStore savesStore, ModalNavigationStore modalNavigationStore)
        {
            ICommand submitCommand = new CreateSaveCommand(this, savesStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            
            SaveDetailsFormViewModel = new SaveDetailsFormViewModel(submitCommand, cancelCommand); 
        }

    }   
}

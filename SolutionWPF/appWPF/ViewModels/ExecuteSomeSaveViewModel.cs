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
    public class ExecuteSomeSaveViewModel : ViewModelBase
    {
        private SavesStore savesStore;
        private ModalNavigationStore modalNavigationStore;
        private SelectedSaveStore selectedSaveStore;

        public SavesListingViewModel SavesListingViewModel { get; }
        public SaveDetailsViewModel SaveDetailsViewModel { get; }


        public ExecuteSomeSaveFormViewModel ExecuteSomeSaveFormViewModel { get; }

        public ExecuteSomeSaveViewModel(SavesStore savesStore, ModalNavigationStore modalNavigationStore, SelectedSaveStore selectedSaveStore)
        {
            this.savesStore = savesStore;
            this.modalNavigationStore = modalNavigationStore;
            this.selectedSaveStore = selectedSaveStore;


            SavesListingViewModel = SavesListingViewModel.LoadViewModel(savesStore, selectedSaveStore, modalNavigationStore);
            SaveDetailsViewModel = new SaveDetailsViewModel(selectedSaveStore);


            ICommand submitCommand = new ExecuteSomeSavesCommand(this, savesStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);

            ExecuteSomeSaveFormViewModel = new ExecuteSomeSaveFormViewModel(submitCommand, cancelCommand);
        }

    }
}

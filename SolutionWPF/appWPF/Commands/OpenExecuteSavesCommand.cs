using appWPF.Stores;
using appWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appWPF.Commands
{
    public class OpenExecuteSavesCommand : CommandBase
    {
        private readonly SavesStore _savesStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly SelectedSaveStore _selectedSaveStore;
       
        public OpenExecuteSavesCommand(SavesStore savesStore, ModalNavigationStore modalNavigationStore, SelectedSaveStore selectedSaveStore)
        {
            _selectedSaveStore = selectedSaveStore;
            _savesStore = savesStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            ExecuteSomeSaveViewModel createSaveViewModel = new ExecuteSomeSaveViewModel(_savesStore, _modalNavigationStore, _selectedSaveStore);
            _modalNavigationStore.CurrentViewModel = createSaveViewModel;
        }
    }
}

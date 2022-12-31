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
    public class SavesViewModel : ViewModelBase
    {
        public SavesListingViewModel SavesListingViewModel { get; }
        public SaveDetailsViewModel SaveDetailsViewModel { get; }
        public ICommand CreateSave { get; }
        public ICommand ExecuteAllSaves { get; }

        public SavesViewModel(SavesStore savesStore, SelectedSaveStore _selectedSaveStore, ModalNavigationStore modalNavigationStore)
        {
            SavesListingViewModel = SavesListingViewModel.LoadViewModel(savesStore, _selectedSaveStore, modalNavigationStore);
            SaveDetailsViewModel = new SaveDetailsViewModel(_selectedSaveStore);

            ExecuteAllSaves = new ExecuteAllSavesCommand(savesStore);
            CreateSave = new OpenAddSaveCommand(savesStore, modalNavigationStore);
        }
    }
}

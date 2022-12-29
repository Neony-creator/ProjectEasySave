using SaveDomain.Models;
using appWPF.Stores;
using appWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appWPF.Commands
{
    public class OpenEditSaveCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly SavesListingItemViewModel _savesListingItemViewModel;
        private readonly SavesStore _savesStore;

        public OpenEditSaveCommand(SavesListingItemViewModel savesListingItemViewModel, SavesStore savesStore, ModalNavigationStore modalNavigationStore)
        {
            _savesListingItemViewModel = savesListingItemViewModel;
            _savesStore = savesStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public SavesStore SaveStore { get; }

        public override void Execute(object parameter)
        {
            Save save = _savesListingItemViewModel.Save;

            EditSaveViewModel editSaveViewModel = new EditSaveViewModel(save, _savesStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editSaveViewModel;
        }
    }
}

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
    public class CreateSaveCommand : AsyncCommandBase
    {
        private readonly CreateSaveViewModel _createSaveViewModel;
        private readonly SavesStore _saveStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public CreateSaveCommand(CreateSaveViewModel createSaveViewModel, SavesStore savesStore, ModalNavigationStore modalNavigationStore)
        {
            _createSaveViewModel = createSaveViewModel;
            _saveStore = savesStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            SaveDetailsFormViewModel formViewModel = _createSaveViewModel.SaveDetailsFormViewModel;

            Save save = new Save(Guid.NewGuid(), formViewModel.SaveName, formViewModel.SourceDisplay, formViewModel.DestinationDisplay, formViewModel.TypeDisplay);

            try
            {
                await _saveStore.Add(save);

                _modalNavigationStore.Close();
            }
            catch(Exception)
            {
                throw;
            }

        }
    }
}

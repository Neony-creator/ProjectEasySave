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
    public class EditSaveCommand : AsyncCommandBase
    {
        private readonly EditSaveViewModel _editSaveViewModel;
        private readonly SavesStore _savesStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditSaveCommand(EditSaveViewModel editSaveViewModel, SavesStore savesStore, ModalNavigationStore modalNavigationStore)
        {
            _editSaveViewModel = editSaveViewModel;
            _savesStore = savesStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            SaveDetailsFormViewModel formViewModel = _editSaveViewModel.SaveDetailsFormViewModel;

            Save save = new Save(_editSaveViewModel.SaveId , formViewModel.SaveName, formViewModel.SourceDisplay, formViewModel.DestinationDisplay, formViewModel.TypeDisplay);

            try
            {
                await _savesStore.Update(save);

                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

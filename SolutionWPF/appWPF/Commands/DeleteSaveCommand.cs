using appWPF.Stores;
using appWPF.ViewModels;
using SaveDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appWPF.Commands
{
    public class DeleteSaveCommand : AsyncCommandBase
    {
        private readonly SavesListingItemViewModel _savesListingItemViewModel;
        private readonly SavesStore _savesStore;

        public DeleteSaveCommand(SavesListingItemViewModel savesListingItemViewModel, SavesStore savesStore)
        {
            _savesListingItemViewModel = savesListingItemViewModel;
            _savesStore = savesStore;
        }

       

        public override async Task ExecuteAsync(object parameter)
        {
            Save save = _savesListingItemViewModel.Save;
            //string name = save.DestinationDisplay;
            try
            {
                await _savesStore.Delete(save.Id);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}

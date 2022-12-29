using appWPF.Commands;
using SaveDomain.Models;
using appWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace appWPF.ViewModels
{
    public class SavesListingItemViewModel : ViewModelBase
    {
        public Save Save { get; private set; }
        public string SaveName => Save.SaveName;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }



        public SavesListingItemViewModel(Save save, SavesStore savesStore, ModalNavigationStore modalNavigationStore) //1:43:20
        {
            Save = save;

            EditCommand = new OpenEditSaveCommand(this, savesStore, modalNavigationStore);
            DeleteCommand = new DeleteSaveCommand(this, savesStore);
        }

        public void Update(Save save)
        {
            Save = save;

            OnPropertyChanged(nameof(SaveName));
        }
    }
}

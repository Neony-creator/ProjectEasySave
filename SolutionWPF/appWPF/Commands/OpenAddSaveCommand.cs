using appWPF.Stores;
using appWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace appWPF.Commands
{
    public class OpenAddSaveCommand : CommandBase
    {
        private readonly SavesStore _savesStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddSaveCommand(SavesStore savesStore, ModalNavigationStore modalNavigationStore)
        {
            _savesStore = savesStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            CreateSaveViewModel createSaveViewModel = new CreateSaveViewModel(_savesStore, _modalNavigationStore) ;
            _modalNavigationStore.CurrentViewModel = createSaveViewModel;
        }
    }
}

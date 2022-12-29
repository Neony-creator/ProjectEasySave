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
    public class EditSaveViewModel : ViewModelBase
    {
        public Guid SaveId { get; }
        public SaveDetailsFormViewModel SaveDetailsFormViewModel { get; }

        public EditSaveViewModel(Save save, SavesStore savesStore, ModalNavigationStore modalNavigationStore)
        {
            SaveId = save.Id;

            ICommand submitCommand = new EditSaveCommand(this, savesStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            SaveDetailsFormViewModel = new SaveDetailsFormViewModel(submitCommand, cancelCommand)
            {
                SaveName = save.SaveName,
                SourceDisplay = save.SourceDisplay,
                DestinationDisplay = save.DestinationDisplay,
                TypeDisplay = save.TypeDisplay
            };
        }
    }
}

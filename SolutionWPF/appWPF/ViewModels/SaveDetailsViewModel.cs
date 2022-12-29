using SaveDomain.Models;
using appWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appWPF.ViewModels
{
    public class SaveDetailsViewModel : ViewModelBase
    {
        private readonly SelectedSaveStore _selectedSaveStore;

        private Save SelectedSave => _selectedSaveStore.SelectedSave;

        public bool HasSelectedSave => SelectedSave != null;
        public string SaveName => SelectedSave?.SaveName;
        public string SourceDisplay => SelectedSave?.SourceDisplay;
        public string DestinationDisplay => SelectedSave?.DestinationDisplay;
        public string TypeDisplay => SelectedSave?.TypeDisplay;

        public SaveDetailsViewModel(SelectedSaveStore selectedSaveStore)
        {
            _selectedSaveStore = selectedSaveStore;

            _selectedSaveStore.SelectedSaveChanged += _selectedSaveStore_SelectedSaveChanged;
        }

        protected override void Dispose()
        {
            _selectedSaveStore.SelectedSaveChanged += _selectedSaveStore_SelectedSaveChanged;
            base.Dispose();
        }

        private void _selectedSaveStore_SelectedSaveChanged()
        {
            OnPropertyChanged(nameof(HasSelectedSave));
            OnPropertyChanged(nameof(SaveName));
            OnPropertyChanged(nameof(SourceDisplay));
            OnPropertyChanged(nameof(DestinationDisplay));
            OnPropertyChanged(nameof(TypeDisplay));
        }
    }
}
     
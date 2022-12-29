using appWPF.Commands;
using SaveDomain.Models;
using appWPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace appWPF.ViewModels
{
    public class SavesListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<SavesListingItemViewModel> _savesListingItemViewModels;
        private readonly SavesStore _saveStore;
        private readonly SelectedSaveStore _selectedSaveStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public IEnumerable<SavesListingItemViewModel> SavesListingItemViewModels => _savesListingItemViewModels;

        private SavesListingItemViewModel _selectedSaveListingItemViewModel;
        public SavesListingItemViewModel SelectedSaveListingItemViewModel
        {
            get
            {
                return _selectedSaveListingItemViewModel;
            }
            set
            {
                _selectedSaveListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedSaveListingItemViewModel));
                _selectedSaveStore.SelectedSave = _selectedSaveListingItemViewModel?.Save;
            }
        }

        public ICommand LoadSavesCommand { get; }


        public SavesListingViewModel(SavesStore savesStore, SelectedSaveStore selectedSaveStore, ModalNavigationStore modalNavigationStore)
        {
            _saveStore = savesStore;
            _selectedSaveStore = selectedSaveStore;
            _modalNavigationStore = modalNavigationStore;
            _savesListingItemViewModels = new ObservableCollection<SavesListingItemViewModel>();

            LoadSavesCommand = new LoadSavesCommand(savesStore);

            //
            _saveStore.SavesLoaded += SaveStore_SavesLoaded;
            _saveStore.SaveAdded += SaveStore_SaveAdded;
            _saveStore.SaveUpdated += SaveStore_SaveUpdated;
            _saveStore.SaveDeleted += SaveStore_SaveDeleted;

        }

        //

        private void SaveStore_SaveDeleted(Guid id)
        {
            SavesListingItemViewModel itemViewModel = _savesListingItemViewModels.FirstOrDefault(y => y.Save?.Id == id);

            if(itemViewModel != null)
            {
                _savesListingItemViewModels.Remove(itemViewModel);
            }
        }

        private void SaveStore_SavesLoaded()
        {
            _savesListingItemViewModels.Clear();

            foreach (Save save in _saveStore.Saves)
            {
                AddSave(save);
            }
        }

        public static SavesListingViewModel LoadViewModel(SavesStore savesStore, SelectedSaveStore selectedSaveStore, ModalNavigationStore modalNavigationStore)
        {
            SavesListingViewModel viewModel = new SavesListingViewModel(savesStore, selectedSaveStore, modalNavigationStore);

            viewModel.LoadSavesCommand.Execute(null);

            return viewModel;
        }

        private void SaveStore_SaveUpdated(Save save)
        {
            SavesListingItemViewModel saveViewModel = _savesListingItemViewModels.FirstOrDefault(y => y.Save.Id == save.Id);

            if(saveViewModel != null)
            {
                saveViewModel.Update(save);
            }
        }

        protected override void Dispose()
        {
            _saveStore.SavesLoaded -= SaveStore_SavesLoaded;
            _saveStore.SaveAdded -= SaveStore_SaveAdded;
            _saveStore.SaveUpdated -= SaveStore_SaveUpdated;
            _saveStore.SaveDeleted -= SaveStore_SaveDeleted;

            base.Dispose();
        }

        private void SaveStore_SaveAdded(Save save)
        {
            AddSave(save);
        }

        private void AddSave(Save save)
        {

            SavesListingItemViewModel itemViewModel = new SavesListingItemViewModel(save, _saveStore, _modalNavigationStore);
            _savesListingItemViewModels.Add(itemViewModel);
        }
    }
}


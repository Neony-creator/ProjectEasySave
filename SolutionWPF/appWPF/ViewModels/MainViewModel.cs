using appWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ModalNavigationStore modalNavigationStore;

        public ViewModelBase CurrentModalViewModel => modalNavigationStore.CurrentViewModel;
        public bool IsModalOpen => modalNavigationStore.IsOpen;
        public SavesViewModel SavesViewModel { get; }

        public MainViewModel(ModalNavigationStore modalNavigationStore, SavesViewModel savesViewModel)
        {
            this.modalNavigationStore = modalNavigationStore;
            SavesViewModel = savesViewModel;

            this.modalNavigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;

        }

        protected override void Dispose()
        {
            this.modalNavigationStore.CurrentViewModelChanged -= ModalNavigationStore_CurrentViewModelChanged;
            base.Dispose();
        }

        private void ModalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}

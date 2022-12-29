using SaveDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appWPF.Stores
{
    public class SelectedSaveStore
    {
        private readonly SavesStore _savesStore;
        private Save _selectedSave;
        public Save SelectedSave
        {
            get
            {
                return _selectedSave;
            }
            set
            {
                _selectedSave = value;
                SelectedSaveChanged?.Invoke();            }
        }

        public event Action SelectedSaveChanged;

        public SelectedSaveStore(SavesStore savesStore)
        {
            _savesStore = savesStore;
            _savesStore.SaveUpdated += SavesStore_SaveUpdated;
        }

        private void SavesStore_SaveUpdated(Save save)
        {
            if(save.Id == SelectedSave?.Id)
            {
                SelectedSave = save;
            }
        }
    }
}

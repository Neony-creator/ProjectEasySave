using appWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appWPF.Commands
{
    public class LoadSavesCommand : AsyncCommandBase
    {
        private readonly SavesStore _savesStore;

        public LoadSavesCommand(SavesStore savesStore)
        {
            _savesStore = savesStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {

            try
            {
                await _savesStore.Load();
            }
            catch (Exception)
            {
                throw;
            }            
            
        }
    }
}

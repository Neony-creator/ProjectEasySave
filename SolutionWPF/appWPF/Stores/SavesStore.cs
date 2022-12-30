using SaveDomain.Commands;
using SaveDomain.Models;
using SaveDomain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appWPF.Stores
{
    public class SavesStore
    {
        private readonly IGetAllSavesQuery _getAllSavesQuery;
        private readonly ICreateSaveCommand _createSaveCommand;
        private readonly IUpdateSaveCommand _updateSaveCommand;
        private readonly IDeleteSaveCommand _deleteSaveCommand;
        

        private readonly List<Save> _saves;
        public IEnumerable<Save> Saves => _saves;

        public event Action SavesLoaded;
        public event Action<Save> SaveAdded;
        public event Action<Save> SaveUpdated;
        public event Action<Guid> SaveDeleted;

        public SavesStore(IGetAllSavesQuery getAllSavesQuery, ICreateSaveCommand createSaveCommand, IUpdateSaveCommand updateSaveCommand, IDeleteSaveCommand deleteSaveCommand)
        {
            _getAllSavesQuery = getAllSavesQuery;
            _createSaveCommand = createSaveCommand;
            _updateSaveCommand = updateSaveCommand;
            _deleteSaveCommand = deleteSaveCommand;

            _saves = new List<Save>();
        }

        public async Task Load()
        {
            IEnumerable<Save> saves = await _getAllSavesQuery.Execute();
            _saves.Clear();
            _saves.AddRange(saves);

            SavesLoaded?.Invoke();
        }

        public async Task Add(Save save)
        {
            await _createSaveCommand.Execute(save);

            _saves.Add(save);

            SaveAdded?.Invoke(save);
        }

        public async Task Update(Save save)
        {
            await _updateSaveCommand.Execute(save);

            int currentIndex = _saves.FindIndex(y => y.Id == save.Id);

            if(currentIndex != -1)
            {
                _saves[currentIndex] = save;
            }
            else
            {
                _saves.Add(save);
            }

            SaveUpdated?.Invoke(save);
        }

        public async Task Delete(Guid id)
        {
            await _deleteSaveCommand.Execute(id);

            _saves.RemoveAll(y => y.Id == id);

            SaveDeleted?.Invoke(id);
        }
    }
}

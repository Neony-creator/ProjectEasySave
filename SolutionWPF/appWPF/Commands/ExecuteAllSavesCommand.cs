using appWPF.Stores;
using SaveDomain.Models;
using SaveDomain.Queries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace appWPF.Commands
{
    public class ExecuteAllSavesCommand : AsyncCommandBase
    {
        private readonly SavesStore _saveStore;

        

        public ExecuteAllSavesCommand(SavesStore savesStore)
        {
            _saveStore = savesStore;
        }


        public override async Task ExecuteAsync(object parameter)
        {

            List<Task> tasks = new List<Task>();



            foreach (Save save in _saveStore.Saves)
            {

                string name = save.SaveName;
                string source = save.SourceDisplay;
                string destination = save.DestinationDisplay;
                string typeOfBackUp = save.TypeDisplay;
                countNbTotalFile(name, source);
                if (typeOfBackUp == "complete")
                {
                    tasks.Add(Task.Run(() => completeFile(source, destination, name)));
                    tasks.Add(Task.Run(() => completeDirectory(source, destination, name)));

                }
                else if (typeOfBackUp == "differential")
                {
                    tasks.Add(Task.Run(() => differentialFile(source, destination, name)));
                    tasks.Add(Task.Run(() => differentialDirectory(source, destination, name)));

                }

            }

            await Task.WhenAll(tasks);
        }


        ////////////////////////////////////////////////////////////


        

        ////////////////////////////////////////////////////////////
    }
}
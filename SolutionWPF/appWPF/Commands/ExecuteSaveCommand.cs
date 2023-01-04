using appWPF.Stores;
using appWPF.ViewModels;
using SaveDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.IO;
using System.Text.Json;
using System.Diagnostics;
using System.Configuration;

namespace appWPF.Commands
{
    class ExecuteSaveCommand : AsyncCommandBase
    {
        private readonly SavesListingItemViewModel _savesListingItemViewModel;
        private readonly SavesStore _savesStore;

        public ExecuteSaveCommand(SavesListingItemViewModel savesListingItemViewModel, SavesStore savesStore)
        {
            _savesListingItemViewModel = savesListingItemViewModel;
            _savesStore = savesStore;
        }



        public override async Task ExecuteAsync(object parameter)
        {
            Save save = _savesListingItemViewModel.Save;
            string name = save.SaveName;
            string source = save.SourceDisplay;
            string destination = save.DestinationDisplay;
            string typeOfBackUp = save.TypeDisplay;
            List<Task> taskss = new List<Task>();

            if (typeOfBackUp == "complete")
            {
                taskss.Add(Task.Run(() => completeFile(source, destination, name)));
                taskss.Add(Task.Run(() => completeDirectory(source, destination, name)));

            }
            else if (typeOfBackUp == "differential")
            {
                taskss.Add(Task.Run(() => differentialFile(source, destination, name)));
                taskss.Add(Task.Run(() => differentialDirectory(source, destination, name)));

            }

        

        await Task.WhenAll(taskss);
    }


       


        ////////////////////////////////////////////////////////////


    }
}

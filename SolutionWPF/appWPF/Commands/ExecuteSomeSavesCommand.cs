using appWPF.Stores;
using appWPF.ViewModels;
using SaveDomain.Models;
using SaveDomain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace appWPF.Commands
{
    public class ExecuteSomeSavesCommand : AsyncCommandBase
    {
        private readonly ExecuteSomeSaveViewModel _executeSomeSaveViewModel;

        private readonly SavesListingItemViewModel _savesListingItemViewModel;
        private readonly SavesStore _savesStore;


        private readonly IGetAllSavesQuery _getAllSavesQuery;
        private readonly List<Save> _saves;
        public IEnumerable<Save> Saves => _saves;

        public ExecuteSomeSavesCommand(ExecuteSomeSaveViewModel executeSomeSaveViewModel, SavesStore savesStore)
        {
            _executeSomeSaveViewModel = executeSomeSaveViewModel;
            _savesStore = savesStore;
        }

        public override Task ExecuteAsync(object parameter)
        {
            throw new NotImplementedException();
        }
    }


        /*public override Task ExecuteAsync(object parameter)
        {
            ExecuteSomeSaveFormViewModel formViewModel = _executeSomeSaveViewModel.ExecuteSomeSaveFormViewModel;

            string names = formViewModel.SavesSelectedToExecute;

            string[] namesaves = Regex.Split(names, @"\D+");

            foreach (string nbr  in namesaves)
            {
                string name = nbr;


                //List<string> Result = _saves.FindAll(save.SaveName);

            }


            }*/
    
}

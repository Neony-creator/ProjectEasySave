using appWPF.Stores;
using appWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appWPF.Commands
{
    public class TypeLogCommand : AsyncCommandBase
    {
        private readonly TypeLogViewModel _typeLogViewModel;
        private readonly SavesStore _savesStore;
        private readonly ModalNavigationStore _modalNavigationStore;



        public TypeLogCommand(TypeLogViewModel typeLogViewModel, SavesStore savesStore, ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
            _typeLogViewModel = typeLogViewModel;
            _savesStore = savesStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            setChoiceTypeLogs();
            _modalNavigationStore.Close();
        }

        private void setChoiceTypeLogs() //Fonction qui permet d'attribuer un nom d'une sauvegarde à notre fichier config
        {
            TypeLogFormViewModel formViewModel = _typeLogViewModel.TypeLogFormViewModel;

            string result = formViewModel.log;
            string logFormat;

            if (result == "Json")
            {
                logFormat = "Json";
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("logFormat");
                config.AppSettings.Settings.Add("logFormat", logFormat);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            else if (result == "Xml")
            {
                logFormat = "Xml";
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("logFormat");
                config.AppSettings.Settings.Add("logFormat", logFormat);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            else if (result == "JsonXml")
            {
                logFormat = "JsonXml";
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("logFormat");
                config.AppSettings.Settings.Add("logFormat", logFormat);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
    }
}

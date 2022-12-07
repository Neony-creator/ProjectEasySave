using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ProjetEasySaveCLI
{
    class controllerChoiceLogs
    {
        string result;
        string logFormat;
        private modelMain menu = new modelMain(); //On instancie le model
        private viewMain viewMenu = new viewMain(); //On instancie la view
        private modelLogs menuChoiceLogs = new modelLogs(); //On instancie le modelChoiceLogs
        public controllerChoiceLogs()
        {

            viewMenu.display(menuChoiceLogs.MenuChoiceLogs()); //On affiche le menu principal de l'application


            while (true)
            {
                result = Console.ReadLine(); //On récupére l'entrée de l'utilisateur
                switch (result) //On utilise un switch case afin d'effectuer l'action correspondante à l'entrée de l'utilisateur 
                {
                    case "1":
                        Console.Clear(); //On efface les informations affichées sur la console
                        setChoiceTypeLogs();
                        viewMenu.display(menuChoiceLogs.TypeLogsJson());
                        Console.ReadLine();
                        Console.Clear();
                        loadChoiceTypeLogs();
                        break;

                    case "2":
                        Console.Clear();
                        setChoiceTypeLogs();
                        viewMenu.display(menuChoiceLogs.TypeLogsXml());
                        Console.ReadLine();
                        Console.Clear();
                        loadChoiceTypeLogs();
                        break;

                    case "3":
                        Console.Clear();
                        setChoiceTypeLogs();
                        viewMenu.display(menuChoiceLogs.TypeLogsJsonXml());
                        Console.ReadLine();
                        Console.Clear();
                        loadChoiceTypeLogs();
                        break;

                    case "4":
                        Console.Clear();
                        controllerMain mainmenu = new controllerMain(); //On retourne au menu
                        break;

                    default:
                        viewMenu.display(menu.GetError()); // On affiche une erreur si l'entrée de l'utilisateur ne correspond à aucun menu défini

                        break;
                }
            }





            

        }
        private void setChoiceTypeLogs() //Fonction qui permet d'attribuer un nom d'une sauvegarde à notre fichier config
        {
            if(result == "1")
            {
                logFormat = "Json";
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("logFormat");
                config.AppSettings.Settings.Add("logFormat", logFormat);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            else if(result == "2")
            {
                logFormat = "Xml";
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("logFormat");
                config.AppSettings.Settings.Add("logFormat", logFormat);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            else if (result == "3")
            {
                logFormat = "JsonXml";
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("logFormat");
                config.AppSettings.Settings.Add("logFormat", logFormat);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        public void loadChoiceTypeLogs()
        {
            controllerChoiceLogs choiceLogs = new controllerChoiceLogs();
        }

    }
}

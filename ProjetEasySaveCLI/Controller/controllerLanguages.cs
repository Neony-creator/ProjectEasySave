using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace ProjetEasySaveCLI
{
    class controllerLanguages
    {
        private modelLanguages menu = new modelLanguages();
        private viewLanguages viewMenu = new viewLanguages();
        modelMain langue = new modelMain();
        

        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        /*private string name;
        private string source;
        private string destination;
        private string typeOfBackUp;
        private string confirmation;*/
        public controllerLanguages()
        {
            menuLanguage();

        }

        public void menuLanguage()
        {
            viewMenu.display(menu.GetFirstMenuData());
            while (true)
            {
                string userchoice = Console.ReadLine();
                switch (userchoice)
                {
                    case "1":
                        Console.Clear();

                        config.AppSettings.Settings.Remove("language");
                        config.AppSettings.Settings.Add("language", "en");
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                        loadLanguage();

                        break;
                    case "2":
                        Console.Clear();

                        config.AppSettings.Settings.Remove("language");
                        config.AppSettings.Settings.Add("language", "fr");
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                        loadLanguage();


                        break;
                    case "3":
                        Console.Clear();
                        controllerMain mainmenu = new controllerMain();

                        break;

                    default:
                        viewMenu.display(menu.GetError());

                        break;
                }
            }
        }

        public void loadLanguage()
        {
            controllerLanguages language = new controllerLanguages();
        }

    }
}

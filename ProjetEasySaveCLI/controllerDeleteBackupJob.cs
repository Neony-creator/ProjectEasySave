using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace ProjetEasySaveCLI
{
    class controllerDeleteBackupJob
    {
        private modelBackupJob menu = new modelBackupJob();
        private viewDeleteBackupJob viewMenu = new viewDeleteBackupJob();

        string userchoice;

        public controllerDeleteBackupJob()
        {
            menu.affiche();
            viewMenu.display(menu.MenuDelete());
            viewMenu.display(menu.Backup1());
            viewMenu.display(menu.Backup2());
            viewMenu.display(menu.Backup3());
            viewMenu.display(menu.Backup4());
            viewMenu.display(menu.Backup5());
            viewMenu.display(menu.Return());
            

            while (true)
            {
                userchoice = Console.ReadLine();
                switch (userchoice)
                {
                    case "1":
                        Console.Clear();
                        Delete();
                        break;
                    case "2":
                        Console.Clear();
                        Delete();
                        break;
                    case "3":
                        Console.Clear();
                        Delete();
                        break;
                    case "4":
                        Console.Clear();
                        Delete();
                        break;
                    case "5":
                        Console.Clear();
                        Delete();
                        break;
                    case "6":
                        Console.Clear();
                        controllerMain mainmenu = new controllerMain();
                        break;

                    default:
                        viewMenu.display(menu.GetError());

                        break;
                }
            }

        }


        



        private void Delete()
        {
            

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("Name"+userchoice);
            config.AppSettings.Settings.Remove("Source" + userchoice);
            config.AppSettings.Settings.Remove("Destination" + userchoice);
            config.AppSettings.Settings.Remove("TypeOfBackUp" + userchoice);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

        }

        
    }
}

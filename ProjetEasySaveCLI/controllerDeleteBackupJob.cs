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


        



        private void Delete() //Fonction permettant la supression d'une sauvegarde existante
        {
            

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); //Ouvre notre fichier config
            config.AppSettings.Settings.Remove("Name"+userchoice); //Nous permet de supprimer les paramètres du fichier suprimmé par l'utilisateur de notre fichie config
            config.AppSettings.Settings.Remove("Source" + userchoice);
            config.AppSettings.Settings.Remove("Destination" + userchoice);
            config.AppSettings.Settings.Remove("TypeOfBackUp" + userchoice);
            int nbbackup = menu.ScearchNbBackUp() - 1; //On indique dans notre fichier config qu'il y a une sauvegarde de moins
            config.AppSettings.Settings.Remove("nbbackup");
            config.AppSettings.Settings.Add("nbbackup", nbbackup.ToString()); //Permet d'ajouter un paramètre dans notre fichier config
            config.Save(ConfigurationSaveMode.Modified); //Permet de sauvegarder notre fichier config
            ConfigurationManager.RefreshSection("appSettings"); //Permet d'actualiser notre fichier config

        }

        
    }
}

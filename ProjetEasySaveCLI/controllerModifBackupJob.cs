using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace ProjetEasySaveCLI
{
    class controllerModifBackupJob 
    {
        private modelBackupJob menu = new modelBackupJob();
        private viewModifBackupJob viewMenu = new viewModifBackupJob();

        string userchoice;

        private string name;
        private string source;
        private string destination;
        private string typeOfBackUp;
        private string confirmation;

        public controllerModifBackupJob()
        {
            menu.affiche();
            viewMenu.display(menu.MenuModif1());
            viewMenu.display(menu.Backup1());
            viewMenu.display(menu.Backup2());
            viewMenu.display(menu.Backup3());
            viewMenu.display(menu.Backup4());
            viewMenu.display(menu.Backup5());
            viewMenu.display(menu.Return());

            userchoice = Console.ReadLine();





            while (true)
            {
                 
                Console.Clear();
                viewMenu.display(menu.MenuModiff());
                string userchoice2 = Console.ReadLine();

                switch (userchoice2)
                {
                    case "1":
                        Console.Clear();
                        setNameDataBackUp();
                        Console.WriteLine(name);
                        setConfirmationDataBackUp();

                        break;
                    case "2":
                        Console.Clear();
                        setSourceDataBackUp();
                        Console.WriteLine(source);
                        setConfirmationDataBackUp();

                        break;
                    case "3":
                        Console.Clear();
                        setDestinationDataBackUp();
                        Console.WriteLine(destination);
                        setConfirmationDataBackUp();

                        break;
                    case "4":
                        Console.Clear();
                        setTypeBackupDataBackUp();
                        Console.WriteLine(typeOfBackUp);
                        setConfirmationDataBackUp();

                        break;
                    case "5":
                        Console.Clear();
                        controllerBackupJob backupmenu = new controllerBackupJob();
                        break;

                    default:
                        viewMenu.display(menu.GetError());

                        break;
                }
            }

        }


        


        private void setNameDataBackUp() //Fonction qui permet d'attribuer un nom d'une sauvegarde à notre fichier config
        {
            viewMenu.display(menu.GetName());
            name = Console.ReadLine();

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("Name" + userchoice);
            config.AppSettings.Settings.Add("Name" + userchoice, name);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");


        }

        private void setSourceDataBackUp() //Fonction qui permet d'attribuer une source d'une sauvegarde à notre fichier config
        {
            viewMenu.display(menu.GetSource());
            source = Console.ReadLine();

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("Source" + userchoice);
            config.AppSettings.Settings.Add("Source" + userchoice, source);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void setDestinationDataBackUp() //Fonction qui permet d'attribuer une destination d'une sauvegarde à notre fichier config
        {
            viewMenu.display(menu.GetDestination());
            destination = Console.ReadLine();

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("Destination" + userchoice);
            config.AppSettings.Settings.Add("Destination" + userchoice, destination);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void setTypeBackupDataBackUp() //Fonction qui permet d'attribuer un type de backup d'une sauvegarde à notre fichier config
        {
            viewMenu.display(menu.GetTypeBackUp());
            typeOfBackUp = Console.ReadLine();
            if (typeOfBackUp == "1")
            {
                typeOfBackUp = "complete";
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("TypeOfBackUp" + userchoice);
                config.AppSettings.Settings.Add("TypeOfBackUp" + userchoice, typeOfBackUp);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                
            }
            else
            {
                typeOfBackUp = "differential";
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("TypeOfBackUp" + userchoice);
                config.AppSettings.Settings.Add("TypeOfBackUp" + userchoice, typeOfBackUp);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void setConfirmationDataBackUp() //Fonction qui permet à l'utilisateur de valider s'il souhaite confirmer les informations qu'il a saisit
        {
            viewMenu.display(menu.GetConfirmation());
            confirmation = Console.ReadLine();
            if (confirmation == "y")
            {
                viewMenu.display(menu.GetFirstMenuData());
            }
            else if (confirmation == "n")
            {
                viewMenu.display(menu.GetFirstMenuData());
            }
            else
            {
                viewMenu.display(menu.GetError());
                //confirmation = "";
                setConfirmationDataBackUp();
            }
        }

       

        


    }
}

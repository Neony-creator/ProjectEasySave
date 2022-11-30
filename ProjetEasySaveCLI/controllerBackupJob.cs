using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Configuration;

namespace ProjetEasySaveCLI
{
    class controllerBackupJob
    {
        private modelBackupJob model = new modelBackupJob();
        private viewBackupJob viewMenu = new viewBackupJob();
        private string name;
        private string source;
        private string destination;
        private string typeOfBackUp;
        private string confirmation;



        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public controllerBackupJob()
        {
            viewMenu.display(model.GetFirstMenuData());
            while (true)
            {
                string userchoice = Console.ReadLine();
                switch (userchoice)
                {
                    case "1":
                        Console.Clear();
                        controllerExecuteBackupJob executemenu = new controllerExecuteBackupJob();

                        break;
                    case "2":
                        Console.Clear();
                        verifyNbBackUp();
                        setCreationDataBackUp();
                        viewMenu.display(model.ValidateCreate());
                        break;
                    case "3":
                        Console.Clear();
                        controllerModifBackupJob modiffmenu = new controllerModifBackupJob();

                        break;
                    case "4":
                        Console.Clear();
                        controllerDeleteBackupJob supprmenu = new controllerDeleteBackupJob();

                        break;
                    case "5":
                        Console.Clear();
                        controllerMain mainmenu = new controllerMain();
                        break;

                    default:
                        viewMenu.display(model.GetError());

                        break;
                }
            }

        }

        private void setCreationDataBackUp()
        {
            while (true)
            {
                affiche();
                viewMenu.display(model.GetName());
                name = Console.ReadLine();


                viewMenu.display(model.GetSource());
                source = Console.ReadLine();

                viewMenu.display(model.GetDestination());
                destination = Console.ReadLine();

                viewMenu.display(model.GetConfirmation());
                confirmation = Console.ReadLine();

                if (confirmation == "y")
                {

                    viewMenu.display(model.GetTypeBackUp());
                    typeOfBackUp = Console.ReadLine();
                    if (typeOfBackUp == "1")
                    {
                        typeOfBackUp = "complete";
                        model.completeFile(source, destination);
                        model.completeDirectory(source, destination);
                        SetConfManager();
                        controllerMain mainmenu = new controllerMain();
                        Console.Clear();

                    }
                    else
                    {
                        typeOfBackUp = "differential";
                        model.differentialFile(source, destination);
                        model.differentialDirectory(source, destination);
                        SetConfManager();
                        controllerMain mainmenu = new controllerMain();
                        Console.Clear();
                    }

                }
                Console.Clear();


            }

        }


        void SetConfManager()
        {
            int nbBackUp = model.ScearchNbBackUp() + 1;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add("Name" + nbBackUp, name);
            config.AppSettings.Settings.Add("Source" + nbBackUp, source);
            config.AppSettings.Settings.Add("Destination" + nbBackUp, destination);
            config.AppSettings.Settings.Add("TypeOfBackUp" + nbBackUp, typeOfBackUp);
            config.AppSettings.Settings.Remove("nbbackup");
            config.AppSettings.Settings.Add("nbbackup", nbBackUp.ToString());

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            affiche();
        }
        void affiche()
        {
            Console.Clear();
            for (int i = 1; i <= model.ScearchNbBackUp(); i++)
            {

                Console.WriteLine(ConfigurationManager.AppSettings["Name" + i]);
                Console.WriteLine(ConfigurationManager.AppSettings["Source" + i]);
                Console.WriteLine(ConfigurationManager.AppSettings["Destination" + i]);
                Console.WriteLine(ConfigurationManager.AppSettings["TypeOfBackUp" + i]);
                Console.ReadLine();

            }
        }


        public void verifyNbBackUp()
        {
            if (ConfigurationManager.AppSettings["nbBackUp"] == "5")
            {
                viewMenu.display(model.GetErrorNB());
                /*controllerDeleteBackupJob er = new controllerDeleteBackupJob();*/
            }
        }






    }
}

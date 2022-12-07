using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models;
using System.IO;
using System.Text.Json;
using System.Diagnostics;
using System.Configuration;

namespace WPF.Controllers
{
    class ControllerCreate
    {
        private modelCreate model = new modelCreate();
        private CreateView create = new CreateView();

        private string confirmation;

        public ControllerCreate()
        { 
            verifyNbBackUp(); //On appelle la fonciton "verifyNbBackUp"
            setCreationDataBackUp();
        }



        private void setCreationDataBackUp() //Fonction permmettant la création d'une sauvegarde
        {
            while (true)
            {
                /*affichage des différents menus*/
                model.affiche();
                /*viewMenu.display(model.GetName());
                name = Console.ReadLine();

                viewMenu.display(model.GetSource());
                source = Console.ReadLine();
                model.countNbTotalFile(source);
                viewMenu.display(model.GetDestination());
                destination = Console.ReadLine();

                viewMenu.display(model.GetConfirmation());
                confirmation = Console.ReadLine();
                */
                //if (confirmation == "y")
                //{

                    /*viewMenu.display(model.GetTypeBackUp());
                    typeOfBackUp = Console.ReadLine();*/
                    if (create.type == "1")
                    {
                        create.type = "complete";
                        model.completeFile(create.source, create.destination, create.name);
                        model.completeDirectory(create.source, create.destination, create.name);
                        SetConfManager();
                        /*controllerMain mainmenu = new controllerMain();
                        Console.Clear();*/

                    }
                    else
                    {
                        create.type = "differential";
                        model.differentialFile(create.source, create.destination, create.name);
                        model.differentialDirectory(create.source, create.destination, create.name);
                        SetConfManager();
                        /*controllerMain mainmenu = new controllerMain();
                        Console.Clear();*/
                    }

                //}
                //Console.Clear();


            }

        }


        void SetConfManager() //Foontion permetant l'ajout des paramètres d'une sauvegarde dans notre fichier config
        {
            int nbBackUp = model.ScearchNbBackUp() + 1;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add("Name" + nbBackUp, create.name);
            config.AppSettings.Settings.Add("Source" + nbBackUp, create.source);
            config.AppSettings.Settings.Add("Destination" + nbBackUp, create.destination);
            config.AppSettings.Settings.Add("TypeOfBackUp" + nbBackUp, create.type);
            config.AppSettings.Settings.Remove("nbbackup");
            config.AppSettings.Settings.Add("nbbackup", nbBackUp.ToString());

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            model.affiche();
        }



        public void verifyNbBackUp() //Fonction vérifiant que l'utilisateur n'ai pas dépassé le nombre maximum de sauvegarde
        {
            if (model.ScearchNbBackUp() >= 5)
            {
                /*viewMenu.display(model.GetErrorNB());
                Console.ReadLine();
                controllerMain mainmenu = new controllerMain();
                /*controllerDeleteBackupJob er = new controllerDeleteBackupJob();*/
            }
        }
    }
}

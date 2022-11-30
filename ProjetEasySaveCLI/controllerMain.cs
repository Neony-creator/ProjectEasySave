using System;
using System.Configuration;

namespace ProjetEasySaveCLI
{
    class controllerMain
    {
        string result;
        private modelMain menu = new modelMain(); //On instancie le model
        private viewMain viewMenu = new viewMain(); //On instancie la view
        public controllerMain()
        {
           
            viewMenu.display(menu.GetinterfaceData()); //On affiche le menu principal de l'application


            while (true)
            {
                result = Console.ReadLine(); //On récupére l'entrée de l'utilisateur
                switch (result) //On utilise un switch case afin d'effectuer l'action correspondante à l'entrée de l'utilisateur 
                {
                    case "1":
                        Console.Clear(); //On efface les informations affichées sur la console
                        controllerBackupJob backup = new controllerBackupJob(); //On instancie le controller de Backup, qui prendrera le relais afin d'entrer dans le menu de sauvegarde
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine(menu.ScearchNbBackUp());
                        controllerLogs logs = new controllerLogs(); //On instancie le controller de logs, qui prendrera le relais afin d'entrer le menu de logs
                        break;

                    case "3":
                        Console.Clear();
                        controllerLanguages language = new controllerLanguages(); //On instancie le controller de langage, qui prendrera le relais afin d'entrer le menu de changement de langue
                        break;

                    default:
                        viewMenu.display(menu.GetError()); // On affiche une erreur si l'entrée de l'utilisateur ne correspond à aucun menu défini

                        break;
                }
            }



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEasySaveCLI
{
    class controllerChoiceLogs
    {
        string result;
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
                        
                        break;

                    case "2":
                        Console.Clear();
                        
                        break;

                    case "3":
                        Console.Clear();
                        controllerMain mainmenu = new controllerMain(); //On retourne au menu
                        break;

                    default:
                        viewMenu.display(menu.GetError()); // On affiche une erreur si l'entrée de l'utilisateur ne correspond à aucun menu défini

                        break;
                }
            }



        }

    }
}

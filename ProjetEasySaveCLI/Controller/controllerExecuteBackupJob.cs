using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;

namespace ProjetEasySaveCLI
{
    class controllerExecuteBackupJob
    {
            private modelBackupJob menu = new modelBackupJob();
            private viewExecuteBackupJob viewMenu = new viewExecuteBackupJob();
    
    
            public controllerExecuteBackupJob()
            {
                menu.affiche();
                viewMenu.display(menu.MenuExecute());
                viewMenu.display(menu.Return());

                while (true)
                {

                    execute();

                }

            }

            private void execute() //Fonction qui permet d'executer une sauvergade existante
            {
                string inputuser = Console.ReadLine();

                if(inputuser == "6")
                {
                    Console.Clear();
                    controllerMain mainmenu = new controllerMain();
                }
                else 
                    { 
                    string[] numbers = Regex.Split(inputuser, @"\D+"); //Permet de récupérer uniquement les chiffres d'une chaîne de caractère
                    foreach (string nbr in numbers)
                    {
                        string name = ConfigurationManager.AppSettings["Name" + nbr]; //Permet de récupérer une valeur correspondante à un ID de notre fichier config
                        string source = ConfigurationManager.AppSettings["Source" + nbr]; 
                        string destination = ConfigurationManager.AppSettings["Destination" + nbr]; 
                        string typeOfBackUp = ConfigurationManager.AppSettings["TypeOfBackUp" + nbr];
                        menu.countNbTotalFile(source);
                        if (typeOfBackUp == "complete")
                        {
                            menu.completeFile(source, destination, name);
                            menu.completeDirectory(source, destination, name);
                            controllerMain mainmenu = new controllerMain();
                            Console.Clear();

                        }
                        else if(typeOfBackUp == "differential")
                        {
                            menu.differentialFile(source, destination, name);
                            menu.differentialDirectory(source, destination, name);
                            controllerMain mainmenu = new controllerMain();
                            Console.Clear();
                        }
    
                    }
                }
            }



    }
}




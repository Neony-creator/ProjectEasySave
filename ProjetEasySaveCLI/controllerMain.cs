using System;
using System.Configuration;

namespace ProjetEasySaveCLI
{
    class controllerMain
    {
        string result;
        private modelMain menu = new modelMain();
        private viewMain viewMenu = new viewMain();
        public controllerMain()
        {
           
            viewMenu.display(menu.GetinterfaceData());


            while (true)
            {
                result = Console.ReadLine();
                switch (result)
                {
                    case "1":
                        Console.Clear();
                        controllerBackupJob backup = new controllerBackupJob();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine(menu.ScearchNbBackUp());
                        controllerLogs logs = new controllerLogs();
                        break;

                    case "3":
                        Console.Clear();
                        controllerLanguages language = new controllerLanguages();
                        break;

                    default:
                        viewMenu.display(menu.GetError());

                        break;
                }
            }



        }
    }
}

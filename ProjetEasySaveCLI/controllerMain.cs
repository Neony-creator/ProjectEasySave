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

                    default:
                        viewMenu.display(menu.GetError());

                        break;
                }
            }



        }
    }
}

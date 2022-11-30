using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetEasySaveCLI
{
    class controllerLogs
    {

        private modelLogs menu = new modelLogs();
        private viewLogs viewMenu = new viewLogs();
        
        public controllerLogs()
        {
            viewMenu.display(menu.GetFirstMenuData());
            while (true)
            {
                string userchoice = Console.ReadLine();
                switch (userchoice)
                {
                    case "1":
                        Console.Clear();

                        break;
                    case "2":
                        Console.Clear();

                        break;
                    case "3":
                        Console.Clear();
                        controllerMain mainmenu = new controllerMain();

                        break;

                    default:
                        viewMenu.display(menu.GetError());

                        break;
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetEasySaveCLI
{
    class controllerBackupJob
    {
        private modelBackupJob menu = new modelBackupJob();
        private viewBackupJob viewMenu = new viewBackupJob();
        private string name;
        private string source;
        private string destination;
        private string typeOfBackUp;
        private string confirmation;
        public controllerBackupJob()
        {
            viewMenu.display(menu.GetFirstMenuData());
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
                        setCreationDataBackUp();
                        break;

                    case "5":
                        Console.Clear();
                        controllerMain mainmenu = new controllerMain();
                        break;

                    default:
                        viewMenu.display(menu.GetError());

                        break;
                }
            }

        }

        private void setCreationDataBackUp()
        {
            while(true)
            {
                viewMenu.display(menu.GetName());
                name = Console.ReadLine();

                viewMenu.display(menu.GetSource());
                source = Console.ReadLine();

                viewMenu.display(menu.GetDestination());
                destination = Console.ReadLine();

                viewMenu.display(menu.GetTypeBackUp());
                typeOfBackUp = Console.ReadLine();
                if (typeOfBackUp == "1")
                {
                    typeOfBackUp = "complete";
                }
                else
                {
                    typeOfBackUp = "differential";
                }

                viewMenu.display(menu.GetConfirmation());
                confirmation = Console.ReadLine();

                if (confirmation == "y")
                {

                }
            }

        }

        public void complete()
        {

        }
    }
}

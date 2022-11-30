using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetEasySaveCLI
{
    class controllerModifBackupJob 
    {
        private modelBackupJob menu = new modelBackupJob();
        private viewModifBackupJob viewMenu = new viewModifBackupJob();


        private string name;
        private string source;
        private string destination;
        private string typeOfBackUp;
        private string confirmation;

        public controllerModifBackupJob()
        {
            viewMenu.display(menu.MenuModiff());
            while (true)
            {
                string userchoice = Console.ReadLine();
                switch (userchoice)
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


        


        private void setNameDataBackUp()
        {
            viewMenu.display(menu.GetName());
            name = Console.ReadLine();
        }

        private void setSourceDataBackUp()
        {
            viewMenu.display(menu.GetSource());
            source = Console.ReadLine();
        }

        private void setDestinationDataBackUp()
        {
            viewMenu.display(menu.GetDestination());
            destination = Console.ReadLine();
        }

        private void setTypeBackupDataBackUp()
        {
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
        }

        private void setConfirmationDataBackUp()
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

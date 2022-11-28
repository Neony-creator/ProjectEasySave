using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetEasySaveCLI
{
    class controllerExecuteBackupJob
    {
            private modelExecuteBackupJob menu = new modelExecuteBackupJob();
            private viewExecuteBackupJob viewMenu = new viewExecuteBackupJob();
            /*private string name;
            private string source;
            private string destination;
            private string typeOfBackUp;
            private string confirmation;*/
            public controllerExecuteBackupJob()
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

                            break;
                        case "4":
                            Console.Clear();

                            break;
                        case "5":
                            Console.Clear();

                            break;
                        case "6":
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




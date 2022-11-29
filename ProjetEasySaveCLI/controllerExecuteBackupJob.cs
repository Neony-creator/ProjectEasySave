using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetEasySaveCLI
{
    class controllerExecuteBackupJob
    {
            private modelBackupJob menu = new modelBackupJob();
            private viewExecuteBackupJob viewMenu = new viewExecuteBackupJob();
    
            public controllerExecuteBackupJob()
            {
                viewMenu.display(menu.MenuExecute());
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




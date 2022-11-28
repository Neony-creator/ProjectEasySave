using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetEasySaveCLI
{
    class controllerLanguages
    {
        private modelLanguages menu = new modelLanguages();
        private viewLanguages viewMenu = new viewLanguages();
        modelMain langue = new modelMain();
        /*private string name;
        private string source;
        private string destination;
        private string typeOfBackUp;
        private string confirmation;*/
        public controllerLanguages()
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
                        langue.ConfigLanguage = "fr";
                        controllerLanguages language = new controllerLanguages();

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

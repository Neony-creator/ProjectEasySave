using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;


namespace ProjetEasySaveCLI
{
    class modelLanguages : modelMain
    {
        /*private const string FIRST_MENU_FR = "Quelle langue souhaitez vous appliquer ?\n" +
            "Choisissez une des options (1,2,3):\n" +
            "1-Anglais\n" +
            "2-Francais\n" +
            "3-Retour";
        */


        public string GetFirstMenuData()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string FIRST_MENU = $"{langue.MenuLangues}";
            return FIRST_MENU;
        }

    }

}
